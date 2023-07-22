using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public List<Combatant> Combatants { get; private set; } = new();
    public List<Combatant> Players { get; private set; } = new();
    public List<Combatant> Enemies { get; private set; } = new();
    public int TurnIndex { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginCombat(List<Combatant> players, List<Combatant> enemies)
    {
        Players = players;
        Enemies = enemies;
        foreach (Combatant p in players)
        {
            Combatants.Add(p);
        }
        foreach (Combatant e in enemies)
        {
            Combatants.Add(e);
        }
        Combatants.Sort();
        TurnIndex = 0;

    }

    private void NextTurn()
    {
        do
        {
            if (TurnIndex == Combatants.Count - 1)
            {
                TurnIndex = -1;
            }
            TurnIndex++;
        }
        while (!Combatants[TurnIndex].IsAlive);
    }

    public void TakeTurn()
    {

        if (Combatants[TurnIndex].IsPlayer)
        {
            Player p = Combatants[TurnIndex].GetComponent<Player>();
            Inventory i = Combatants[TurnIndex].GetComponent<Inventory>();
            Combatant e = Combatants[TurnIndex + 1];
            if (p.AttackWithSword((Sword)i.Equipment[0], e))
            {
                Debug.Log("Attacking with sword");
            } else
            {
                Debug.Log("Sword durability gone");
                if (p.AttackWithBow((Bow)i.Equipment[1], e, 1))
                {
                    Debug.Log("Attacking with bow");
                } else
                {
                    Debug.Log("No arrows left");
                }

            }
        } 
        else
        {
            Combatants[TurnIndex].gameObject.GetComponent<Enemy>().Attack();
        }
        NextTurn();
    }
}
