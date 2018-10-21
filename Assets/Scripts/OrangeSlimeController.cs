using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSlimeController : MonoBehaviour{
    public float movePower = 1f;

    MonsterHealthManager mHealth;
    Animator animator;
    Vector3 movement;
    Vector3 moveVelocity = Vector3.zero;

    int movementFlag = 0;   //0:Idle, 1:Left, 2:Right
    int cHealth;
    public int ID { get; set; }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        //ID = 0;
        mHealth = gameObject.GetComponent<MonsterHealthManager>();
        

        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        Move();
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
            animator.SetBool("isMoving", true);

        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMovement");
    }

    void Move()
    {
        

        if(movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    /*
    public void Die()
    {
        CombatEvents.EnemyDied(this);
        Debug.Log("Slime Died");
    }
    */
}
