using UnityEditor;
using UnityEngine;

namespace TowerSpace
{
    [InitializeOnLoad]
    [CustomEditor(typeof(TowerFieldOfView))]
    public class TowerFieldOfViewEditor : Editor
    {
        private void OnSceneGUI()
        {
            TowerFieldOfView towerFieldOfView = (TowerFieldOfView)target;
            Handles.color = Color.green;
            
            Handles.DrawWireArc(towerFieldOfView.transform.position, Vector3.up, Vector3.forward, 360, towerFieldOfView.viewRadius);
            
            Handles.color = Color.grey;

            if (towerFieldOfView.visibleTarget != null)
            {
                foreach (var visibleTarget in towerFieldOfView.visibleTarget)
                {
                    if (visibleTarget == towerFieldOfView.visibleTarget[0])
                    {
                        Handles.color = Color.red;
                    }
                    else
                    {
                        Handles.color = Color.grey;
                    }
                    Handles.DrawLine(towerFieldOfView.transform.position, visibleTarget.position, 1.5f);
                }   
            }
        }
    }
}