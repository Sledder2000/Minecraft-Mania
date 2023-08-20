using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    // Start is called before the first frame update
    CombatController cc;
    bool combatStarted = false;
    List<Combatant> ps = new();
    List<Combatant> es = new();
    List<Combatant> cs = new();
    void Start()
    {
        cc = GameObject.Find("CombatController").GetComponent<CombatController>();
        Combatant player = GameObject.Find("Steve").GetComponent<Combatant>();
        Combatant player2 = GameObject.Find("Alex").GetComponent<Combatant>();
        Combatant enemy = GameObject.Find("Enemy").GetComponent<Combatant>();
        Combatant enemy2 = GameObject.Find("Enemy2").GetComponent<Combatant>();
        Inventory inv = GameObject.Find("Steve").GetComponent<Inventory>();
        Inventory inv2 = GameObject.Find("Alex").GetComponent<Inventory>();
        ItemSprites isprites = GameObject.Find("ItemSprites").GetComponent<ItemSprites>();

        player.SetSpeed(10);
        player2.SetSpeed(5);
        enemy.SetSpeed(10);
        enemy2.SetSpeed(15);
        player.SetMaxHP(10);
        player2.SetMaxHP(150);
        enemy.SetMaxHP(100);
        enemy2.SetMaxHP(150);


        player.IsPlayer = true;
        player2.IsPlayer = true;
        enemy.IsPlayer = false;
        enemy.IsPlayer = false;

        ps.Add(player);
        ps.Add(player2);
        es.Add(enemy);
        es.Add(enemy2);
        cs.Add(player);
        cs.Add(player2);
        cs.Add(enemy);
        cs.Add(enemy2);

        inv.AddItems(ItemList.Arrow, 30);
        inv.AddEquipment(new Sword("Wood Sword", isprites.WoodSword, 3, 10));
        inv.AddEquipment(new Bow("Bow", isprites.Bow, 5));

        inv2.AddItems(ItemList.Arrow, 2);
        inv2.AddEquipment(new Sword("Iron Axe", isprites.IronAxe, 5, 25));
        inv2.AddEquipment(new Bow("Bow", isprites.Bow, 5));

        inv.AddItems(ItemList.Stone, 2);
        inv.AddItems(ItemList.Emerald, 3);
        inv.AddItems(ItemList.Gold, 5);
        inv.AddItems(ItemList.Wood, 12);
        inv.AddItems(ItemList.Diamond, 1);
        inv.AddItems(ItemList.Iron, 9);
        inv.AddItems(ItemList.RottenFlesh, 9);
        inv.AddItems(ItemList.Redstone, 9);
        inv.AddItems(ItemList.Netherite, 9);

        inv2.AddItems(ItemList.Netherite, 69);



        /*for (int i = 0; i < 10; i++)
        {
            cc.TakeTurn();
            Debug.Log("Enemy HP: " + enemy.HP);
            cc.TakeTurn();
            Debug.Log("Player HP: " + player.HP);
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        if (!combatStarted && Input.GetKeyDown(KeyCode.C))
        {
            cc.BeginCombat(ps, es);

            foreach (Combatant c in cc.Combatants)
            {
                Debug.Log(c.gameObject.name + ": " + c.Speed);
            }
        }
    }
}
