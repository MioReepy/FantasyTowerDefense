using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/WaveSpawner")]
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
}