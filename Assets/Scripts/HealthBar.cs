using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    
    private HealthComponent playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();
        healthBar.maxValue = playerHealth.Health;
    }

    private void Update()
    {
        healthBar.value = playerHealth.Health;
    }
}
