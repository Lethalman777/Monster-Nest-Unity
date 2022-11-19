using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    int pointer = 0;
    float j = 0;

    Text menu;
    GameManager gameManager;
    MenuManager menuManager;
    List<string> mainList = new List<string>() { "PowrÛt Do Gry", "Wyjdü do Menu", "Wyjdü Z Gry" };
    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        menu = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        menuShow();
      
            menuNavigation();
    }

    void menuNavigation()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pointer < mainList.Count - 1)
                pointer++;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (pointer > 0)
                pointer--;
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
        menu.text += "<color=red><b>Menu</b></color>" + Environment.NewLine;
        foreach (var item in mainList)
        {
            if (pointer == mainList.IndexOf(item))
                menu.text += "<color=red><b>" + item + "</b></color>" + Environment.NewLine;
            else
                menu.text += "<color=white><b>" + item + "</b></color>" + Environment.NewLine;
        }
    }

    void ChoiceMade()
    {
        gameManager.isGamePause = false;
        switch (pointer)
        {
            case 0:                
                Destroy(this);
                break;
            case 1:
                SceneManager.LoadScene("MainMenu");
                break;
            case 2:            
                break;
        }
    }
}
