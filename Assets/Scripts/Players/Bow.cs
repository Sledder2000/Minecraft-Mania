using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    public Bow(string name, Sprite icon, int durability) : base(name, icon, durability)
    {
        Damage = 15;
    }
}
