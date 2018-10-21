using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public GameObject masi;
    PlayerHealthManager ph;

    public void RestartButton()
    {
        masi.SetActive(true);
        ph = masi.GetComponent<PlayerHealthManager>();
        ph.playerCurrentHealth = 30;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1f;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
