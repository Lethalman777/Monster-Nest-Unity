using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour 
{
    public string name { get; set; }
    public Enums.ItemType type { get; set; }
    public Enums.potionType potionType { get; set; }
    public int plusPoints { get; set; }
    public int attack { get; set; }
    public int criticalAttack { get; set; }
    public int bonusCriticalAttack { get; set; }
    public int Defence { get; set; }
    public Sprite icon { get; set; }
    public Sprite swordIcon;
    public Sprite armorIcon;
    public Sprite potionIconRed;
    public Sprite potionIconBlue;
    public Sprite hoodIcon;
    public Sprite BowIcon;

    private void Start()
    {

    }

    private void Update()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icon;
    }

    public void constructor(Enums.ItemType type, Enums.potionType potionType, string name, int plusPoints, int attack, int bonusCriticalAttack, int criticalAttack, int Defence)
    {
        if(type == Enums.ItemType.potion)
        {
            this.name = name;
            this.plusPoints = plusPoints;
            this.potionType = potionType;
            this.type = Enums.ItemType.potion;
            this.potionType = potionType;
            if(potionType == Enums.potionType.health)
            this.icon = potionIconRed;
            else
                this.icon = potionIconBlue;
        }

       else if(type == Enums.ItemType.weapon)
        {
            this.name = name;
            this.attack = attack;
            this.bonusCriticalAttack = bonusCriticalAttack;
            this.criticalAttack = criticalAttack;
            this.type = Enums.ItemType.weapon;
            this.icon = swordIcon;
        }

        else
        {
            this.name = name;
            this.Defence = Defence;
            this.type = Enums.ItemType.armor;
            this.icon = armorIcon;
        }
    }

    public string description()
    {
        if(type == Enums.ItemType.armor)
        {
            return "<color=yellow>Nazwa: " + name + Tools.newLine() +
            "Ochrona: " + Defence + "</color>";
        }
        else if (type == Enums.ItemType.weapon)
        {
            return "<color=yellow>Nazwa: " + name + Tools.newLine() +
            "Obra¿enia: " + attack + Tools.newLine() +
            "Obra¿enia krytyczne: " + criticalAttack + Tools.newLine() +
            "Szansa na trafienie krytyczne: " + bonusCriticalAttack +"</color>";
        }
        else
        {
            return "<color=yellow>Nazwa: " + name + Tools.newLine() +
            "Typ: " + type.ToString() + Tools.newLine() +
            "Wartoœæ: " + plusPoints.ToString() + "</color>";
        }
        return "";
    }
}
