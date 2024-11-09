using EnemySpace;
using UnityEngine;

namespace WaypointSpase
{
    public class WaypointNavigator : MonoBehaviour
    {
        [SerializeField] private EnemyNavigator _enemyNavigator;
        [SerializeField] internal Waypoint _currentWaypoint;

        private void Awake()
        {
            _enemyNavigator = GetComponent<EnemyNavigator>();
        }

        private void Start()
        {
            _enemyNavigator.SetDestination(_currentWaypoint);
        }

        private void Update()
        {
            SetCurrentWaypoint();
        }

        private void SetCurrentWaypoint()
        {
            if (!_enemyNavigator.isReachedDestination)
            {
                _currentWaypoint = _currentWaypoint.nextWaypoint;
                _enemyNavigator.SetDestination(_currentWaypoint);
            }
        }

        internal void UpdateWaypoint(Waypoint waypoint)
        {
            _currentWaypoint = waypoint;
            _enemyNavigator.SetDestination(_currentWaypoint);

        }
    }
}