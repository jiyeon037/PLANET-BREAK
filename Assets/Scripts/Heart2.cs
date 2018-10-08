using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart2 : MonoBehaviour {

    public Sprite fullHeart, halfHeart;
    public PlayerHealthManager pHealth;

    int curHealth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curHealth = pHealth.playerCurrentHealth;

        if (curHealth == 20)
        {
            gameObject.GetComponent<Image>().sprite = fullHeart;
        }
        else if (curHealth == 15)
        {
            gameObject.GetComponent<Image>().sprite = halfHeart;
        }
        else if (curHealth < 15)
        {
            Destroy(gameObject);
        }
    }
}
