using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGenerator : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject treasure;
    public GameObject Item;
    public List<GameObject> treasures = new List<GameObject>();
    GameObject Player;
    PlayerStat hero;
    Vector2 vector;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        hero = Player.GetComponent<PlayerStat>(); 
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Szeroki miecz", 0, 20, 10, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Wyborna lutnia",0, 10, 20, 30, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "¯o³nierski miecz",0, 25, 5, 25, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Sztylet zabójcy",0, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "¯o³nierski miecz",0, 25, 5, 25, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.weapon, Enums.potionType.health, "Diamentowe ostrze",0, 10, 30, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Ciê¿ki pancerz stra¿nika miejskiego", 0, 15, 25, 20, 25);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Zdobiony kaftan", 0, 15, 25, 20, 20);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.armor, Enums.potionType.health, "Mroczny kaptur", 0, 15, 25, 20, 15);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.health, "Mikstura lecznicza", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 15, 25, 20, 0);
        items.Add(Instantiate(Item));
        items[items.Count - 1].transform.SetParent(transform, false);
        items[items.Count - 1].GetComponent<Item>().constructor(Enums.ItemType.potion, Enums.potionType.stamina, "Mikstura wytrzyma³oœci", 50, 15, 25, 20, 0);
        generatorStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatorStart()
    {
        Debug.Log("trt");
        RaycastHit2D hit;
        for(int i = 0; i < 20; i++)
        {
            treasures.Add(Instantiate(treasure));
            treasures[i].transform.SetParent(gameObject.transform, false);
            do
            {
                vector = new Vector2((float)UnityEngine.Random.Range(-600, 600), (float)UnityEngine.Random.Range(-600, 600));
                hit = Physics2D.Raycast(vector, vector);
            } while (hit.collider.bounds.Contains(vector));
            treasures[i].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
            Item  = Instantiate(items[UnityEngine.Random.Range(0, items.Count-1)]);
            itemWrite(Item.GetComponent<Item>(), items[UnityEngine.Random.Range(0, items.Count - 1)].GetComponent<Item>());
            Item.transform.SetParent(treasures[i].transform, false);
        }
    }

    public void treasureLoot(GameObject loot)
    {
        hero.items.Add(loot.transform.GetChild(0).gameObject);
        treasures.Remove(loot);
        loot.transform.GetChild(0).SetParent(GameObject.Find("Equipment").transform, false);
        Destroy(loot);
    }

    public void itemWrite(Item origin, Item copy)
    {
        origin.name = copy.name;
        origin.plusPoints = copy.plusPoints;
        origin.potionType = copy.potionType;
        origin.type = copy.type;
        origin.attack = copy.attack;
        origin.bonusCriticalAttack = copy.bonusCriticalAttack;
        origin.criticalAttack = copy.criticalAttack;
        origin.Defence = copy.Defence;
        origin.icon = copy.icon;
    }
}