using System.Collections;
using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace WaveSpawnerSpace
{
    public class WaveSpawnerOld : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private float _waveNumber = 3f;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _coolDownWaves = 5f;
        [SerializeField] private float _timeBetweenEnemySpawns = 0.5f;

        [SerializeField] internal float _waveSpawnerWeight = 5f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        private void Start()
        {
            _enemyPrefab.GetComponent<WaypointNavigator>()._currentWaypoint = _waypoint;
            minBounds = transform.position + transform.right * _waveSpawnerWeight / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWeight / 2;
        }

        private void Update()
        {
            if (_coolDownWaves <= 0f)
            {
                StartCoroutine(SpawnWave());
                _coolDownWaves = _timeBetweenWaves;
            }
            _coolDownWaves -= Time.deltaTime;
        }

        private IEnumerator SpawnWave()
        {
            for (int i = 0; i < _waveNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_timeBetweenEnemySpawns);
            }

            _waveNumber--;  
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPosition = Vector3.Lerp(minBounds, maxBounds, Random.Range(0f, 1f));
            var enemy = Instantiate(_enemyPrefab, spawnPosition, transform.rotation);
            enemy.GetComponent<WaypointNavigator>()._currentWaypoint = _waypoint;
        }
    }
}