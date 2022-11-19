using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string name { get; set; }
    public int health { get; set; }
    public int totalHealth { get; set; }
    public int minAttack { get; set; }
    public int maxAttack { get; set; }
    public int chanceForUnik { get; set; }
    public Enums.MonsterType type { get; set; }

    public Slider healthBar;
    public GameObject canvasBar;
    public GameManager gameManager;
    public GameObject Canvas;
 
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
        //healthBar.maxValue = totalHealth;
        //healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.maxValue = totalHealth;
        //healthBar.value = health;
        //if(!gameManager.isFight && canvasBar != null)
        //{
        //    Destroy(canvasBar);
        //}
    }
}
