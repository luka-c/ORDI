using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int LevelToLoad;
    public Collider2D player;
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other == player)
        {
            Debug.Log("collided");
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
