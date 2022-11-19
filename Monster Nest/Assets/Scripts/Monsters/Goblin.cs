using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        type = Enums.MonsterType.goblin;
        name = "Goblin";
        minAttack = 1;
        maxAttack = 10;
        chanceForUnik = 20;
        totalHealth = 30;
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
