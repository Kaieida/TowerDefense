using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MobInfo : MonoBehaviour
{
    [HideInInspector]
    public int maxHealth, currentHealth;
    [HideInInspector]
    public string mobName;
    [HideInInspector]
    public Sprite mobImage;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textName, textHealth;
    [SerializeField]
    private Image imageForMob;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        textName.text = mobName;
        imageForMob.sprite = mobImage;
        textHealth.text = $"{currentHealth}/{maxHealth}";

    }
}
