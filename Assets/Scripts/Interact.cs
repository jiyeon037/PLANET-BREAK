using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public virtual void GetInteraction()
    {
        Interacts();
    }
	public virtual void Interacts()
    {
        Debug.Log("Interacting with base class.");
    }
        
}
