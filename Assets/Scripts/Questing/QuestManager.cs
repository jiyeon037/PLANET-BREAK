using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    //bool activate = true;
    public bool AssignedQuest { get; set; }
    public static QuestManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        AssignedQuest = false;
	}

    // Update is called once per frame
    void Update()
    {/*
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
            
        }*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Quest UI").transform.Find("Canvas").gameObject.SetActive(false);
        }

    }

    public void onGuideButton()
    {

            GameObject.Find("Quest UI").transform.Find("Canvas").gameObject.SetActive(true);     
    }
}
