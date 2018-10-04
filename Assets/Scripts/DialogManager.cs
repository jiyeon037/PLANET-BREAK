using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive = false;


	// Use this for initialization
	void Start () {
        dBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
	}

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
