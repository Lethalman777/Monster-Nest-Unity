using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringer : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        type = Enums.MonsterType.skeleton;
        name = "Death Bringer";
        minAttack = 20;
        maxAttack = 40;
        chanceForUnik = 50;
        totalHealth = 60;
        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
