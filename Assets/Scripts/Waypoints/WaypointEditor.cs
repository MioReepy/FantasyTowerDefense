using UnityEditor;
using UnityEngine;

namespace WaypointSpase
{
    // public class WaypointEditor
    // {
    //     [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    //     
    //     private static void OnDrawGizmo(Waypoint waypoint, GizmoType gizmoType)
    //     {
    //         float waypointRadius = 0.5f;
    //
    //         if ((gizmoType & GizmoType.Selected) != 0)
    //         {
    //             Gizmos.color = Color.magenta;
    //         }
    //         else
    //         {
    //             Gizmos.color = Color.grey;
    //         }
    //         
    //         Gizmos.DrawSphere(waypoint.transform.position, waypointRadius);
    //         Gizmos.color = Color.white;
    //         Gizmos.DrawLine(waypoint.transform.position + waypoint.transform.right * waypoint.waypointWeight / 2, 
    //             waypoint.transform.position - waypoint.transform.right * waypoint.waypointWeight / 2);
    //
    //         if (waypoint.nextWaypoint != null)
    //         {
    //             Gizmos.color = Color.cyan * 0.5f;
    //             Vector3 leftBorder = waypoint.transform.position + waypoint.transform.right * waypoint.waypointWeight / 2;
    //             Vector3 rightBorder = waypoint.transform.position - waypoint.transform.right * waypoint.waypointWeight / 2;
    //             Vector3 leftNextBorder = waypoint.nextWaypoint.transform.position + 
    //                                      waypoint.nextWaypoint.transform.right * waypoint.nextWaypoint.waypointWeight / 2;
    //             Vector3 rightNextBorder = waypoint.nextWaypoint.transform.position - 
    //                                       waypoint.nextWaypoint.transform.right * waypoint.nextWaypoint.waypointWeight / 2;
    //             
    //             Gizmos.DrawLine(leftBorder, leftNextBorder);
    //             Gizmos.DrawLine(rightBorder, rightNextBorder);
    //         }
    //     }
    // }
}