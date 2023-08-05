using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CombatController CC;
    public Weapon EquippedWeapon { get; private set; }
    public Armor EquippedArmor { get; private set; }
    public int ArrowsToUse { get; private set; }
    private Fists fists;
    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();
        fists = new Fists();
        gameObject.GetComponent<Inventory>().AddEquipment(fists);
        EquippedWeapon = fists;
        Armor noArmor = new("No armor", null, 999999999, 0, 0.0);
        gameObject.GetComponent<Inventory>().AddEquipment(noArmor);
        EquippedArmor = noArmor;
        ArrowsToUse = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }

    /*public bool AttackWithSword(Sword sword, Combatant target)
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
    }*/

    public bool MeleeAttack(Combatant target)
    {
        if (EquippedWeapon.Durability == 0) { return false; }
        DealTrueDamage(EquippedWeapon.Damage, target);
        EquippedWeapon.ChangeDurability(-1);
        EquippedWeapon = fists;
        return true;
    }

    public bool BowAttack(Combatant target, int numArrows)
    {
        if (EquippedWeapon.Durability == 0)
        {
            return false;
        }
        DealTrueDamage(EquippedWeapon.Damage * numArrows, target);
        EquippedWeapon.ChangeDurability(-1 * numArrows);
        gameObject.GetComponent<Inventory>().RemoveItems(ItemList.Arrow, numArrows);
        EquippedWeapon = fists;
        return true;
    }

    public bool ChangeEquippedWeapon(Weapon weapon)
    {
        if (weapon != null && weapon.Durability > 0)
        {
            EquippedWeapon = weapon;
            return true;
        }
        return false;
    }

    public bool SetArrowsToUse(int num)
    {
        if (num >= 0 && gameObject.GetComponent<Inventory>().HasItems(ItemList.Arrow, num))
        {
            ArrowsToUse = num;
            return true;
        }
        return false;
    }

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }
}
