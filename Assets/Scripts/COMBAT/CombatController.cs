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
    private Button AttackButton;
    public float AttackDelayTimer { get; private set; }
    private TMPro.TMP_Text BattleInfoText;
    //private bool PlayerTargeting = false;

    // Start is called before the first frame update
    void Start()
    {
        CUI = GameObject.Find("CombatUIController").GetComponent<CombatUIController>();
        AttackButton = GameObject.Find("AttackButton").GetComponent<Button>();
        AttackDelayTimer = 1.5f;
        BattleInfoText = GameObject.Find("BattleInfoText").GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InCombat && Combatants[TurnIndex].IsPlayer)
        {
            Player p = Combatants[TurnIndex].GetComponent<Player>();

            if (CUI.State == 2)
            {
                ToggleEnemiesClickable(true);
                Combatant e = EnemyClicked;
                if (EnemyClicked == null) { return; }

                if (p.EquippedWeapon is Bow) { BattleInfoText.text = "Attack (" + p.EquippedWeapon.GetName() + ", " + p.ArrowsToUse + " arrows)"; }
                else { BattleInfoText.text = "Attack (" + p.EquippedWeapon.GetName() + ")"; }

                if (AttackDelayTimer > 0)
                {
                    AttackDelayTimer -= Time.deltaTime;
                    return;
                }

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
                AttackDelayTimer = 1.5f;
                CUI.ChangeState(1);
                ToggleEnemiesClickable(false);
                CheckDeaths();
                AttackButton.interactable = false;
            } else
            {
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
        }
        Combatants.Sort();
        TurnIndex = 0;
        ToggleEnemiesClickable(false);
        TakeTurn();
    } 

    public void NextTurn()
    {
        if (!InCombat) { return; }
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
            CUI.ChangeState(7);
            Debug.Log("enemy turn");
            StartCoroutine(nameof(EnemyAttack));
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
        CUI.ChangeState(0);
    }

    private void ToggleEnemiesClickable(bool state)
    {
        foreach (Combatant enemy in Enemies)
        {
            enemy.gameObject.GetComponent<Enemy>().Clickable = state;
        }
    }

    public Player GetActivePlayer()
    {
        if (Combatants[TurnIndex].IsPlayer) { return Combatants[TurnIndex].gameObject.GetComponent<Player>(); }
        return null;
    }

    public void SetAttackDelay(float delay)
    {
        if (delay < 0) { return; }
        AttackDelayTimer = delay;
    }

    private IEnumerator EnemyAttack()
    {
        Enemy e = Combatants[TurnIndex].gameObject.GetComponent<Enemy>();
        e.ChooseAttack();
        BattleInfoText.text = e.CurrentAttackText;
        while (AttackDelayTimer > 0)
        {
            AttackDelayTimer -= Time.deltaTime;
            yield return null;
        }
        e.Attack();
        Debug.Log("Player HP: " + Players[0].HP);
        CheckDeaths();
        AttackButton.interactable = true;
        AttackDelayTimer = 1.5f;
        if (InCombat) { NextTurn(); }
    }
}
