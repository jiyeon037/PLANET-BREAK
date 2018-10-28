using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactShipZone : MonoBehaviour {

    public bool CheckZone;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            CheckZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            CheckZone = false;
        }
    }

}
