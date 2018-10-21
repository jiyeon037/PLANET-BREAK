﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    bool activate = true;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activate = !activate;
            if (activate)
            {
                GameObject.Find("Quest UI").transform.Find("Canvas").gameObject.SetActive(false);
            }else if (!activate)
            {
                GameObject.Find("Quest UI").transform.Find("Canvas").gameObject.SetActive(true);
            }
            
        }
    }
}