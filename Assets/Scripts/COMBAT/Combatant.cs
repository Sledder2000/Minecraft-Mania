using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour, IComparable {
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int XP { get; private set; }
    public int Speed { get; private set; }
    public bool IsPlayer; //{ get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        XP = 0;
        Speed = 10;
        if (gameObject.GetComponent<Player>() == null)
        {
            IsPlayer = false;
        }
        else
        {
            IsPlayer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHP(int value)
    {
        if (value > 0)
        {
            MaxHP = value;
        }
    }

    public void SetSpeed(int value)
    {
        if (value > 0)
        {
            Speed = value;
        }
    }

    public void ChangeXP(int amount)
    {
        XP += amount;
    }

    public void TakePhysicalDamage(int damage)
    {
        
    }

    public void TakeMagicDamage(int damage)
    {

    }

    public void TakeImpactDamage(int damage)
    {

    }

    public void TakeTrueDamage(int damage)
    {
        if (damage > 0)
        {
            HP -= Mathf.Max(0, HP - damage);
        }
        // ADD DEATH CHECKING EVENT HERE
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            HP = Mathf.Min(MaxHP, HP + amount);
        }
    }

    public int CompareTo(object other)
    {
        if (other == null || !(other is Combatant))
        {
            return 0;
        }
        Combatant otherCombatant = (Combatant)other;
        if (this.Speed == otherCombatant.Speed)
        {
            if (this.IsPlayer && !otherCombatant.IsPlayer) { return -1; }
            if (otherCombatant.IsPlayer && !this.IsPlayer) { return 1; }
        }
        return otherCombatant.Speed - this.Speed;
    }
}