using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTower : Tower
{
    [SerializeField]
    GameObject arrow;
    /*[SerializeField]
    Button button;*/

    void Start()
    {
        enemyListManager = GameObject.Find("GameManager").GetComponent<EnemyCreation>();
        //buttonSwitch = GameObject.Find("GameManager").GetComponent<ButtonSwitch>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        StartCoroutine(ShootingEnemy(arrow));
    }
    private void OnDestroy()
    {
        TowerDestruction(1);
    }
}
