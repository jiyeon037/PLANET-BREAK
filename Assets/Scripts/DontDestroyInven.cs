using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyInven : MonoBehaviour
{

    private static bool playerExists;

    // Use this for initialization
    void Start()
    {

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
