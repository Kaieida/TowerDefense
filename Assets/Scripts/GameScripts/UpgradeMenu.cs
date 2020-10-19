using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    UpgradeCoinData upgradeCoinData;
    public int enemiesKilled;
    public int coinsForLevel;
    void Start()
    {
        enemiesKilled = 0;
        coinsForLevel = 0;
    }
    public void GameEndRewards(int difficulty)
    {
        coinsForLevel += (enemiesKilled / 10) * difficulty;
        upgradeCoinData.upgradeCoins = coinsForLevel;
    }
}
