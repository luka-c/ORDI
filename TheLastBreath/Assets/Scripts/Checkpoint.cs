using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public GameObject respawnPoint;

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
        GameObject thePlayer = GameObject.Find("Player");
        Respawn playerScript = thePlayer.GetComponent<Respawn>();
        playerScript.respawnPoint.transform.position = respawnPoint.transform.position;
    }
}
