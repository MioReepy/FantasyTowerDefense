using System.Collections;
using UnityEngine;
using WaypointSpase;

namespace WaveSpawnerSpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _timeBetweenEnemies = 0.5f;
        private float _coolDownWaves = 5f;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] internal float _waveSpawnerWidth = 5f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private EnemyObjectPool _enemyPool;

        private int _currentWave = 0;

        private void Start()
        {
            _enemyPool = GetComponent<EnemyObjectPool>();
            minBounds = transform.position + transform.right * _waveSpawnerWidth / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWidth / 2;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_currentWave < waves.Length)
            {
                for (int i = _currentWave; i < waves.Length; i++)
                {
                    StartCoroutine(SpawnWaves(_currentWave));
                    
                    yield return new WaitForSeconds(_timeBetweenWaves);
                }
            }
        }

        private IEnumerator SpawnWaves(int waveNumber)
        {
            while (_currentWave == waveNumber)
            {
                for (int i = 0; i < waves[waveNumber].enemies.Length; i++)
                {
                    for (int j = 0; j < waves[waveNumber].enemies[i].count; j++)
                    {
                        SpawnEnemy();
                        yield return new WaitForSeconds(_timeBetweenEnemies);
                    }
                }
                
                _currentWave++;
            }
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