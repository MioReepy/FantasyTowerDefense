using System.Collections;
using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace WaveSpawnerSpace
{
    public class WaveSpawnerOld : MonoBehaviour
    {
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private int _waveNumber = 3;
        [SerializeField] private int _startEnemiesCount = 3;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _timeBetweenEnemySpawns = 0.5f;

        [SerializeField] internal float _waveSpawnerWeight = 5f;
        [SerializeField] private ObjectPool _enemyPool;
        [SerializeField] private Transform _spawnPoint;
        private float _coolDownWaves = 5f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        private void Start()
        {
            _enemyPool = GetComponent<ObjectPool>();
            minBounds = transform.position + transform.right * _waveSpawnerWeight / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWeight / 2;
        }

        private void Update()
        {
            if (_waveNumber > 0)
            {
                if (_coolDownWaves <= 0f)
                {
                    StartCoroutine(SpawnWave());
                    _coolDownWaves = _timeBetweenWaves;
                }

                _coolDownWaves -= Time.deltaTime;
            }
        }

        private IEnumerator SpawnWave()
        {
            for (int i = 0; i < _startEnemiesCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_timeBetweenEnemySpawns);
            }

            _waveNumber--;
            _startEnemiesCount++;
        }

        private void SpawnEnemy()
        {
            GameObject enemyObject = _enemyPool.GetPoolObject();

            if (enemyObject != null)
            {
                enemyObject.GetComponent<WaypointNavigator>().UpdateWaypoint(_waypoint);
                Vector3 spawnPosition = Vector3.Lerp(minBounds, maxBounds, Random.Range(0f, 1f));
                enemyObject.transform.parent = _enemyPool.spawnObject.transform;
                enemyObject.transform.position = spawnPosition;
                enemyObject.transform.rotation = transform.rotation;

                enemyObject.SetActive(true);
            }
        }
    }
}