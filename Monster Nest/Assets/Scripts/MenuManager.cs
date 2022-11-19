using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject MainMenu;
    Text menu;

    bool isChoiceMade = true;
    bool isHero = false;
    int pointer = 0;
    float j = 0;

    List<string> currentList;
    List<string> mainList = new List<string>() { "Nowa Gra", "Wyjœcie" };
    List<string> heroList = new List<string>() { "Wybierz Klasê Postaci", "Paladyn", "Bard", "£otrzyk", "Powrót" };

    public Enums.HeroClass hero;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu = GameObject.Find("MainMenu");
        menu = MainMenu.transform.GetChild(1).gameObject.GetComponent<Text>();
        currentList = mainList;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChoiceMade)
        {
            menuShow();
                menuNavigation();
        }  
    }
    private void FixedUpdate()
    {        
       

    }

    void menuNavigation()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pointer < currentList.Count - 1)
                pointer++;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentList == heroList && pointer > 1)
            {
                pointer--;
            }
            else
            {
                if (pointer > 0)
                    pointer--;
            }
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChoiceMade();
            return;
        }
    }

    void menuShow()
    {
        menu.text = "";
            foreach(var item in currentList)
            {
            if (pointer == currentList.IndexOf(item) || (currentList == heroList && currentList.IndexOf(item) == 0))
                menu.text += "<color=red><b>" + item + "</b></color>" + Environment.NewLine;
            else
                menu.text += "<color=white><b>" + item + "</b></color>" + Environment.NewLine;
            }
    }

    void ChoiceMade()
    {
        if(isHero)
        {
            switch(pointer)
            {
                case 1:
                    pointer = 0;
                    isHero = false;
                    isChoiceMade = false;
                    hero = Enums.HeroClass.paladin;
                    SceneManager.LoadScene("MainGame");
                    break;
                case 2:
                    pointer = 0;
                    isHero = false;
                    isChoiceMade = false;
                    hero = Enums.HeroClass.bard;
                    SceneManager.LoadScene("MainGame");
                    break;
                case 3:
                    pointer = 0;
                    isHero = false;
                    isChoiceMade = false;
                    hero = Enums.HeroClass.theif;
                    SceneManager.LoadScene("MainGame");
                    break;
                case 4:
                    isHero = false;
                    pointer = 0;
                    currentList = mainList;
                    break;
            }
        }
        else
        {
            switch (pointer)
            {
                case 0:
                    isHero = true;
                    pointer = 1;
                    currentList = heroList;
                    break;
                case 1:                    
                    break;
            }
        }
    }
}
