using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystems : MonoBehaviour
{
    int startingCoins, maxHealth, _health;
    public int coins;
    public bool isGameOver = false;
    GameController gameController;
    [SerializeField]
    TextMeshProUGUI coinText, healthText;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0 && !isGameOver)
            {
                isGameOver = true;
                gameController.GameOver();
            }
        }
    }
    void Awake()
    {
        startingCoins = 5;
        coins = startingCoins;
        maxHealth = 10;
        _health = maxHealth;
    }
    void Update()
    {
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        coinText.text = coins.ToString();
        healthText.text = Health.ToString();
    }
}
