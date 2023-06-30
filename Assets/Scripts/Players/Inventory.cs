using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<GameObject, int> Items;
    private List<GameObject> Equipment;

    // Start is called before the first frame update
    void Start()
    {
        Items = new Dictionary<GameObject, int>();
        Equipment = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasItems(GameObject item, int count)
    {
        return !Items.ContainsKey(item) || Items[item] < count;
    }

    public void AddItems(GameObject item, int count)
    {
        if (!Items.ContainsKey(item))
        {
            Items.Add(item, 0);
        }
        Items[item] += count;
    }

    public bool RemoveItems(GameObject item, int count)
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

    public void AddEquipment(GameObject equipment)
    {
        Equipment.Add(equipment);
    }
}
