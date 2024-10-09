using System.Collections;
using System.Collections.Generic;
using EnemySpace;
using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace WaveSpawnerSpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Wave[] waves;
        [SerializeField] internal float _waveSpawnerWidth = 5f;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _timeBetweenEnemies = 0.5f;
        private float _coolDownWaves = 5f;
        private int _currentWave = 0;
        private List<Enemies> _enemyObjects;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;
        
        private void Awake()
        {
            _enemyObjects = new List<Enemies>();
            
            for (int wave = 0; wave < waves.Length; wave++)
            {
                for (int enemy = 0; enemy < waves[wave].enemies.Length; enemy++)
                {
                    var enemyObject = waves[wave].enemies[enemy];
                    enemyObject.waveNumber = wave;
                    _enemyObjects.Add(enemyObject);
                    EnemyPool.CreateEnemyPool(enemyObject.enemyObject.enemyType, enemyObject.enemyCount);
                }
            }
        }

        private void Start()
        {
            minBounds = transform.position + transform.right * _waveSpawnerWidth / 2;
            maxBounds = transform.position - transform.right * _waveSpawnerWidth / 2;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_currentWave < waves.Length)
            {
                foreach (var enemy in _enemyObjects)
                {
                    if (enemy.waveNumber != _currentWave)
                    {
                        continue;
                    }
                    
                    for (int i = 0; i < enemy.enemyCount; i++)
                    {
                        SpawnEnemy(enemy.enemyObject.enemyType);
                        yield return new WaitForSeconds(_timeBetweenEnemies);   
                    }
                }

                _currentWave++;
                yield return new WaitForSeconds(_timeBetweenWaves);
            }
        }

        private void SpawnEnemy(EnemyType enemyType)
        {
            GameObject enemyObject = EnemyPool.GetEnemy(enemyType);

            if (enemyObject != null)
            {
                enemyObject.GetComponent<WaypointNavigator>().UpdateWaypoint(_waypoint);
                Vector3 spawnPosition = Vector3.Lerp(minBounds, maxBounds, Random.Range(0f, 1f));
                
                enemyObject.transform.position = spawnPosition;
                enemyObject.transform.rotation = transform.rotation;

                enemyObject.SetActive(true);
            }
        }
    }
}