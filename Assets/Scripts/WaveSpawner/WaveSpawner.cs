using System.Collections;
using UnityEngine;
using WaypointSpase;

namespace WaveSpawnerSpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private float _timeBetweenWaves = 5f;
        private float _coolDownWaves = 5f;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] internal float _waveSpawnerWidth = 5f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private ObjectPool _enemyPool;

        private int _currentWave = 0;

        private void Start()
        {
            _enemyPool = GetComponent<ObjectPool>();
            minBounds = transform.position + transform.right * _waveSpawnerWidth / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWidth / 2;
        }

        private void Update()
        {
            if (_currentWave < waves.Length)
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
            for (int i = 0; i < waves[_currentWave].enemy.Length; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(waves[_currentWave].timeBetweenEnemies);
            }

            _currentWave++;
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