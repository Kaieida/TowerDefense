using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public List<TowerData> towerData = new List<TowerData>();
    [SerializeField]
    private int _health, _goldReward, _damage, i = 0;
    EnemyCreation enemyList;
    GameSystems gameSystems;
    UpgradeMenu upgradeMenu;
    [SerializeField]
    List<GameObject> Points = new List<GameObject>();
    [SerializeField]
    float speed, currentSpeed, distanceBetween = 0.25f;
    [SerializeField]
    GameObject spawnPoint;
    public bool isFrozen, isBurning;
    [SerializeField]
    UpgradeCoinData upgradeCoinData;
    void Start()
    {
        upgradeMenu = GameObject.Find("UpgradeManager").GetComponent<UpgradeMenu>();
        spawnPoint = GameObject.Find("SpawnPoint");
        enemyList = GameObject.Find("GameManager").GetComponent<EnemyCreation>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        for (int i = 0; i < Points.Count; i++)
        {
            Points[i] = GameObject.Find("Point_" + i);
        }
        _health *= upgradeCoinData.difficulty;
        speed *= upgradeCoinData.difficulty;
        currentSpeed = speed;

        StartCoroutine(MovingToPoints());
        StartCoroutine(Aliments());

    }
    public void DamageTaken(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        enemyList.enemyList.Remove(this.gameObject);
        gameSystems.coins += _goldReward;
        upgradeMenu.enemiesKilled++;
        Destroy(this.gameObject);
    }
    IEnumerator Aliments()
    {
        while (true)
        {
            if (isFrozen)
            {
                currentSpeed = speed * towerData[1].slowMultiplier;
                yield return new WaitForSeconds(1f);
                isFrozen = false;
                currentSpeed = speed;
            }
            else if (isBurning)
            {
                DamageTaken(towerData[2].dotDamage);
                yield return new WaitForSeconds(1f);
                i++;
                if (i >= 5)
                {
                    isBurning = false;
                    i = 0;
                }
            }
            yield return null;
        }
    }
    IEnumerator MovingToPoints()
    {
        int targetPoint = 0;
        while (true)
        {
            if (Vector3.Distance(Points[targetPoint].transform.position, transform.position) < distanceBetween)
            {
                targetPoint++;
                if (targetPoint == Points.Count)
                {
                    targetPoint = 0;
                    gameSystems.Health -= _damage;
                    transform.position = spawnPoint.transform.position;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, Points[targetPoint].transform.position, currentSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
