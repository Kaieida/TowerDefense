using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public int maxHealth, goldReward, damage;
    public Sprite mobImage;
}
