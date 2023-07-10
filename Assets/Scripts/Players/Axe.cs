using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Equipment
{
    private int Damage;

    public Axe(string name, Sprite icon, int durability, int damage) : base(name, icon, durability)
    {
        Damage = damage;
    }

    public int getDamage()
    {
        return Damage;
    }

}
