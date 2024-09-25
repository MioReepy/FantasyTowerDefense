using EnemySpace;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/New Wave")]
public class Wave: ScriptableObject
{
    public Enemy[] enemy; 
    public float timeBetweenEnemies = 0.5f;
}