using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeControl : MonoBehaviour {

    public float movePower = 1f;

    Animator animator;
    Vector3 movement;
    int movementFlag = 0;   //0:Idle, 1:Left, 2:Right

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        Move();
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 5);

        if (movementFlag == 0)
        {
            animator.SetBool("isRoll", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isStop", true);
        }
        else if(movementFlag == 1 || movementFlag == 2)
        {
            animator.SetBool("isRoll", false);
            animator.SetBool("isJump", true);
            animator.SetBool("isStop", false);
        }
        else if (movementFlag == 3 || movementFlag == 4)
        {
            animator.SetBool("isRoll", true);
            animator.SetBool("isJump", false);
            animator.SetBool("isStop", false);
        }


        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMovement");
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1 || movementFlag == 3)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2 || movementFlag == 4)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}
