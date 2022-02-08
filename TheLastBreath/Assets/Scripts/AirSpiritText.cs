using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirSpiritText : MonoBehaviour
{
    private GameObject player;
    public Text floatingText;
    public Canvas earthSpiritCanvas;
    public UnlockedAbilities unlocked;
    //private GameObject trnje;

    void Start()
    {
        player = GameObject.Find("Player");
        unlocked = GameObject.Find("Abilities").GetComponent<UnlockedAbilities>();
        //trnje = GameObject.Find("trnjeVodopad");
    }
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 20)
        {
            if (ScoreManager.instance.getScore() < 5)
            {
                if (ScoreManager.instance.getScore() == 4)
                {
                    floatingText.text = "Hi, little one! Please collect " + (5 - ScoreManager.instance.getScore()) + " more soul.";
                }
                else
                {
                    floatingText.text = "Hi, little one! Please collect " + (5 - ScoreManager.instance.getScore()) + " more souls.";
                }
            }
            else
            {
                floatingText.text = "As thanks I bestow upon you the ability to dash. Farewell...";
                unlocked.canDash = true;
                SceneManager.LoadScene(1);
            }

            earthSpiritCanvas.gameObject.SetActive(true);
        }
        else
        {
            earthSpiritCanvas.gameObject.SetActive(false);
        }
    }

}
