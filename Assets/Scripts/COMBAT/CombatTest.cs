using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CombatController cc = GameObject.Find("CombatController").GetComponent<CombatController>();
        Combatant player = GameObject.Find("Player").GetComponent<Combatant>();
        Combatant enemy = GameObject.Find("Enemy").GetComponent<Combatant>();
        Inventory inv = GameObject.Find("Player").GetComponent<Inventory>();

        player.SetSpeed(10);
        enemy.SetSpeed(10);
        player.SetMaxHP(100);
        enemy.SetMaxHP(100);


        player.IsPlayer = true;
        enemy.IsPlayer = false;

        List<Combatant> ps = new();
        List<Combatant> es = new();
        List<Combatant> cs = new();

        ps.Add(player);
        es.Add(enemy);
        cs.Add(player);
        cs.Add(enemy);

        inv.AddItems(ItemList.Arrow, 3);
        inv.AddEquipment(new Sword("wood sword", null, 3, 10));
        inv.AddEquipment(new Bow("bow", null, 5));


        cc.BeginCombat(ps, es);

        foreach (Combatant c in cc.Combatants)
        {
            Debug.Log(c.gameObject.name + ": " + c.Speed);
        }

        for (int i = 0; i < 10; i++)
        {
            cc.TakeTurn();
            Debug.Log("Enemy HP: " + enemy.HP);
            cc.TakeTurn();
            Debug.Log("Player HP: " + player.HP);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
