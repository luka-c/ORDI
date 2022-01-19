using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSpiritWaterfall : MonoBehaviour
{
    private GameObject player;
    public Text floatingText;
    public Canvas waterSpiritCanvas;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 20)
        {
            if (ScoreManager.instance.getScore() < 7)
            {
                floatingText.text = "We can't proceed with saving the forest if you don't help us collect all souls!";
            }
            else
            {
                floatingText.text = "You have our thanks, small one! For your troubles here is a little tip: Press L-Shift to dash.";
            }

            waterSpiritCanvas.gameObject.SetActive(true);
        }
        else
        {
            waterSpiritCanvas.gameObject.SetActive(false);
        }
    }

}
