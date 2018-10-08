using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    protected Animator animator;
    private float directionX = 0;
    private float directionY = 0;
    private bool walking = false;
    public float speed = 5f;
    private static bool playerExists;
    public Vector2 lastMove;
    PolygonCollider2D pc;
    GameObject stick;

    public bool playerMove;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    void Start()
    {
        playerMove = true;
        stick = transform.GetChild(0).gameObject;
        pc = gameObject.GetComponentInChildren<PolygonCollider2D>();
        animator = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        
        if (!attacking && playerMove)
        {
            if (true)
            {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                walking = true;
                if (h > 0)
                {
                    directionX = 1;
                    directionY = 0;
                }
                else if (h < 0)
                {
                    directionX = -1;
                    directionY = 0;
                }
                else if (v > 0)
                {
                    directionX = 0;
                    directionY = 1;
                }
                else if (v < 0)
                {
                    directionX = 0;
                    directionY = -1;
                }
                else
                {
                    walking = false;
                }
                if (walking)
                {
                    transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * speed);
                    pc.enabled = false;
                }
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    animator.SetBool("Hit", true);
                    pc.enabled = true;
                }
                animator.SetFloat("DirectionX", directionX);
                animator.SetFloat("DirectionY", directionY);
                animator.SetBool("Walking", walking);
            }           
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            animator.SetBool("Hit", false);
        }
    }
   
}
