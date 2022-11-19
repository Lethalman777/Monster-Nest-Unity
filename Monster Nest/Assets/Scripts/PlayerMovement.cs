using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isFightPanel = false;
    public bool isAttacking = false;
    public bool isBlocking = false;
    public bool isDeath = false;
    public bool isHurt = false;
    public float xAxis;
    public float enemyXAxis;

    public Equipment equipment;
    public GameObject panel;
    public GameObject EquipmentCanvas;
    public GameObject CanvasSource;
    public GameObject canvas;
    public GameObject MenuCanvas;
    public GameObject GameManager;
    public GameObject Treasures;
    GameManager gameManager;
    Rigidbody2D rb;
    Collider2D collider;
    Collider2D other;
    Vector2 movement;
    Animator animator;
    bool canWalk = true;
    PlayerStat hero;
    public GameObject CanvasEnd;
    Vector2 falseMovement;
    /*private void Awake()
    {
        canvas.SetActive(false);
        gameManager = GameManager.GetComponent<GameManager>();
        movement = new Vector2();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
    }*/
    void Start()
    {
        //canvas.SetActive(false);
        //canvas = GameObject.Find("Canvas");
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>();
        equipment = GameManager.GetComponent<Equipment>();

        movement = new Vector2();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
        hero = GetComponent<PlayerStat>();
        Treasures = GameObject.Find("Treasures");
    }

    void Update()
    {
        xAxis = gameObject.transform.localPosition.x;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //if(Input.GetKeyDown(KeyCode.Escape) && !gameManager.isGamePause)
        //{
        //    Debug.Log("uuu");
        //    gameManager.isGamePause = true;
        //    canvas = Instantiate(MenuCanvas);
        //    canvas.transform.SetParent(transform);
        //    if (canvas == null)
        //        Debug.Log("qqq");
        //}
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    canvas = Instantiate(EquipmentCanvas);
        //    canvas.transform.SetParent(gameObject.transform, false);
        //    panel = GameObject.Find("EquipmentPanel");
        //    foreach (GameObject i in hero.items)
        //    {
        //        i.transform.SetParent(canvas.transform.GetChild(0), false);
        //    }
        //    gameManager.isGamePause = true;
        //    equipment.EquipmentStart();
        //}
        //else
        //{
            if ((movement.x == 0 && movement.y == 0) || gameManager.isGamePause)
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
                RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, moveSpeed * Time.fixedDeltaTime);
                if (hit.collider == null)
                {
                    if (movement.x < 0)
                    {
                        animator.SetBool("isRight", false);
                        animator.SetBool("isMoving", true);
                    }
                    else
                    {
                        animator.SetBool("isRight", true);
                        animator.SetBool("isMoving", true);
                    }
                    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                    canWalk = true;
                }
                else if (movement.y == 1 && canWalk)
                {
                    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                    animator.SetBool("isMoving", true);
                    animator.SetBool("isRight", true);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                    animator.SetBool("isRight", false);
                }
            }
            if (isAttacking)
            {
                if (xAxis > enemyXAxis)
                {
                    animator.SetBool("isAttack", true);
                    animator.SetBool("isRight", false);
                }
                else
                {

                    animator.SetBool("isAttack", true);
                    animator.SetBool("isRight", true);
                }
                isAttacking = false;
            }
            else
            {
                animator.SetBool("isAttack", false);
            }
            if (isBlocking)
            {
                if (xAxis > enemyXAxis)
                {
                    animator.SetBool("isBlock", true);
                    animator.SetBool("isRight", false);
                }
                else
                {
                    animator.SetBool("isBlock", true);
                    animator.SetBool("isRight", true);
                }
                isBlocking = false;
            }
            else
            {
                animator.SetBool("isBlock", false);
            }
            if (isDeath)
            {
                if (xAxis > enemyXAxis)
                {
                    animator.SetBool("isDeath", true);
                    animator.SetBool("isRight", false);
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
            if (isHurt)
            {
                if (xAxis > enemyXAxis)
                {
                    animator.SetBool("isHurt", true);
                    animator.SetBool("isRight", false);
                }
                else
                {
                    animator.SetBool("isHurt", true);
                    animator.SetBool("isRight", true);
                }
                isHurt = false;
            }
            else
            {
                animator.SetBool("isHurt", false);
            }
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CaveWallTag"))
        {
            canWalk = false;
            falseMovement = movement;
        }
        else if(other.gameObject.CompareTag("MonsterTag"))
        {
            if (!isFightPanel)
            {
                isFightPanel = true;
                canvas = Instantiate(CanvasSource);
                canvas.transform.SetParent(gameObject.transform, false);
                //canvas.SetActive(true);
                //canvas.SetActive(true);
                canvas = GameObject.Find("Canvas");
                gameManager.isGamePause = true;
                gameManager.fightStart(other.transform.gameObject);
            }
                //gameObject.transform.GetChild(6).transform.GetChild(0).transform.GetChild(0).GetComponent<FightPanelManager>().startFight(other.transform.GetComponentInParent<Monster>());
        }
        else if(other.gameObject.CompareTag("TreasureTag"))
        {
            Treasures.GetComponent<TreasureGenerator>().treasureLoot(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CaveWallTag"))
        {
            
        }
        else if (other.gameObject.CompareTag("MonsterTag"))
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRight", false);
            isFightPanel = false;
        }
    }
}
