using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public EnemyStats targetEnemy;
    public string projectileName;
    public List<TowerData> towerData = new List<TowerData>();
    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
        }
        else if (Vector2.Distance(transform.position, targetEnemy.transform.position) < 0.1f)
        {
            switch (gameObject.name)
            {
                case "Arrow(Clone)":
                    targetEnemy.DamageTaken(towerData[0].attackDamage);
                    break;
                case "Fireball(Clone)":
                    targetEnemy.DamageTaken(towerData[2].attackDamage);
                    targetEnemy.isBurning = true;
                    break;
                case "Iceball(Clone)":
                    targetEnemy.DamageTaken(towerData[1].attackDamage);
                    Debug.Log("target reached");
                    targetEnemy.isFrozen = true;
                    break;
            }
            Destroy(gameObject);
        }
        else
        {
            transform.right = targetEnemy.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, 10 * Time.deltaTime);
        }
    }
}
