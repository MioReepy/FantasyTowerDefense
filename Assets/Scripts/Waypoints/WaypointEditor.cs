using UnityEditor;
using UnityEngine;

namespace WaypointSpase
{
    [InitializeOnLoad()]
    public class WaypointEditor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
        
        private static void OnDrawGizmo(Waypoint waypoint, GizmoType gizmoType)
        {
            float waypointRadius = 0.15f;

            if (gizmoType == GizmoType.Selected)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.blue * 0.5f;
            }
            
            Gizmos.DrawSphere(waypoint.transform.position, waypointRadius);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(waypoint.transform.position + waypoint.transform.right * waypoint.weight / 2, 
                waypoint.transform.position - waypoint.transform.right * waypoint.weight / 2);

            if (waypoint.nextWaypoint != null)
            {
                Gizmos.color = Color.cyan;
                Vector3 leftBorder = waypoint.transform.position + waypoint.transform.right * waypoint.weight / 2;
                Vector3 rightBorder = waypoint.transform.position - waypoint.transform.right * waypoint.weight / 2;
                Vector3 leftNextBorder = waypoint.nextWaypoint.transform.position + 
                                         waypoint.nextWaypoint.transform.right * waypoint.nextWaypoint.weight / 2;
                Vector3 rightNextBorder = waypoint.nextWaypoint.transform.position - 
                                          waypoint.nextWaypoint.transform.right * waypoint.nextWaypoint.weight / 2;
                
                Gizmos.DrawLine(leftBorder, leftNextBorder);
                Gizmos.DrawLine(rightBorder, rightNextBorder);
            }
        }
    }
}