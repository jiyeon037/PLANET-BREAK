using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public GameObject item;
    Transform trans;
    GameObject obj;
    float posX, posY;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
        posX = trans.position.x;
        
        posY = trans.position.y;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine("dropTheItem");

        }

    }

    IEnumerator dropTheItem()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(item, new Vector3(posX, posY), Quaternion.identity);
        Destroy(gameObject);
    }

    public void HurtObject(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
