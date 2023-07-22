using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equipment
{
    public int Damage { get; private set; }

    public Sword(string name, Sprite icon, int durability, int damage) : base(name, icon, durability)
    {
        Damage = damage;
    }

}
