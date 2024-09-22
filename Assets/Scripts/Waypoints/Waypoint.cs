using UnityEngine;

namespace WaypointSpase
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] internal Waypoint nextWaypoint;
        [SerializeField] internal Waypoint previousWaypoint;
        [SerializeField] internal float weight = 6f;

        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        private void Start()
        {
            minBounds = transform.position + transform.right * weight / 2;
            maxBounds = transform.position - transform.right * weight / 2;
        }
    }
}
