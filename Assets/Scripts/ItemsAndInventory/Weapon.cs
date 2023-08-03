using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipment
{
    public int Damage { get; protected set; }
    public Weapon(string name, Sprite icon, int durability) : base(name, icon, durability)
    {

    }
}
