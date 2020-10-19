﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    [SerializeField]
    GameObject iceball;
    void Start()
    {
        enemyListManager = GameObject.Find("GameManager").GetComponent<EnemyCreation>();
        //buttonSwitch = GameObject.Find("GameManager").GetComponent<ButtonSwitch>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        StartCoroutine(ShootingEnemy(iceball));
    }
    private void OnDestroy()
    {
        TowerDestruction(1);
    }
}