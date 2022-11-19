using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public Enums.HeroClass type { get; set; }
    public int baseHealth { get; set; }
    public int totalHealth { get; set; }
    public int totalStamina { get; set; }
    public int Health { get; set; }
    public int Stamina { get; set; }
    public Item activeArmor;
    public Item activeWeapon;
    public GameObject item;
    public List<GameObject> items;
    public GameObject canvas;
    public GameObject Canvas;
    public Slider healthBar;
    public Slider staminaBar;
    public Slider monsterBar;
    public Monster monster;
    public GameManager gameManager;

    private void Awake()
    {
        type = GameObject.Find("MenuManager").GetComponent<MenuManager>().hero;
    }
    // Start is called before the first frame update
    void Start()
    {
        HeroStart(type);
        canvas = Instantiate(Canvas);
        canvas.transform.SetParent(transform);
        healthBar = canvas.transform.GetChild(1).gameObject.GetComponent<Slider>();
        staminaBar = canvas.transform.GetChild(0).gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = totalHealth;
        staminaBar.maxValue = totalStamina;
        healthBar.value = Health;
        staminaBar.value = Stamina;
        //if(gameManager.isFight)
        //{
        //    canvas.transform.GetChild(2).gameObject.SetActive(true);
        //    monsterBar = canvas.transform.GetChild(2).gameObject.GetComponent<Slider>();
        //    monsterBar.maxValue = monster.totalHealth;
        //    monsterBar.value = monster.health;
        //}
        //else
        //{
        //    canvas.transform.GetChild(2).gameObject.SetActive(false);
        //}
    }

    public void HeroStart(Enums.HeroClass type)
    {
        this.type = type;
        if (type == Enums.HeroClass.paladin)
        {
            items = new List<GameObject>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[0].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Pancerz stra¿nika miejskiego", 0,0,0,0, 15);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Prosty miecz",0, 10, 5, 15, 0);
            activeArmor = items[0].GetComponent<Item>();
            activeWeapon = items[1].GetComponent<Item>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[2].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 0,0,0,0);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[3].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 0,0,0,0);
            baseHealth = 45;
            totalHealth = 45 + activeArmor.Defence;
            Health = totalHealth;
            totalStamina = 100;
            Stamina = 100;
        }
        else if(type == Enums.HeroClass.bard)
        {
            items = new List<GameObject>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[0].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Skórzana kurtka",0,0,0,0, 10);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Lutnia",0, 5, 20, 2, 0);
            activeArmor = items[0].GetComponent<Item>();
            activeWeapon = items[1].GetComponent<Item>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[2].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 0, 0, 0, 0);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[3].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 0, 0, 0, 0);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[4].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 0, 0, 0, 0);
            baseHealth = 40;
            totalHealth = 40 + activeArmor.Defence;
            Health = totalHealth;
            totalStamina = 90;
            Stamina = 90;
        }
        else if(type==Enums.HeroClass.theif)
        {
            items = new List<GameObject>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[0].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Spodnie kopacza",0,0,0,0, 5);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Nó¿ z³odzieja",0, 20, 10, 15,0);
            activeArmor = items[0].GetComponent<Item>();
            activeWeapon = items[1].GetComponent<Item>();
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[2].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 0, 0, 0, 0);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[3].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 0, 0, 0, 0);
            items.Add(Instantiate(item));
            items[items.Count - 1].transform.SetParent(GameObject.Find("Equipment").transform, false);
            items[4].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "pancerz", 0, 0, 0, 0, 5);
            baseHealth = 50;
            totalHealth = 50 + activeArmor.Defence;
            Health = totalHealth;
            totalStamina = 105;
            Stamina = 105;
        }
    }

    public void useItem(Item item)
    {      
        if (item.type == Enums.ItemType.weapon)
        {
            activeWeapon = item;
        }
        else if (item.type == Enums.ItemType.armor)
        {
            activeArmor = item;
        }
        else
        {
            if (item.potionType == Enums.potionType.health)
            {
                if (Health + item.plusPoints >= totalHealth)
                    Health = totalHealth;
                else
                    Health += item.plusPoints;
            }
            else
            {
                if (Stamina + item.plusPoints >= totalStamina)
                    Stamina = totalStamina;
                else
                    Stamina += item.plusPoints;
            }
            Destroy(item.gameObject);
            items.Remove(item.gameObject);
        }
    }
}
