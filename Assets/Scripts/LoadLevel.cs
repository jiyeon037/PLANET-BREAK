using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;
    public float posX=10.0f, posY=10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            collision.transform.position = new Vector3(posX, posY, 0);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}