using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSpiritText : MonoBehaviour
{
    private GameObject player;
    public Text floatingText;
    public Canvas waterSpiritCanvas;
    private GameObject trnje;

    void Start()
    {
        player = GameObject.Find("Player");
        trnje = GameObject.Find("trnjeVodopad");
    }
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 20)
        {
            if (ScoreManager.instance.getScore() < 5)
            {
                if (ScoreManager.instance.getScore() == 4)
                {
                    floatingText.text = "Hi, little one! Please collect " + (5 - ScoreManager.instance.getScore()) + " more water soul and we will be able to get rid of the thorns.";
                } else
                {
                    floatingText.text = "Hi, little one! Please collect " + (5 - ScoreManager.instance.getScore()) + " more water souls and we will be able to get rid of the thorns.";
                }
            } else {
                floatingText.text = "Be careful and watch out for waves! You don't look like the best swimmer...";
                trnje.SetActive(false);
            }
             
            waterSpiritCanvas.gameObject.SetActive(true);
        } else
        {
            waterSpiritCanvas.gameObject.SetActive(false);
        }
    }
    
}
