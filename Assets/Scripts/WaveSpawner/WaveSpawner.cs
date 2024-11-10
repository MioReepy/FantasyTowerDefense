using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnemySpace;
using GameController;
using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace WaveSpawnerSpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] internal Wave[] waves;
        [SerializeField] internal float _waveSpawnerWidth = 5f;
        [SerializeField] internal float _timeBetweenWaves = 5f;
        [SerializeField] private float _timeBetweenEnemies = 0.5f;
        [SerializeField] private GameObject _enemyPortal;
        internal float coolDownWaves = 0f;
        internal int _currentWave = 0;
        private List<Enemies> _enemyObjects;
        private Vector3 _minBounds;
        private Vector3 _maxBounds;

        public static WaveSpawner Instance;
        private void Awake() => Instance = this;

        private void Start()
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
                    Finish.Instance.SetEnemy(enemyObject.enemyCount);
                }
            }
            
            _minBounds = transform.position + transform.right * _waveSpawnerWidth / 2;
            _maxBounds = transform.position - transform.right * _waveSpawnerWidth / 2;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_currentWave < waves.Length)
            {
                coolDownWaves = _timeBetweenWaves;
                yield return new WaitForSeconds(_timeBetweenWaves);
                
                foreach (var enemy in _enemyObjects.Where(enemy => enemy.waveNumber == _currentWave))
                {
                    for (int i = 0; i < enemy.enemyCount; i++)
                    {
                        SpawnEnemy(enemy.enemyObject.enemyType);
                        yield return new WaitForSeconds(_timeBetweenEnemies);   
                    }
                }

                _currentWave++;
            }
        }

        private void SpawnEnemy(EnemyType enemyType)
        {
            GameObject enemyObject = EnemyPool.GetEnemy(enemyType);

            if (enemyObject == null) return;
            
            enemyObject.GetComponent<WaypointNavigator>().UpdateWaypoint(_waypoint);
            Vector3 spawnPosition = Vector3.Lerp(_minBounds, _maxBounds, Random.Range(0f, 1f));
            enemyObject.transform.position = spawnPosition;
            enemyObject.transform.rotation = transform.rotation;
            GameObject enemyPool = EnemyPortalObjectPool.Singleton.GetPoolObject();
            enemyPool.SetActive(true);
            enemyPool.transform.position = spawnPosition;
            enemyPool.transform.rotation = transform.rotation;
            enemyObject.SetActive(true);
        }
    }
}