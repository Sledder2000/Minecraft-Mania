using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewManager : MonoBehaviour
{
    [SerializeField] private Vector2 AnchorPos;
    [SerializeField] private int Width, Height;
    private Grid GridInfo;
    [SerializeField] private GameObject ItemPrefab;
    private Dictionary<Vector2, Item> Items;
    
    // Start is called before the first frame update
    void Start()
    {
        GridInfo = gameObject.GetComponent<Grid>();
        Items = new Dictionary<Vector2, Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEquipmentView(Inventory inv)
    {
        int count = 0;
        foreach (Equipment weapon in inv.Equipment)
        {
            if (!(weapon is Weapon)) { continue; }
            float xPos = AnchorPos.x + 13.75f * (count % Width) * (GridInfo.cellSize.x + GridInfo.cellGap.x);
            float yPos = AnchorPos.y - 13.75f * (count / Width) * (GridInfo.cellSize.y + GridInfo.cellGap.y);
            var spawnedItem = Instantiate(ItemPrefab, new Vector2(xPos, yPos), Quaternion.identity);
            spawnedItem.transform.localScale *= 14;
            spawnedItem.GetComponent<SpriteRenderer>().sprite = weapon.Icon;
            Items[new Vector2(Width, Height)] = weapon;
            count++;
        }
    }
}
