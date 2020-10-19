using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int level;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    UpgradeMenu upgradeMenu;
    [SerializeField]
    TextMeshProUGUI coinsEarned, enemiesKilled;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        upgradeMenu = GameObject.Find("UpgradeManager").GetComponent<UpgradeMenu>();
    }
    public void StartNextWave(int level)
    {
        this.level += level;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        upgradeMenu.GameEndRewards(1);
        gameOverPanel.SetActive(true);
        coinsEarned.text = upgradeMenu.coinsForLevel.ToString();
        enemiesKilled.text = upgradeMenu.enemiesKilled.ToString();

    }
}
