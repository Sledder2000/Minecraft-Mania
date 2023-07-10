using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int XP { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        XP = 0;
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
}
