using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FightPanelManager : MonoBehaviour
{
    public GameObject Player;
    PlayerStat hero;
    public Monster enemy;
    public Slider monsterBar;
    public Text panelText;
    List<string> tab = new List<string>() { "ci�ki atak", "lekki atak", "wypij mikstur� lecznicz�", "wypij mikstur� wytrzyma�o�ci" };
    List<string> tab1 = new List<string>() { "unik", "nic nie r�b" };
    // Start is called before the first frame update
    void Start()
    {
        panelText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        monsterBar.maxValue = enemy.totalHealth;
        monsterBar.value = enemy.health;
    }

    public void startFight(Monster Enemy)
    {
        enemy = Enemy;
        hero = Player.GetComponent<PlayerStat>();
        gameObject.GetComponent<Text>().text = "Bohater   Punkty �ycia: " + hero.Health + " / " + hero.totalHealth + " Wytrzyma�o��: " +
        hero.Stamina + " / " + hero.totalStamina + Environment.NewLine +
        "Wr�g   Punkty �ycia: " + enemy.health + " / " + enemy.totalHealth;       
    }

    public void fightUI(string communicate, int phase, int pointer, Monster enemy)
    {
        panelText = gameObject.GetComponent<Text>();
        panelText.text = ""; 
        switch(phase)
        {
            case 0:
                foreach (string s in tab)
                {
                    if(pointer == tab.IndexOf(s))
                       panelText.text += "<color=red><b>" + s + "</b></color>";
                    else
                       panelText.text += "<color=white><b>" + s + "</b></color>";
                    panelText.text += newLine();
                }
                break;
                            
            case 1:
                foreach (string s in tab1)
                { 
                    if (pointer == tab1.IndexOf(s))
                        panelText.text += "<color=red><b>" + s + "</b></color>";
                    else
                        panelText.text += "<color=white><b>" + s + "</b></color>";
                    panelText.text += newLine();
                }
                break;
        }
        panelText.text += newLine();
        panelText.text += "<color=white>" + communicate + "</color>";
    }

    static string newLine()
    {
        return Environment.NewLine;
    }
}
