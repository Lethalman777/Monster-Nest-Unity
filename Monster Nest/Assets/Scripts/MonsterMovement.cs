using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public bool isAttacking = false;
    public bool isBlocking = false;
    public bool isHurt = false;
    public bool isDeath = false;
    float interval = 0;
    bool canWalk;
    Animator animator;
    GameManager gameManager;
    Vector2 movement;
    Rigidbody2D rb;
    BoxCollider2D colliderBox;
    
    
    float moveSpeed = 100f;

    public float xAxis; 
    public float playerXAxis;
    // Start is called before the first frame update
    void Start()
    {
        //canWalk = true;
        //int j = UnityEngine.Random.Range(0, 7);
        //switch (j)
        //{
        //    case 0:
        //        movement = new Vector2(1, 0);
        //        break;
        //    case 1:
        //        movement = new Vector2(-1, 0);
        //        break;
        //    case 2:
        //        movement = new Vector2(0, 1);
        //        break;
        //    case 3:
        //        movement = new Vector2(0, -1);
        //        break;
        //    case 4:
        //        movement = new Vector2(1, -1);
        //        break;
        //    case 5:
        //        movement = new Vector2(-1, -1);
        //        break;
        //    case 6:
        //        movement = new Vector2(1, 1);
        //        break;
        //    case 7:
        //        movement = new Vector2(-1, 1);
        //        break;
        //}
        moveSpeed = 100f;
        isAttacking = false;
        isBlocking = false;
        isHurt = false;
        isDeath = false;
        animator = GetComponent<Animator>();  
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        colliderBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per fra
    void Update()
    {
        xAxis = gameObject.transform.localPosition.x;
        interval += Time.deltaTime; 
        if (gameManager.isGamePause)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRight", false);
            /*if (gameManager.isFight && xAxis > enemyXAxis)
            animator.SetBool("isIdle", false);
            else
                animator.SetBool("isIdle", true);*/
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRight", false);
        }
        //else
        //{
        //    if(interval > 10)
        //    {
        //        if (!canWalk)
        //        {
        //            int j = UnityEngine.Random.Range(0, 7);
        //            switch (j)
        //            {
        //                case 0:
        //                    movement = new Vector2(1, 0);
        //                    break;
        //                case 1:
        //                    movement = new Vector2(-1, 0);
        //                    break;
        //                case 2:
        //                    movement = new Vector2(0, 1);
        //                    break;
        //                case 3:
        //                    movement = new Vector2(0, -1);
        //                    break;
        //                case 4:
        //                    movement = new Vector2(1, -1);
        //                    break;
        //                case 5:
        //                    movement = new Vector2(-1, -1);
        //                    break;
        //                case 6:
        //                    movement = new Vector2(1, 1);
        //                    break;
        //                case 7:
        //                    movement = new Vector2(-1, 1);
        //                    break;
        //            }
        //        }
        //        //else
        //        //{
        //        //    movement = new Vector2(-movement.x, -movement.y);
        //        //    canWalk = true;
        //        //}
        //        interval = 0;
        //    }
        //    //RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, moveSpeed * Time.fixedDeltaTime);
        //    //if (hit.collider == null)
        //    //{
        //        if (movement.x < 0)
        //        {
        //            animator.SetBool("isRight", false);
        //            animator.SetBool("isMoving", true);
        //        }
        //        else
        //        {
        //            animator.SetBool("isRight", true);
        //            animator.SetBool("isMoving", true);
        //        }
            
        //    //RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, moveSpeed *2* Time.deltaTime);
        //    //if (hit.collider != null)
        //    //{
        //    //    movement = new Vector2(-movement.x, -movement.y);
        //    //}
        //    //if(Physics2D.)
        //    //    rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
            
        //    //rb.position = Vector2.MoveTowards(rb.position, movement, moveSpeed * Time.deltaTime);
            
            
        //    //}
        //    /*else if (movement.y == 1 && canWalk)
        //    {
        //        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //        animator.SetBool("isMoving", true);
        //        animator.SetBool("isRight", true);
        //    }*/
        //    //else
        //    //{
        //    //    animator.SetBool("isMoving", false);
        //    //    animator.SetBool("isRight", false);
        //    //    movement = new Vector2(-movement.x, -movement.y);
        //    //}
        //}
        if (isAttacking)
        {
            if (xAxis > playerXAxis)
            {
                animator.SetBool("isAttack", true);
                animator.SetBool("isRight", false);
            }
            else
            {
                animator.SetBool("isAttack", true);
                animator.SetBool("isRight", true);
            }
            isAttacking=false;
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
        if(isBlocking)
        {
            if (xAxis > playerXAxis)
            {
                Debug.Log("ewe");
                animator.SetBool("isBlock", true);
                animator.SetBool("isRight", false);
            }
            else
            {
                Debug.Log("tyt");
                animator.SetBool("isBlock", true);
                animator.SetBool("isRight", true);
            }
            isBlocking = false;
        }
        else
        {
            animator.SetBool("isBlock", false);
        }
        if(isHurt)
        {
            if (xAxis > playerXAxis)
            {
                Debug.Log("ewe");
                animator.SetBool("isHurt", true);
                animator.SetBool("isRight", false);
            }
            else
            {
                Debug.Log("tyt");
                animator.SetBool("isHurt", true);
                animator.SetBool("isRight", true);
            }
            isHurt = false;
        }
        else
        {
            animator.SetBool("isHurt", false);
        }
        if (isDeath)
        {
            if (xAxis > playerXAxis)
            {
                animator.SetBool("isDeath", true);
                animator.SetBool("isDeath", false);
            }
            else
            {
                animator.SetBool("isDeath", true);
                animator.SetBool("isRight", true);
            }
            isDeath = false;
        }
        else
        {
            animator.SetBool("isDeath", false);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("wtw");
    //    movement = new Vector2(movement.x, movement.y);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    canWalk = false;
    //    Debug.Log("jkj");
    //}
}
