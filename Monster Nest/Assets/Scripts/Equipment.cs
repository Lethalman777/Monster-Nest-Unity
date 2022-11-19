using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Equipment : MonoBehaviour
{
    List<GameObject> items;
    GameObject Player;
    PlayerStat hero;
    GameManager gameManager;
    PlayerMovement playerMovement;
    GameObject Canvas;
    GameObject EquipPanel, EquipDescription, EquipActive;
    bool isEquipment , isChoiceMade;
    public GameObject panel;

    int pointer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        hero = Player.GetComponent<PlayerStat>();
        items = hero.items;
        gameManager = GetComponent<GameManager>();
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isEquipment)
        {
            playerMovement.canvas = Instantiate(playerMovement.EquipmentCanvas);
            playerMovement.canvas.transform.SetParent(Player.transform, false);
            panel = GameObject.Find("EquipmentPanel");
            foreach (GameObject i in hero.items)
            {
                i.transform.SetParent(playerMovement.canvas.transform.GetChild(0), false);
            }
            gameManager.isGamePause = true;
            EquipmentStart();
        }
        if (isEquipment)
        {
            EquipmentNavigation();
            EquipmentPointer();
            if (isChoiceMade)
            {               
                isChoiceMade = false;
                if (items[pointer].GetComponent<Item>().type == Enums.ItemType.potion && pointer > 0)
                {
                    hero.useItem(items[pointer].GetComponent<Item>());
                    pointer--;
                }
                else                    
                    hero.useItem(items[pointer].GetComponent<Item>());               
            }
        }
        else if(playerMovement.canvas != null)
        {
            foreach (GameObject i in hero.items)
            {
                i.transform.SetParent(GameObject.Find("Equipment").transform, false);
            }
            Destroy(playerMovement.canvas);
            gameManager.isGamePause = false;
        }
    }

    public void EquipmentStart()
    {
        pointer = 0;
        Canvas = Player.transform.GetChild(7).transform.gameObject;
        EquipPanel = Canvas.transform.GetChild(0).gameObject;
        EquipDescription = Canvas.transform.GetChild(1).gameObject;
        EquipActive = Canvas.transform.GetChild(2).gameObject;
        isEquipment = true;
    }

    public void EquipmentNavigation()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (pointer+5 < items.Count - 1)
                pointer += 5;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pointer-5 > 0)
                pointer -= 5;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(pointer < items.Count-1)
                pointer++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(pointer > 0)
                pointer--;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
           isChoiceMade = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEquipment = false;
        }
    }

    public void EquipmentPointer()
    {
        EquipActive.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text = "<color=yellow>Active Weapon: " + hero.activeWeapon.name+ Environment.NewLine+ "Active Armor: " + hero.activeArmor.name + "</color>";
        foreach (var item in items)
        {
            if(items[pointer] == item)
            {
                item.gameObject.GetComponent<Image>().color = Color.white;
                EquipDescription.transform.GetChild(0).transform.gameObject.GetComponent<Text>().text = item.GetComponent<Item>().description();
            }
            else
            {
                item.gameObject.GetComponent<Image>().color = Color.clear;
            }
        }
    }
}
