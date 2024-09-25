using UnityEditor;
using UnityEngine;

namespace WaveSpawnerSpace
{
    [InitializeOnLoad()]
    public class WaveSpawnerEditor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        public static void OnDrawGizmos(WaveSpawner waveSpawner, GizmoType gizmoType)
        {
            float WaveSpawnerRadius = 1f;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(waveSpawner.transform.position, WaveSpawnerRadius);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(waveSpawner.transform.position + Vector3.right * waveSpawner._waveSpawnerWidth / 2,
                waveSpawner.transform.position - Vector3.right * waveSpawner._waveSpawnerWidth / 2);
        }
    }
}