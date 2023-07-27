using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    public Sword(string name, Sprite icon, int durability, int damage) : base(name, icon, durability)
    {
        Damage = damage;
    }

}
