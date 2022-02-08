using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedAbilities : MonoBehaviour
{
    public bool canWallJump;
    public bool canDash;
    private GameObject[] abilities;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnLevelWasLoaded()
    {
        abilities = GameObject.FindGameObjectsWithTag("Abilities");
        Debug.Log(abilities);
        if (abilities.Length > 1)
        {
            Destroy(abilities[1]);
        }
    }
    
}
