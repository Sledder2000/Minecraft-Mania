using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{

    private string Name;
    private int Type; // 0 = resource, 1 = consumable, 2 = equipment, 3 = permanent item
    public Sprite Icon { get; private set; }

    public Item(string name, int type, Sprite icon)
    {
        Name = name;
        Type = type;
        Icon = icon;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetItemType()
    {
        return Type;
    }
}