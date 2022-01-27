using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    public Transform respawnPoint;

    public Canvas healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pod"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
        
    }

    public void RespawnPlayer()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerHealth playerScript = thePlayer.GetComponent<PlayerHealth>();
        playerScript.currentHealth = 100;
        player.transform.position = respawnPoint.transform.position;

        foreach (Transform child in healthBar.transform)
        {
            if (child.GetComponent<Image>())
            {
                var childImage = child.GetComponent<Image>();
                if (childImage.name.Contains("Srce") && childImage.enabled == false)
                {
                    childImage.enabled = true;
                }
            }

        }
    }
}
