using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interact {
    public string[] dialogue;
    public string name;

    public bool questStart { get; set; }

    public override void Interacts()
    {
        if (!questStart)
        {
            questStart = true;
        }

        DialogHolder.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC.");
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            DialogHolder.Instance.MasiIn();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            DialogHolder.Instance.MasiOut();

        }
    }*/
}
