using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

    SpriteRenderer spriteRenderer;
    CapsuleCollider2D cCol;
    bool isUnbeatTime = false;

	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        cCol = gameObject.GetComponent<CapsuleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void HurtPlayer(int damage)
    {
        playerCurrentHealth -= damage;

        if(playerCurrentHealth > 0)
        {
            isUnbeatTime = true;
            cCol.enabled = false;
            StartCoroutine("UnbeatTime");
        }
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    IEnumerator UnbeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }

        spriteRenderer.color = new Color(255, 255, 255, 255);

        isUnbeatTime = false;
        cCol.enabled = true;

        yield return null;
    }
}
