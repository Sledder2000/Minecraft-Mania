using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewManager : MonoBehaviour
{
    private Vector2 AnchorPos;
    [SerializeField] private int Width, Height;
    private Grid GridInfo;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private GameObject QuantityPrefab;
    private Dictionary<Vector2, Item> Items;
    private List<GameObject> SpawnedItems;
    
    // Start is called before the first frame update
    void Start()
    {
        GridInfo = gameObject.GetComponent<Grid>();
        Items = new Dictionary<Vector2, Item>();
        SpawnedItems = new List<GameObject>();
        AnchorPos = new Vector2(gameObject.transform.position.x - 6 * Width * GridInfo.cellSize.x - 28, 
            gameObject.transform.position.y + 6 * Height * GridInfo.cellSize.y - 11);
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
            spawnedItem.GetComponent<ClickableWeapon>().Wpn = (Weapon)weapon;
            spawnedItem.GetComponent<ClickableWeapon>().Owner = inv.gameObject.GetComponent<Player>();
            SpawnedItems.Add(spawnedItem);
            Items[new Vector2(Width, Height)] = weapon;
            count++;
        }
    }

    public void GenerateInventoryView(Inventory inv)
    {
        int count = 0;
        foreach (Item item in inv.Items.Keys)
        {
            float xPos = AnchorPos.x + 13.75f * (count % Width) * (GridInfo.cellSize.x + GridInfo.cellGap.x);
            float yPos = AnchorPos.y - 13.75f * (count / Width) * (GridInfo.cellSize.y + GridInfo.cellGap.y);
            var spawnedItem = Instantiate(ItemPrefab, new Vector2(xPos, yPos), Quaternion.identity);
            spawnedItem.transform.localScale *= 14;
            spawnedItem.GetComponent<SpriteRenderer>().sprite = item.Icon;
            spawnedItem.GetComponent<ClickableWeapon>().clickable = false;
            SpawnedItems.Add(spawnedItem);
            Items[new Vector2(Width, Height)] = item;

            if (inv.ItemCount(item) > 1)
            {
                var quantityIndicator = Instantiate(QuantityPrefab, new Vector2(1.02f * xPos + 15, yPos - 5), Quaternion.identity, GameObject.Find("Canvas").transform);
                quantityIndicator.GetComponent<TMPro.TMP_Text>().text = "" + inv.ItemCount(item);
                SpawnedItems.Add(quantityIndicator);
            }
            count++;
        }
    }

    public void RemoveSpawnedItems()
    {
        foreach (GameObject item in SpawnedItems)
        {
            Destroy(item);
        }
        SpawnedItems.Clear();
    }
}
