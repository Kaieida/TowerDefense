using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    protected TowerData towerData;
    protected GameObject target;
    protected EnemyStats enemyStats;
    protected EnemyCreation enemyListManager;
    protected GameSystems gameSystems;
    private GameObject projectile;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5);
    }
    public void TowerDestruction(int refundCost)
    {
        gameSystems.coins += refundCost;
    }
    protected void ProjectileCreation(GameObject projectileType, GameObject attackingEnemy)
    {
        Quaternion enemyQuaternion = attackingEnemy.transform.rotation;
        enemyStats = attackingEnemy.GetComponent<EnemyStats>();
        projectile = Instantiate(projectileType, transform.position, enemyQuaternion);
        projectile.GetComponent<Projectile>().targetEnemy = enemyStats;
        projectile.GetComponent<Projectile>().projectileName = projectileType.name;
    }
    public IEnumerator ShootingEnemy(GameObject projectileType)
    {
        while (true)
        {
            float temp = 10;
            foreach (GameObject obj in enemyListManager.enemyList)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (temp > distance)
                {
                    temp = distance;
                    target = obj;
                }
            }
            if (temp < 5)
            {
                ProjectileCreation(projectileType, target);
            }
            yield return new WaitForSeconds(towerData.attackSpeed);
        }
    }
}
