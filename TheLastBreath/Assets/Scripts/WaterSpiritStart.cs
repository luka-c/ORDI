using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSpiritStart : MonoBehaviour
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
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 15)
        {
            waterSpiritCanvas.gameObject.SetActive(true);
        }
        else
        {
            waterSpiritCanvas.gameObject.SetActive(false);
        }
    }

}
