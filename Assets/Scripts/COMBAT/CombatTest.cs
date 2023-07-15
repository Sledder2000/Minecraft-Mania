using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CombatController cc = GameObject.Find("CombatController").GetComponent<CombatController>();
        GameObject player = GameObject.Find("Player");
        GameObject enemy1 = GameObject.Find("Enemy");
        GameObject enemy2 = GameObject.Find("Enemy2");

        player.GetComponent<Combatant>().SetSpeed(10);
        enemy1.GetComponent<Combatant>().SetSpeed(10);
        enemy2.GetComponent<Combatant>().SetSpeed(15);

        player.GetComponent<Combatant>().IsPlayer = true;
        enemy1.GetComponent<Combatant>().IsPlayer = false;
        enemy2.GetComponent<Combatant>().IsPlayer = false;

        List<Player> ps = new();
        List<Enemy> es = new();
        List<Combatant> cs = new();

        ps.Add(player.GetComponent<Player>());
        es.Add(enemy1.GetComponent<Enemy>());
        es.Add(enemy2.GetComponent<Enemy>());

        cs.Add(player.GetComponent<Combatant>());
        cs.Add(enemy1.GetComponent<Combatant>());
        cs.Add(enemy2.GetComponent<Combatant>());

        cc.BeginCombat(ps, es);

        foreach (Combatant c in cc.Combatants)
        {
            Debug.Log(c.gameObject.name + ": " + c.Speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
