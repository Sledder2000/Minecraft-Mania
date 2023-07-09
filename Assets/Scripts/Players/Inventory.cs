using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly Dictionary<Item, int> Items = new();
    private readonly List<Equipment> Equipment = new();
    private readonly List<PermanentItem> PermItems = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool HasItems(Item item, int count)
    {
        return ItemCount(item) >= count;
    }

    public void AddItems(Item item, int count)
    {
        // no equipment in items storage
        if (item is Equipment || item is PermanentItem)
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

    public int ItemCount(Item item)
    {
        if (!Items.ContainsKey(item))
        {
            return 0;
        }
        return Items[item];
    }

    public bool HasPermItem(PermanentItem item)
    {
        return PermItems.Contains(item);
    }

    public void AddPermItem(PermanentItem item)
    {
        if (!HasPermItem(item))
        {
            PermItems.Add(item);
        }
    }

    public void AddEquipment(Equipment equipment)
    {
        Equipment.Add(equipment);
    }
}
