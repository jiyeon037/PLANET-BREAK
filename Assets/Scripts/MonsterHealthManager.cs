using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public GameObject item;
    Transform trans;
    GameObject obj;
    //Animator animator;

    // Use this for initialization
    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
           /* animator.SetBool("isDie", true);
            animator.SetBool("isStop", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isRoll", false);*/
            StartCoroutine("dropTheItem");
            
        }

    }

    IEnumerator dropTheItem()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(item, trans.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void HurtMonster(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
