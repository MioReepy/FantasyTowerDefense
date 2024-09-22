using UnityEngine;
using WaypointSpase;

namespace EnemySpace
{
    public class EnemyNavigator : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 10f;
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
                    _isReachedDestination = true;
                    Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                        _rotationSpeed * Time.deltaTime);
                    transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
                }
                else
                {
                    _isReachedDestination = false;
                }
            }
        }

        internal void SetDestination(Waypoint waypoint)
        {
            _destination = Vector3.Lerp(waypoint.minBounds, waypoint.maxBounds, Random.Range(0f, 1f));
            _isReachedDestination = false;
        }
    }
}