using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //public HealthBar healthBar;
    public Canvas healthBar;
    private Image childLast;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxhealth(maxHealth);
    }

    void Update()
    {
        //if (Input.GetButtonDown("Jump")) {
        //    TakeDamage(20);
        //}
        if(currentHealth <= 0)
        {
            GameObject thePlayer = GameObject.Find("Player");
            Respawn playerScript = thePlayer.GetComponent<Respawn>();
            playerScript.RespawnPlayer();
        }
    }

    void TakeDamage(int damage) {
        if (currentHealth != 0)
            currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pod"))
        {

            currentHealth = 0;
           //healthBar.SetHealth(currentHealth);
        }

        
        if (collision.gameObject.CompareTag("Damage"))
        {
            TakeDamage(25);
            
            foreach (Transform child in healthBar.transform)
            {
                if (child.GetComponent<Image>())
                {
                    var childImage = child.GetComponent<Image>();
                    if (childImage.name.Contains("Srce") && childImage.enabled == true)
                    {
                        childLast = childImage;
                    }
                }
                
            }

            Debug.Log(childLast.name);
            childLast.enabled = false;
        }
    }
}
