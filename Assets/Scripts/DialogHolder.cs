using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    List<string> dString = new List<string>();
    public string dialogue;
    private DialogManager dMan;
    bool cBool;
    int cnt = 0;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogManager>();
        dString.Add("Hello!");
        dString.Add("I'm the owner of this land");
        dString.Add("I saw your spaceship crash");
        dString.Add("If you help me, I'll let you go back to where you lived");
        dString.Add("");
    }

    // Update is called once per frame
    void Update()
    {
        if (cBool)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dMan.ShowBox(dString[cnt]);
                cnt++;

                if (cnt > 4)
                {
                    dMan.dBox.SetActive(false);
                    dMan.dialogActive = false;
                    cnt = 0;
                }

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            cBool = true;

        }
    }

}