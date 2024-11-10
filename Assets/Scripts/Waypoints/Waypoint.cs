using UnityEngine;

namespace WaypointSpase
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] internal Waypoint nextWaypoint;
        [SerializeField] internal Waypoint previousWaypoint;
        [SerializeField] internal float waypointWeight = 6f;
        internal Vector3 minBounds;
        internal Vector3 maxBounds;

        private void Start()
        {
            minBounds = transform.position + transform.right * waypointWeight / 2;
            maxBounds = transform.position - transform.right * waypointWeight / 2;
        }
    }
}
