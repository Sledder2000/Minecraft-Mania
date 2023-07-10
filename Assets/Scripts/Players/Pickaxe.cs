using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : Equipment
{
    private int Tier; // 0 = wood, 1 = stone, 2 = iron, 3 = diamond, 4 = netherite

    public Pickaxe(string name, Sprite icon, int durability, int tier) : base(name, icon, durability)
    {
        Tier = tier;
    }

    public int getTier()
    {
        return Tier;
    }

}
