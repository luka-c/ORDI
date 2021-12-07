using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) {
        if (currentHealth != 0)
            currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
