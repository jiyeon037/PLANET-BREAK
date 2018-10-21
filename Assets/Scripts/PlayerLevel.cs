using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CombatEvents.OnEnemyDeath += EnemyEx;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyEx(IEnemy enemy)
    {
        GrantExperience();
    }
    public void GrantExperience()
    {

    }
}
