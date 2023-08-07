using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : Item
{
    public int MaxDurability { get; private set; }
    public int Durability { get; private set; }
    private Dictionary<Enchantment, int> Enchantments;

    public Equipment(string name, Sprite icon, int durability) : base(name, 2, icon)
    {
        Durability = durability;
        MaxDurability = durability;
        Enchantments = new Dictionary<Enchantment, int>();
    }

    public void ChangeDurability(int amount)
    {
        // prevents durability from going below 0 or above max
        Durability = Mathf.Clamp(Durability + amount, 0, MaxDurability);
    }
}
