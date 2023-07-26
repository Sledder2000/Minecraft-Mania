using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    public bool InCombat { get; private set; } = false;
    public List<Combatant> Combatants { get; private set; } = new();
    public List<Combatant> Players { get; private set; } = new();
    public List<Combatant> Enemies { get; private set; } = new();
    public int TurnIndex { get; private set; }
    public Combatant EnemyClicked;
    private bool PlayerTargeting = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InCombat && Combatants[TurnIndex].IsPlayer)
        {
            if (PlayerTargeting)
            {
                Combatant e = EnemyClicked;
                if (EnemyClicked == null) { return; }

                Player p = Combatants[TurnIndex].GetComponent<Player>();
                Inventory i = Combatants[TurnIndex].GetComponent<Inventory>();

                Debug.Log("player attacking");

                if (p.AttackWithSword((Sword)i.Equipment[0], e))
                {
                    Debug.Log("Attacking with sword");
                }
                else
                {
                    Debug.Log("Sword durability gone");
                    if (p.AttackWithBow((Bow)i.Equipment[1], e, 1))
                    {
                        Debug.Log("Attacking with bow");
                    }
                    else
                    {
                        Debug.Log("No arrows left");
                    }
                }
                Debug.Log("Enemy HP: " + e.HP);
                EnemyClicked = null;
                CheckDeaths();
                NextTurn();
            } else
            {
                // choose actions
            }
        }
    }

    public void BeginCombat(List<Combatant> players, List<Combatant> enemies)
    {
        InCombat = true;
        Players = players;
        Enemies = enemies;
        foreach (Combatant p in players)
        {
            Combatants.Add(p);
        }
        foreach (Combatant e in enemies)
        {
            Combatants.Add(e);
            //e.gameObject.GetComponent<Button>().onClick.AddListener(UpdateEnemyClicked);
        }
        Combatants.Sort();
        TurnIndex = 0;
        TakeTurn();
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
        TakeTurn();
    }

    public void TakeTurn()
    {
        if (!Combatants[TurnIndex].IsPlayer) 
        {
            Combatants[TurnIndex].gameObject.GetComponent<Enemy>().Attack();
            Debug.Log("Player HP: " + Players[0].HP);
            CheckDeaths();
            if (InCombat) { NextTurn(); }
        }
    }

    public void CheckDeaths()
    {
        bool playersAlive = false;
        bool enemiesAlive = false;
        foreach (Combatant c in Combatants)
        {
            if (c.IsAlive)
            {
                if (c.IsPlayer) { playersAlive = true; }
                else { enemiesAlive = true; }
            }
        }
        if (!playersAlive)
        {
            EndCombat(false);
        } else if (!enemiesAlive)
        {
            EndCombat(true);
        }
    }

    public void EndCombat(bool PlayerWin)
    {
        Combatants.Clear();
        Players.Clear();
        Enemies.Clear();
        InCombat = false;
    }
}
