using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemainControl : MonoBehaviour {
    public GameObject npcMon;
    public GameObject npcCat;
    public GameObject spaceShip;
    GameObject singleNote;
    GameObject fire;

    public static RemainControl instance = null;
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

        
	}
	
	// Update is called once per frame
	void Update () {
        if(singleNote == null)
        {
            singleNote = GameObject.Find("Single Note Strip(Clone)");
        }
        if(fire == null)
        {
            fire = GameObject.Find("CampFire(Clone)");
        }
        
        if (SceneManager.GetActiveScene().name == "main")
        {
            npcMon.SetActive(true);
            npcCat.SetActive(true);
            spaceShip.SetActive(true);
            if(singleNote != null)
            {
                singleNote.SetActive(true);
            }
            if(fire != null)
            {
                fire.SetActive(true);
            }
           
        }
        else
        {
            npcMon.SetActive(false);
            npcCat.SetActive(false);
            spaceShip.SetActive(false);
//            singleNote.SetActive(false);
//            fire.SetActive(false);
        }

}
}
