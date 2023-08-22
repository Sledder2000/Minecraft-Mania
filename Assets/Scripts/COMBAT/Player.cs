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
    public int AxeCooldown;
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
        AxeCooldown = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public bool SwordAttack(Combatant target)
    {
        if (EquippedWeapon.Durability == 0) { return false; }
        foreach (Combatant enemy in CC.Enemies)
        {
            if (enemy.Equals(target))
            {
                DealTrueDamage(EquippedWeapon.Damage, enemy);
            } else
            {
                DealTrueDamage(EquippedWeapon.Damage / 5, enemy);
            }
        }
        EquippedWeapon.ChangeDurability(-1);
        EquippedWeapon = fists;
        return true;
    }

    public bool AxeAttack(Combatant target)
    {
        if (EquippedWeapon.Durability == 0) { return false; }
        DealTrueDamage(EquippedWeapon.Damage, target);
        EquippedWeapon.ChangeDurability(-1);
        EquippedWeapon = fists;
        AxeCooldown = 2;
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

    public void FistAttack(Combatant target)
    {
        DealTrueDamage(EquippedWeapon.Damage, target);
        EquippedWeapon = fists;
    }

    public bool ChangeEquippedWeapon(Weapon weapon)
    {
        if (weapon != null && weapon.Durability > 0 && !(weapon is Axe && AxeCooldown != 0) && (!(weapon is Bow) || GetComponent<Inventory>().ItemCount(ItemList.Arrow) > 0))
        {
            EquippedWeapon = weapon;
            return true;
        }
        return false;
    }

    public bool SetArrowsToUse(int num)
    {
        if (num >= 0)
        {
            ArrowsToUse = Mathf.Min(num, gameObject.GetComponent<Inventory>().ItemCount(ItemList.Arrow));
            return true;
        }
        return false;
    }

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }

}
