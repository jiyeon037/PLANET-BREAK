using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public GameObject masi;
    PlayerHealthManager ph;
    public Heart theHeart;

    public void RestartButton()
    {
        masi.SetActive(true);
        ph = masi.GetComponent<PlayerHealthManager>();
        ph.playerCurrentHealth = 30;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;

        theHeart.curHealth = theHeart.pHealth.playerCurrentHealth;

        if (theHeart.curHealth == 30)
        {

            theHeart.heart1.SetActive(true);
            theHeart.heart2.SetActive(true);
            theHeart.heart3.SetActive(true);

            theHeart.heart1.GetComponent<Image>().sprite = theHeart.fullHeart;
            theHeart.heart2.GetComponent<Image>().sprite = theHeart.fullHeart;
            theHeart.heart3.GetComponent<Image>().sprite = theHeart.fullHeart;
        }

    }

    // Use this for initialization
    void Start()
    {
        theHeart = FindObjectOfType<Heart>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
