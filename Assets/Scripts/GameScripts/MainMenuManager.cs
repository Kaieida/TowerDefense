﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject difficultyPanel, upgradePanel;
    [SerializeField]
    TowerData arrowTower, fireTower, iceTower;
    [SerializeField]
    TextMeshProUGUI arrowTowerDmg, arrowTowerSpeed, iceTowerDmg, iceTowerSlow, fireTowerDmg, fireTowerDOT;
    [SerializeField]
    UpgradeCoinData upgradeMenuData;
    private void Update()
    {
        arrowTowerDmg.text = arrowTower.attackDamage.ToString();
        arrowTowerSpeed.text = arrowTower.attackSpeed.ToString();
        iceTowerDmg.text = iceTower.attackDamage.ToString();
        iceTowerSlow.text = iceTower.slowMultiplier.ToString();
        fireTowerDmg.text = fireTower.attackDamage.ToString();
        fireTowerDOT.text = fireTower.dotDamage.ToString();

    }
    public void ChooseDifficulty()
    {
        if (difficultyPanel.activeSelf)
        {
            difficultyPanel.SetActive(false);
        }
        else if (!difficultyPanel.activeSelf)
        {
            difficultyPanel.SetActive(true);
        }
    }
    public void UpgradePanel()
    {
        if (upgradePanel.activeSelf)
        {
            upgradePanel.SetActive(false);
        }
        else if (!upgradePanel.activeSelf)
        {
            upgradePanel.SetActive(true);
        }
    }
    public void StartGame(int diffMulti)
    {
        SceneManager.LoadScene(1);
        upgradeMenuData.difficulty = diffMulti;
    }
    public void UpgradeDamage(TowerData towerData)
    {
        if (upgradeMenuData.upgradeCoins >= 10)
        {
            towerData.attackDamage++;
            upgradeMenuData.upgradeCoins -= 10;
        }
        else
        {
            Debug.Log("Not Enough coins");
        }
    }
    public void UpgradeSpecial(TowerData towerData)
    {
        if (upgradeMenuData.upgradeCoins >= 10)
        {
            switch (towerData.name)
            {
                case ("arrowTower"):
                    towerData.attackSpeed -= 0.1f;
                    break;
                case ("iceTower"):
                    towerData.slowMultiplier -= 0.1f;
                    break;
                case ("fireTower"):
                    towerData.dotDamage += 1;
                    break;
            }
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}