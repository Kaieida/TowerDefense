using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    Transform canvas;
    [SerializeField]
    GameObject subTowerMenu;
    GameSystems gameSystems;
    public bool localState;
    private GameObject tempObj;
    TowerMenu towerMenu;
    [SerializeField]
    private int towerCost = 0;
    private void Start()
    {
        towerMenu = GameObject.Find("TowerManager").GetComponent<TowerMenu>();
        gameSystems = GameObject.Find("GameManager").GetComponent<GameSystems>();
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        towerMenu.buttonList.Add(gameObject);
        gameObject.GetComponent<Button>().onClick.AddListener(TowerMenuSwitch);
    }
    public void TowerMenuSwitch()
    {
        towerMenu.EnableButtons(gameObject);
    }
    public void ActivateSubMenu()
    {
        subTowerMenu.SetActive(true);
        localState = true;
    }
    public void DeactivateSubMenu()
    {
        subTowerMenu.SetActive(false);
        localState = false;
    }
    public void BuildTower(GameObject tower)
    {
        if (tower.GetComponent<TowerButton>().towerCost <= gameSystems.coins)
        {
            gameSystems.coins -= tower.GetComponent<TowerButton>().towerCost;
            Debug.Log(gameSystems.coins);
            tempObj = Instantiate(tower, transform.position, Quaternion.identity, canvas);
            tempObj.transform.SetAsFirstSibling();
            //moneySystem.coins -= towerCost;
            TowerDestruction();
        }
        else if (tower.GetComponent<TowerButton>().towerCost >= gameSystems.coins)
        {
            Debug.Log("Not enough coins");
        }

    }
    void TowerDestruction()
    {
        towerMenu.buttonList.Remove(gameObject);
        Destroy(gameObject);
    }
}
