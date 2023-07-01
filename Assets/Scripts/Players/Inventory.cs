using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> Items;
    private List<Equipment> Equipment;

    // Start is called before the first frame update
    void Start()
    {
        Items = new Dictionary<Item, int>();
        Equipment = new List<Equipment>();
    }

    public bool HasItems(Item item, int count)
    {
        return !Items.ContainsKey(item) || Items[item] < count;
    }

    public void AddItems(Item item, int count)
    {
        // no equipment in items storage
        if (item is Equipment)
        {
            return;
        }
        if (!Items.ContainsKey(item))
        {
            Items.Add(item, 0);
        }
        Items[item] += count;
    }

    public bool RemoveItems(Item item, int count)
    {
        if (!HasItems(item, count))
        {
            return false;
        }
        Items[item] -= count;
        if (Items[item] == 0)
        {
            Items.Remove(item);
        }
        return true;
    }

    public void AddEquipment(Equipment equipment)
    {
        Equipment.Add(equipment);
    }
}
