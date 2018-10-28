using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{

    public Sprite fullHeart, halfHeart;
    public PlayerHealthManager pHealth;
    public GameObject heart1, heart2, heart3;

    public int curHealth;

    // Use this for initialization
    void Start()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        curHealth = pHealth.playerCurrentHealth;

        if (curHealth >= 25)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            if (curHealth == 30)
            {
                heart3.GetComponent<Image>().sprite = fullHeart;
            }
            else if (curHealth == 25)
            {
                heart3.GetComponent<Image>().sprite = halfHeart;
            }
        }
        else if (curHealth < 25 && curHealth >= 15)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            if (curHealth == 20)
            {
                heart2.GetComponent<Image>().sprite = fullHeart;
            }
            else if (curHealth == 15)
            {
                heart2.GetComponent<Image>().sprite = halfHeart;
            }
        }
        else if (curHealth < 15 && curHealth >= 5)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            if (curHealth == 10)
            {
                heart1.GetComponent<Image>().sprite = fullHeart;
            }
            else if (curHealth == 5)
            {
                heart1.GetComponent<Image>().sprite = halfHeart;
            }
            else
            {
                heart1.SetActive(false);
            }
        }
    }

}