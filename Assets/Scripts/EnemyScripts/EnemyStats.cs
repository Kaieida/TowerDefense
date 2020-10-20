﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    UpgradeCoinData upgradeCoinData;
    [SerializeField]
    List<GameObject> Points = new List<GameObject>();
    [SerializeField]
    EnemyData enemyData;
    public List<TowerData> towerData = new List<TowerData>();
    EnemyCreation enemyList;
    GameSystems gameSystems;
    UpgradeMenu upgradeMenu;
    GameObject spawnPoint;
    float _currentSpeed;
    [HideInInspector]
    public bool isFrozen, isBurning;
    private int _health, i = 0;
    private Slider slider;
    private Image mobImage;
    private TextMeshProUGUI mobName, healthText;
    private bool changeMob;
    void Start()
    {
        upgradeMenu = GameObject.Find("UpgradeManager").GetComponent<UpgradeMenu>();
        enemyList = GameObject.Find("GameManager").GetComponent<EnemyCreation>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        slider = GameObject.Find("health").GetComponent<Slider>();
        mobImage = GameObject.Find("MobImage").GetComponent<Image>();
        mobName = GameObject.Find("MobName").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("healthIndicator").GetComponent<TextMeshProUGUI>();
        spawnPoint = GameObject.Find("SpawnPoint");
        for (int i = 0; i < Points.Count; i++)
        {
            Points[i] = GameObject.Find("Point_" + i);
        }
        _currentSpeed = enemyData.speed * upgradeCoinData.difficulty;
        _health = enemyData.maxHealth * upgradeCoinData.difficulty;
        gameObject.GetComponent<Image>().sprite = enemyData.mobImage;
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
        gameSystems.coins += enemyData.goldReward;
        upgradeMenu.enemiesKilled++;
        Destroy(this.gameObject);
    }
    IEnumerator Aliments()
    {
        while (true)
        {
            if (isFrozen)
            {
                _currentSpeed = (enemyData.speed * upgradeCoinData.difficulty) * towerData[1].slowMultiplier;
                yield return new WaitForSeconds(1f);
                isFrozen = false;
                _currentSpeed = (enemyData.speed * upgradeCoinData.difficulty);
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
            if (Vector3.Distance(Points[targetPoint].transform.position, transform.position) < 0.25f)
            {
                targetPoint++;
                if (targetPoint == Points.Count)
                {
                    targetPoint = 0;
                    gameSystems.Health -= enemyData.damage;
                    transform.position = spawnPoint.transform.position;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, Points[targetPoint].transform.position, _currentSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void UpdateInfo()
    {
        StartCoroutine(HPUpdate());
    }
    IEnumerator HPUpdate()
    {
        float t = 0;
        while(t < 0.1)
        {
            t += Time.deltaTime;
            mobImage.sprite = enemyData.mobImage;
            mobName.text = enemyData.enemyName;
            slider.maxValue = enemyData.maxHealth;
            slider.value = _health;
            healthText.text = $"{_health}/{enemyData.maxHealth}";
            yield return null;
        }
        yield return null;
    }
}
