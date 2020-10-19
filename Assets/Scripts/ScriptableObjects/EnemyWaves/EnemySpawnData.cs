using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy Spawn Data")]
public class EnemySpawnData : ScriptableObject
{
    public List<GameObject> enemySpawnList;
}
