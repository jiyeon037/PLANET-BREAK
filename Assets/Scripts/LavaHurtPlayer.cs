using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaHurtPlayer : MonoBehaviour {
    public int damageToGive;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);

        }
    }
 

}
