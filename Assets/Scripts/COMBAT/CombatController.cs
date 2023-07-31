using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    public bool InCombat { get; private set; } = false;
    private CombatUIController CUI;
    public List<Combatant> Combatants { get; private set; } = new();
    public List<Combatant> Players { get; private set; } = new();
    public List<Combatant> Enemies { get; private set; } = new();
    public int TurnIndex { get; private set; }
    public Combatant EnemyClicked;
    //private bool PlayerTargeting = false;

    // Start is called before the first frame update
    void Start()
    {
        CUI = GameObject.Find("CombatUIController").GetComponent<CombatUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InCombat && Combatants[TurnIndex].IsPlayer)
        {
            Player p = Combatants[TurnIndex].GetComponent<Player>();
            Inventory i = Combatants[TurnIndex].GetComponent<Inventory>();

            /*if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                p.SetArrowsToUse(1);
                Debug.Log("1 arrow");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                p.SetArrowsToUse(2);
                Debug.Log("2 arrows");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                p.SetArrowsToUse(3);
                Debug.Log("3 arrows");
            }*/

            if (CUI.State == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    EnemyClicked = null;
                    CUI.ChangeState(1);
                    ToggleEnemiesClickable(false);
                }
                Combatant e = EnemyClicked;
                if (EnemyClicked == null) { return; }

                if (p.EquippedWeapon is Bow)
                {
                    if (p.ArrowsToUse == 0) return;
                    p.BowAttack(e, p.ArrowsToUse);
                    Debug.Log("bow attack");
                } else
                {
                    p.MeleeAttack(e);
                    Debug.Log("melee attack");
                }

                Debug.Log("Enemy HP: " + e.HP);
                EnemyClicked = null;
                CUI.ChangeState(1);
                ToggleEnemiesClickable(false);
                CheckDeaths();
                NextTurn();
            } else
            {
                ToggleEnemiesClickable(true);
                //CUI.ChangeState(2);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    p.ChangeEquippedWeapon((Weapon)i.Equipment[0]);
                    Debug.Log("Fists equipped");
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    p.ChangeEquippedWeapon((Weapon)i.Equipment[2]);
                    Debug.Log("Sword equipped");

                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    p.ChangeEquippedWeapon((Weapon)i.Equipment[3]);
                    Debug.Log("Bow equipped");
                }
                else
                {
                    CUI.ChangeState(1);
                }
                EnemyClicked = null;
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
            CUI.ChangeState(0);
            Debug.Log("enemy turn");
            Combatants[TurnIndex].gameObject.GetComponent<Enemy>().Attack();
            Debug.Log("Player HP: " + Players[0].HP);
            CheckDeaths();
            if (InCombat) { NextTurn(); }
        } 
        else
        {
            CUI.ChangeState(1);
            Debug.Log("player turn");
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

    public void EndCombat(bool playerWin)
    {
        Combatants.Clear();
        Players.Clear();
        Enemies.Clear();
        InCombat = false;
    }

    private void ToggleEnemiesClickable(bool state)
    {
        foreach (Combatant enemy in Enemies)
        {
            enemy.gameObject.GetComponent<Button>().enabled = state;
        }
    }
}
