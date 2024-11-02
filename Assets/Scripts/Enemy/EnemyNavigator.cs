using UnityEngine;
using WaypointSpase;
using Random = UnityEngine.Random;

namespace EnemySpace
{
    public class EnemyNavigator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private float _stopDistance = 10f;

        internal bool _isReachedDestination;
        private Vector3 _destination;

        private void Update()
        {
            if (transform.position != _destination)
            {
                Vector3 destinationDirection = _destination - transform.position;
                destinationDirection.y = 0f;
                
                float destinationDistance = destinationDirection.magnitude;

                if (destinationDistance >= _stopDistance)
                {
                    EnemyMove(destinationDirection);
                }
                else
                {
                    _isReachedDestination = false;
                }
            }
        }

        private void EnemyMove(Vector3 destinationDirection)
        {
            _isReachedDestination = true;
            Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                _rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * (gameObject.GetComponent<Enemy>().enemy.enemySpeed * Time.deltaTime));
        }

        internal void SetDestination(Waypoint waypoint)
        {
            _destination = Vector3.Lerp(waypoint.minBounds, waypoint.maxBounds, Random.Range(0f, 1f));
            _isReachedDestination = false;
        }
    }
}