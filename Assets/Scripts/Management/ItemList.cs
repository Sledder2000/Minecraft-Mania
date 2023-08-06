using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemList
{
    private static ItemSprites isprites = GameObject.Find("ItemSprites").GetComponent<ItemSprites>();

    public static PermanentItem Bed = new("Bed", null);
    public static PermanentItem CraftingTable = new("Crafting Table", null);
    public static PermanentItem EnchantingTable = new("Enchanting Table", null);
    public static PermanentItem BrewingStand = new("Brewing Stand", null);

    public static Resource Wood = new("Wood", isprites.Wood);
    public static Resource Stone = new("Stone", isprites.Stone);
    public static Resource Iron = new("Iron Ingot", isprites.Iron);
    public static Resource Gold = new("Gold Ingot", isprites.Gold);
    public static Resource Diamond = new("Diamond", isprites.Diamond);
    public static Resource Lapis = new("Lapis Lazuli", null);
    public static Resource Redstone = new("Redstone", isprites.Redstone);
    public static Resource Emerald = new("Emerald", isprites.Emerald);
    public static Resource Netherite = new("Netherite Ingot", isprites.Netherite);
    public static Resource Obsidian = new("Obsidian", null);

    public static Resource RottenFlesh = new("Rotten Flesh", isprites.RottenFlesh);
    public static Resource Arrow = new("Arrow", isprites.Arrow);
    public static Resource SpiderEye = new("Spider Eye", null);
    public static Resource String = new("String", null);
    public static Resource Gunpowder = new("Gunpowder", null);
    public static Resource BlazePowder = new("Blaze Powder", null);
    public static Resource GhastTear = new("Ghast Tear", null);
    public static Resource WitherSkull = new("Wither Skull", null);

}
