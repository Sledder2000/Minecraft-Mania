using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item
{
    public Consumable(string name, Sprite icon) : base(name, 1, icon)
    {
        // idk what to put here
    }

    public abstract void Use();
}
