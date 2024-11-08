using UnityEditor;
using UnityEngine;

namespace WaypointSpase
{
    // public class WaypointManagerWindow : EditorWindow
    // {
    //     [MenuItem("Tools/Waypoint Editor")]
    //     public static void Open()
    //     {
    //         GetWindow<WaypointManagerWindow>();
    //     }
    //     
    //     public Transform waypointRoot;
    //     private float _waypointDistance = 5f;
    //
    //     private void OnGUI()
    //     {
    //         SerializedObject serializedObject = new SerializedObject(this);
    //         EditorGUILayout.PropertyField(serializedObject.FindProperty("waypointRoot"));
    //
    //         if (waypointRoot == null)
    //         {
    //             EditorGUILayout.HelpBox("Root transform must be selected. Please, assign a root transform", MessageType.Warning);
    //         }
    //         else
    //         {
    //             EditorGUILayout.BeginVertical("box");
    //             DrawButton();
    //             EditorGUILayout.EndVertical();
    //         }
    //         
    //         serializedObject.ApplyModifiedProperties();
    //     }
    //
    //     private void DrawButton()
    //     {
    //         if (waypointRoot.childCount == 0)
    //         {
    //             if (GUILayout.Button("Add Waypoint"))
    //             {
    //                 CreateWaypointAfter();
    //             }
    //         }
    //         else
    //         {
    //             if (GUILayout.Button("Add Waypoint After"))
    //             {
    //                 CreateWaypointAfter();
    //             }
    //             if (GUILayout.Button("Add Waypoint Before"))
    //             {
    //                 CreateWaypointBefore();
    //             }
    //             if (GUILayout.Button("Remove Waipoint"))
    //             {
    //                 RemoveWaypoint();
    //             }
    //         }
    //     }
    //
    //     private void CreateWaypointAfter()
    //     {
    //         GameObject waypointObject = new GameObject("Waypoint_" + (waypointRoot.childCount + 1), typeof(Waypoint));
    //         waypointObject.transform.SetParent(waypointRoot, false);
    //         Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
    //
    //         if (Selection.activeGameObject.GetComponent<Waypoint>())
    //         {
    //             Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
    //             waypointObject.transform.forward = selectedWaypoint.transform.forward;
    //             waypointObject.transform.position = selectedWaypoint.transform.position + selectedWaypoint.transform.forward * _waypointDistance;
    //
    //             if (selectedWaypoint.nextWaypoint != null)
    //             {
    //                 newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
    //                 selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint;
    //             }
    //
    //             newWaypoint.previousWaypoint = selectedWaypoint;
    //             selectedWaypoint.nextWaypoint = newWaypoint;
    //
    //             newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex() + 1);
    //
    //             for (int i = newWaypoint.transform.GetSiblingIndex(); i < waypointRoot.childCount; i++)
    //             {
    //                 waypointRoot.transform.GetChild(i).name = "Waypoint_" + (i + 1);
    //             }
    //         }
    //
    //         Selection.activeGameObject = newWaypoint.gameObject;
    //     }
    //
    //     private void CreateWaypointBefore()
    //     {
    //         GameObject waypointObject = new GameObject("Waypoint_" + (waypointRoot.childCount + 1), typeof(Waypoint));
    //         waypointObject.transform.SetParent(waypointRoot, false);
    //         Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
    //
    //         if (Selection.activeGameObject.GetComponent<Waypoint>())
    //         {
    //             Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
    //             waypointObject.transform.forward = selectedWaypoint.transform.forward;
    //             waypointObject.transform.position = selectedWaypoint.transform.position - selectedWaypoint.transform.forward * _waypointDistance / 2;
    //
    //             if (selectedWaypoint.previousWaypoint != null)
    //             {
    //                 newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
    //                 selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
    //             }
    //
    //             newWaypoint.nextWaypoint = selectedWaypoint;
    //             selectedWaypoint.previousWaypoint = newWaypoint;
    //
    //             newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
    //
    //             for (int i = newWaypoint.transform.GetSiblingIndex(); i < waypointRoot.childCount; i++)
    //             {
    //                 waypointRoot.transform.GetChild(i).name = "Waypoint_" + (i + 1);
    //             }
    //         }
    //
    //         Selection.activeGameObject = newWaypoint.gameObject;
    //     }
    //
    //     private void RemoveWaypoint()
    //     {
    //         Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
    //
    //         if (selectedWaypoint.nextWaypoint != null)
    //         {
    //             selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
    //         }
    //
    //         if (selectedWaypoint.previousWaypoint != null)
    //         {
    //             selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
    //         }
    //         
    //         for (int i = selectedWaypoint.transform.GetSiblingIndex(); i < waypointRoot.childCount; i++)
    //         {
    //             selectedWaypoint.transform.SetSiblingIndex(waypointRoot.transform.childCount - 1);
    //             waypointRoot.transform.GetChild(i).name = "Waypoint_" + (i + 1);
    //         }
    //         
    //         DestroyImmediate(selectedWaypoint.gameObject);
    //     }
    // }
}