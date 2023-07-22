using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CombatController CC;

    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool AttackWithSword(Sword sword, Combatant target)
    {
        if (sword.Durability == 0) { return false; }
        DealTrueDamage(sword.Damage, target);
        sword.ChangeDurability(-1);
        return true;
    }

    public bool AttackWithAxe(Axe axe, Combatant target)
    {
        if (axe.Durability == 0) { return false; }
        DealTrueDamage(axe.Damage, target);
        axe.ChangeDurability(-1);
        return true;
    }

    public bool AttackWithBow(Bow bow, Combatant target, int numArrows)
    {
        if (bow.Durability == 0 || !gameObject.GetComponent<Inventory>().HasItems(ItemList.Arrow, numArrows)) 
        {
            return false; 
        }
        DealTrueDamage(bow.Damage * numArrows, target);
        bow.ChangeDurability(-1 * numArrows);
        gameObject.GetComponent<Inventory>().RemoveItems(ItemList.Arrow, numArrows);
        return true;
    }

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }
}
