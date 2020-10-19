using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public List<GameObject> buttonList = new List<GameObject>();
    public void EnableButtons(GameObject subTower)
    {
        if (!subTower.GetComponent<TowerButton>().localState)
        {
            foreach (GameObject button in buttonList)
            {
                button.GetComponent<TowerButton>().DeactivateSubMenu();
            }
            subTower.GetComponent<TowerButton>().ActivateSubMenu();
        }
        else if (subTower.GetComponent<TowerButton>().localState)
        {
            subTower.GetComponent<TowerButton>().DeactivateSubMenu();
        }
    }
}
