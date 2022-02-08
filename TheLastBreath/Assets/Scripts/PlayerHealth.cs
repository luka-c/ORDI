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
    private Rigidbody2D rg;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
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
            StartCoroutine(ApplyDamage(collision));
        }
    }

    private IEnumerator ApplyDamage(Collider2D collision) {
        TakeDamage(25);
        Physics2D.IgnoreCollision(collision, GetComponent<PolygonCollider2D>());
        rg.AddForce (new Vector2(0, 15), ForceMode2D.Impulse);
        //rg.AddRelativeForce(-Vector2.left * 100);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(collision, GetComponent<PolygonCollider2D>(), false);
    }
}