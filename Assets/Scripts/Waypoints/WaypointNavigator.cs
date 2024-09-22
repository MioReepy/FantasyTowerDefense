using EnemySpace;
using UnityEngine;

namespace WaypointSpase
{
    public class WaypointNavigator : MonoBehaviour
    {
        [SerializeField] private EnemyNavigator _enemyNavigator;
        [SerializeField] private Waypoint _currentWaypoint;

        private void Awake()
        {
            _enemyNavigator = GetComponent<EnemyNavigator>();
        }

        private void Update()
        {
            if (!_enemyNavigator._isReachedDestination)
            {
                _currentWaypoint = _currentWaypoint.nextWaypoint;
                _enemyNavigator.SetDestination(_currentWaypoint);
            }
        }
    }
}