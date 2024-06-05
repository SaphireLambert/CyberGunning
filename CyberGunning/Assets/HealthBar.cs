using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    Damageable playerDamageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDamageable = player.GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = HealthBarPercentage(playerDamageable.CurrentHealth, playerDamageable.MaxHealth);
    }

    private float HealthBarPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
