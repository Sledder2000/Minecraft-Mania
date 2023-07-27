using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    public Axe(string name, Sprite icon, int durability, int damage) : base(name, icon, durability)
    {
        Damage = damage;
    }

}
