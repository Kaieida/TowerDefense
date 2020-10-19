using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    public GameObject spawnPoint;
    public List<GameObject> enemyList = new List<GameObject>();
    public List<EnemySpawnData> enemyWaves = new List<EnemySpawnData>();
    Transform canvas;
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameSystems gameSystems;
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawnSystem()
    {
        GameObject enemyCreation;
        foreach (GameObject enemy in enemyWaves[gameController.level].enemySpawnList)
        {
            enemyCreation = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity, canvas);
            enemyList.Add(enemyCreation);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(20f);
        gameController.StartNextWave(1);
    }
    IEnumerator EnemySpawn()
    {
        while (true)
        {
            if (gameSystems.Health > 0)
            {
                yield return StartCoroutine(EnemySpawnSystem());
            }
            else
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    Destroy(enemyList[i]);
                }
                break;
            }
        }
    }
}
