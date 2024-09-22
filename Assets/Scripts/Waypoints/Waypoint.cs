using UnityEngine;

namespace WaypointSpase
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] internal Waypoint nextWaypoint;
        [SerializeField] internal Waypoint previousWaypoint;
        [SerializeField] internal float weight = 6f;

        public Vector3 GetPosition()
        {
            Vector3 minBounds = transform.position + transform.right * weight / 2;
            Vector3 maxBounds = transform.position - transform.right * weight / 2;
            return Vector3.Lerp(minBounds, maxBounds, Random.Range(0f, 1f));
        }
    }
}
