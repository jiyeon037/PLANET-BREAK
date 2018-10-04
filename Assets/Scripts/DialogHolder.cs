using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogManager dMan;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                dMan.ShowBox(dialogue);
            }
        }
    }
}