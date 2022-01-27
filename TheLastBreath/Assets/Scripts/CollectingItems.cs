using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingItems : MonoBehaviour
{
    public int itemValue = 1;
    public Canvas healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("Collected");
            ScoreManager.instance.ChangeScore(itemValue);
            Destroy(collision.gameObject);

            GameObject thePlayer = GameObject.Find("Player");
            PlayerHealth playerScript = thePlayer.GetComponent<PlayerHealth>();
            if (playerScript.currentHealth < 100)
            {
                playerScript.currentHealth += 25;
            }

            foreach (Transform child in healthBar.transform)
            {
                if (child.GetComponent<Image>())
                {
                    var childImage = child.GetComponent<Image>();
                    if (childImage.name.Contains("Srce") && childImage.enabled == false)
                    {
                        childImage.enabled = true;
                        break;
                    }
                }

            }
        }
    }
}