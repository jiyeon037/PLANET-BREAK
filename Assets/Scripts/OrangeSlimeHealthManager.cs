using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSlimeHealthManager : MonoBehaviour, IEnemy{

    public int maxHealth;
    public int currentHealth;
    public GameObject item;
    Transform trans;
    GameObject obj;
    public int ID { get; set; }

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        ID = 0;
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator dropTheItem()
    {
        yield return new WaitForSeconds(0.3f);
        int rand = Random.Range(0, 100);
        Debug.Log("random number : " + rand);
        if(rand < 70)
        {
            Instantiate(item, trans.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    public void HurtMonster(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartCoroutine("dropTheItem");
            Die();
        }

    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        Debug.Log("Slime Died");
    }
}

