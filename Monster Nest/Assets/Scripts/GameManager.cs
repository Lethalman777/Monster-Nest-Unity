using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{   
    GameMusicManager musicManager;
    public GameObject Player;
    PlayerStat hero;
    FightPanelManager Canvas;
    Monster enemy;
    MonsterMovement enemyMovement;
    PlayerMovement playerMovement;
    public bool isGamePause = false;
    public bool isFight = false;
    public bool isFightHappen;
    public bool isChoiceMade = false;
    bool isTurnChanged = true;
    int phase = 0;
    int pointer = 0;
    public GameObject Enemy;
    public Animator EnemyAnim;
    public Animator PlayerAnim;

    string comunicate = "";
    bool isDoubleTurn;
    bool isYourTurn = true;
    int i = 0, e;
    int x = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        isFight = false;
    }
    void Start()
    {
        musicManager = GameObject.Find("AudioManager").GetComponent<GameMusicManager>();
        Player = GameObject.Find("Player");
        hero = Player.GetComponent<PlayerStat>();
        isGamePause = false;
        //Canvas = GameObject.Find("FightText").GetComponent<FightPanelManager>();
        isFightHappen = false;
        isChoiceMade = false;
        isTurnChanged = true;
        phase = 0;
        pointer = 0;
        playerMovement = Player.GetComponent<PlayerMovement>();
        //GameObject.Find("Monsters").GetComponent<MonsterGenerator>().generatorStart();
        //GameObject.Find("Treasures").GetComponent<TreasureGenerator>().generatorStart();
    }

    // Update is called once per frame
    void Update()
    {       
        if (isFightHappen)
        {
            if (isFight)
            {
                menuSteering();
            }
            fight();
            /*if(playerMovement.isAttacking)
            {
                PlayerAnim.SetBool("isAttack", true);
            }*/
               
        }
        else if(Canvas != null)
        {
            Destroy(Enemy);
            Destroy(Player.transform.GetChild(7).gameObject);
            Player.GetComponent<PlayerMovement>().isFightPanel = false;
            isGamePause = false; 
        }
    }

    string newLine()
    {
        return Environment.NewLine;
    }

    void wait(float waitTime)
    {
        float counter = 0;

        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
        }
    }

    public IEnumerator Timer()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void fightStart(GameObject enemy)
    {
        Canvas = GameObject.Find("FightText").GetComponent<FightPanelManager>();
        //Canvas = canvas.GetComponent<FightPanelManager>();
        
        this.Enemy = enemy;
        Canvas.monsterBar = GameObject.Find("MonsterBar").GetComponent<Slider>();
        enemyMovement = enemy.GetComponent<MonsterMovement>();
        this.enemy = enemy.GetComponent<Monster>();
        PlayerAnim = Player.GetComponent<Animator>();
        PlayerAnim.SetBool("isMoving", false);
        PlayerAnim.SetBool("isRight", false);
        playerMovement.enemyXAxis = enemyMovement.xAxis;
        enemyMovement.playerXAxis = playerMovement.xAxis;
        phase = 0;
        Canvas.enemy = enemy.GetComponent<Monster>();
        isFight = true;
        isFightHappen = true;
        musicManager.musicPlay();
        //PlayerAnim.SetBool("isAttack", true);
    }
        void menuSteering()
    {     
       // FightPanelManager panel = Canvas.GetComponent<FightPanelManager>();
            Canvas.fightUI(comunicate, phase, pointer, enemy);
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (phase == 0)
                {
                    if (pointer < 3)
                        pointer++;
                }
                else if(phase == 1)
                {
                    if (pointer < 2)
                        pointer++;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (pointer > 0)
                {
                    pointer--;
                }
            }
            if(Input.GetKeyDown(KeyCode.Space))
        {
            isChoiceMade = true;
            wait(5);
        }
    }

    void fight()
    {
        if (isTurnChanged)
        {
            if (UnityEngine.Random.Range(1, 100) <= 50)
                isDoubleTurn = false;
            else
                isDoubleTurn = true;
            if (isDoubleTurn)
            {
                if (isYourTurn)
                    comunicate += "Posiadasz podwójny ruch" + newLine() + newLine();
                i = 0;
            }
            else
            {
                i = 1;
            }
            isTurnChanged = false;
        }
            if (isYourTurn)
            {
                if (i < 2)
                {
                    phase = 0;
                if (isChoiceMade)
                {
                    switch (pointer)
                    {
                        case 0:
                            if (hero.Stamina > 30)
                            {
                                //PlayerAnim.SetBool("isAttack", true);
                                playerMovement.isAttacking = true;
                                hero.Stamina -= 30;
                                if (UnityEngine.Random.Range(1, 70) <= enemy.chanceForUnik)
                                {
                                    comunicate += "Wróg wykona³ unik" + newLine();
                                    enemyMovement.isBlocking = true;
                                }
                                else
                                {
                                    enemyMovement.isHurt = true;
                                    if (UnityEngine.Random.Range(1, 100) <= hero.activeWeapon.bonusCriticalAttack)
                                    {
                                        e = 2 * (hero.activeWeapon.attack + hero.activeWeapon.criticalAttack);
                                        enemy.health -= e;
                                        comunicate += "Zrani³eœ wroga krytycznie" + newLine();
                                        comunicate += "Zada³eœ " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                                    }
                                    else
                                    {
                                        e = 2 * hero.activeWeapon.attack;
                                        enemy.health -= 2 * hero.activeWeapon.attack;
                                        comunicate += "Zada³eœ " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                                    }
                                }
                            }
                            else
                            {
                                comunicate += "Za ma³o wytrzyma³oœci" + newLine();
                                i--;
                            }
                            i++;
                            break;
                        case 1:
                            if (hero.Stamina > 15)
                            {
                                playerMovement.isAttacking = true;
                                hero.Stamina -= 15;
                                if (UnityEngine.Random.Range(1, 100) <= enemy.chanceForUnik)
                                {
                                    comunicate += "Wróg wykona³ unik" + newLine();
                                    enemyMovement.isBlocking = true;
                                }
                                else
                                {
                                    enemyMovement.isHurt = true;
                                    if (UnityEngine.Random.Range(1, 100) <= hero.activeWeapon.bonusCriticalAttack)
                                    {
                                        e = (hero.activeWeapon.attack + hero.activeWeapon.criticalAttack);
                                        enemy.health -= e;
                                        comunicate += "Zrani³eœ wroga krytycznie" + newLine();
                                        comunicate += "Zada³eœ " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                                    }
                                    else
                                    {
                                        e = 2 * hero.activeWeapon.attack;
                                        enemy.health -= hero.activeWeapon.attack;
                                        comunicate += "Zada³eœ " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                                    }
                                }
                            }
                            else
                            {
                                comunicate += "Za ma³o wytrzyma³oœci" + newLine();
                                i--;
                            }
                            i++;
                            break;
                        case 2:
                            foreach (GameObject p in hero.items)
                            {
                                if (p.GetComponent<Item>().type == Enums.ItemType.potion)
                                {
                                    if (p.GetComponent<Item>().potionType == Enums.potionType.health)
                                        hero.useItem(p.GetComponent<Item>());
                                    break;
                                }
                            }
                            i++;
                            break;
                        case 3:
                            foreach (GameObject p in hero.items)
                            {
                                if (p.GetComponent<Item>().type == Enums.ItemType.potion)
                                {
                                    if (p.GetComponent<Item>().potionType == Enums.potionType.stamina)
                                        hero.useItem(p.GetComponent<Item>());
                                    break;
                                }
                            }
                            i++;
                            break;
                        default: break;
                    }
                    if (i == 2)
                    {
                        isYourTurn = false;
                        phase = 1;
                        pointer = 0;
                        isTurnChanged = true;
                        comunicate = "";
                    }
                    isChoiceMade = !isChoiceMade;

                    
                    //PlayerAnim.SetBool("isAttack", false);
                    //playerMovement.isAttacking = false;
                }
                }
            }
            else
            {
            if (isChoiceMade)
            {
                switch (pointer)
                {
                    case 0:
                        if (hero.Stamina > 5)
                        {
                            //PlayerAnim.SetBool("isBlock", true);
                            if (UnityEngine.Random.Range(1, 100) <= 50)
                            {
                                playerMovement.isBlocking = true;
                                comunicate += "Wykona³eœ udany unik" + newLine();
                            }
                            else
                            {
                                playerMovement.isHurt = true;
                                e = UnityEngine.Random.Range(enemy.minAttack, enemy.maxAttack);
                                hero.Health -= e;
                                comunicate += "Wróg zada³ ci " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                            }
                        }
                        else
                        {
                            playerMovement.isHurt = true;
                            e = UnityEngine.Random.Range(enemy.minAttack, enemy.maxAttack);
                            hero.Health -= e;
                            comunicate += "Za ma³o wytrzyma³oœci" + newLine();
                            comunicate += "Wróg zada³ ci " + "<color=red>" + e + "</color>" +" pkt. obra¿eñ" + newLine();
                        }
                        i++;
                        break;
                    case 1:
                        playerMovement.isHurt = true;
                        e = UnityEngine.Random.Range(enemy.minAttack, enemy.maxAttack);
                        hero.Health -= e;
                        comunicate += "Wróg zada³ ci " + "<color=red>" + e + "</color>" + " pkt. obra¿eñ" + newLine();
                        i++;
                        break;
                    default: break;
                }               
                enemyMovement.isAttacking = true;
                isTurnChanged = true;
                isChoiceMade = !isChoiceMade;
                isYourTurn = true;
                phase = 0;
                pointer = 0;
                comunicate = "";
            }
            }
            
            if (hero.Health <= 0)
            {
            playerMovement.isDeath = true;
                comunicate += "Nie ¿yjesz" + newLine();
            Canvas.fightUI(comunicate, phase, pointer, enemy);
            isFight = false;
            isFightHappen = false;
            float j = 0;
            while (j < 2)
            {
                j += Time.deltaTime;
            }
            playerMovement.canvas = Instantiate(playerMovement.CanvasEnd, Player.transform,false);
            j = 0;
            while (j<300)
            {
                j+=Time.deltaTime;
            }
            Application.Quit();
            return;
            }
            else if (enemy.health <= 0)
            {
            enemyMovement.isDeath = true;
            Canvas.fightUI(comunicate, phase, pointer, enemy);
            comunicate += "Pokona³eœ wroga" + newLine();
            isFight = false;
            isFightHappen=false;
            musicManager.musicPlay();
            return;
            }                
    }
}
