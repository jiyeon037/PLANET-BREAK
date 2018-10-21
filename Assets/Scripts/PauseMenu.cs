using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool activated = true;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activated = !activated;
            if (activated)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void Resume()
    {
        GameObject.Find("PauseMenuCanvas").transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1f;
        
    }
    void Pause()
    {
        GameObject.Find("PauseMenuCanvas").transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }
}

