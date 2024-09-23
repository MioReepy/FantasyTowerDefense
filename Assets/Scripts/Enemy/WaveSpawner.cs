using System.Collections;
using UnityEngine;
using WaypointSpase;

namespace EnemySpace
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private float _waveNumber = 1f;
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _coolDownWaves = 5f;
        [SerializeField] private float _timeBetweenEnemySpawns = 0.5f;

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

            _waveNumber++;  
        }

        private void SpawnEnemy()
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            enemy.GetComponent<WaypointNavigator>()._currentWaypoint = _waypoint;
        }
    }
}