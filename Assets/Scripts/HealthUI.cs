using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthSprite0;
    [SerializeField] private Image healthSprite1;
    [SerializeField] private Image healthSprite2;
    [SerializeField] private Image healthSprite3;
    [SerializeField] private TextMeshProUGUI healthText;
    private int health;

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        PlayerController.OnTakeDamage += UpdateHealthUI;
    }

    private void OnDisable()
    {
        PlayerController.OnTakeDamage -= UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        health--;
        switch(health)
        {
            case 0:
                healthSprite0.enabled = true;
                healthSprite1.enabled = false;
                healthSprite2.enabled = false;
                healthSprite3.enabled = false;
                break;
            case 1:
                healthSprite0.enabled = false;
                healthSprite1.enabled = true;
                healthSprite2.enabled = false;
                healthSprite3.enabled = false;
                break;
            case 2:
                healthSprite0.enabled = false;
                healthSprite1.enabled = false;
                healthSprite2.enabled = true;
                healthSprite3.enabled = false;
                break;
            case 3:
                healthSprite0.enabled = false;
                healthSprite1.enabled = false;
                healthSprite2.enabled = false;
                healthSprite3.enabled = true;
                break;
        }
        healthText.text = health.ToString();
    }

    private void Initialize()
    {
        health = 3;
        healthSprite0.enabled = false;
        healthSprite1.enabled = false;
        healthSprite2.enabled = false;
        healthSprite3.enabled = true;
    }
}

