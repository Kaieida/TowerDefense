using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField]
    GameObject fireball;
    void Start()
    {
        enemyListManager = GameObject.Find("GameManager").GetComponent<EnemyCreation>();
        //buttonSwitch = GameObject.Find("GameManager").GetComponent<ButtonSwitch>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        StartCoroutine(ShootingEnemy(fireball));
    }
    private void OnDestroy()
    {
        TowerDestruction(1);
    }
}
