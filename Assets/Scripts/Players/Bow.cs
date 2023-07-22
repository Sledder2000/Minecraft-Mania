using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Equipment
{
    public int Damage { get; private set; }

    public Bow(string name, Sprite icon, int durability) : base(name, icon, durability)
    {
        Damage = 15;
    }
}
