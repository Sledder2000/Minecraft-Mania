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
    private Button RetreatButton;
    public float AttackDelayTimer { get; private set; }
    private TMPro.TMP_Text BattleInfoText;
    private const float ATTACK_DELAY = 0.8f;
    //private bool PlayerTargeting = false;

    // Start is called before the first frame update
    void Start()
    {
        CUI = GameObject.Find("CombatUIController").GetComponent<CombatUIController>();
        AttackButton = GameObject.Find("AttackButton").GetComponent<Button>();
        RetreatButton = GameObject.Find("RetreatButton").GetComponent<Button>();
        AttackDelayTimer = ATTACK_DELAY;
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
                if (EnemyClicked == null) return;

                if (AttackDelayTimer == ATTACK_DELAY)
                {
                    if (p.EquippedWeapon is Bow) {
                        BattleInfoText.text = "Attack (" + p.EquippedWeapon.GetName() + ", " + p.ArrowsToUse + " arrow";
                        if (p.ArrowsToUse == 1) { BattleInfoText.text += ")"; }
                        else { BattleInfoText.text += "s)"; }
                    }
                    else { BattleInfoText.text = "Attack (" + p.EquippedWeapon.GetName() + ")"; }
                    p.GetComponent<Combatant>().StartAttackAnimation();
                }


                if (AttackDelayTimer > 0)
                {
                    AttackDelayTimer -= Time.deltaTime;
                    return;
                }

                if (p.EquippedWeapon is Bow)
                {
                    if (p.ArrowsToUse == 0) return;
                    p.BowAttack(e, p.ArrowsToUse);
                } else if (p.EquippedWeapon is Sword)
                {
                    p.SwordAttack(e);
                } else if (p.EquippedWeapon is Axe)
                {
                    p.AxeAttack(e);
                } else
                {
                    p.FistAttack(e);
                }

                EnemyClicked = null;
                AttackDelayTimer = ATTACK_DELAY;
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
        InCombat = true;
        StartCoroutine(nameof(TakeTurn));
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
        StartCoroutine(nameof(TakeTurn));
    }

    private IEnumerator TakeTurn()
    {
        CUI.ChangeState(0);
        yield return new WaitForSecondsRealtime(0.4f);

        if (Combatants[TurnIndex].IsPlayer)
        {
            if (GetActivePlayer().AxeCooldown > 0) GetActivePlayer().AxeCooldown--;
            CUI.ChangeState(1);
            AttackButton.interactable = true;
            RetreatButton.interactable = true;
        }
        else
        {
            CUI.ChangeState(7);
            StartCoroutine(nameof(EnemyAttack));
        }
    }

    public bool CheckDeaths()
    {
        bool playersAlive = false;
        bool enemiesAlive = false;
        foreach (Combatant c in Combatants)
        {
            if (c.IsAlive)
            {
                if (c.IsPlayer) { playersAlive = true; }
                else { enemiesAlive = true; }
            } else
            {
                Players.Remove(c);
                Enemies.Remove(c);
                c.gameObject.SetActive(false);
            }
        }
        if (!playersAlive)
        {
            EndCombat(false);
        } else if (!enemiesAlive)
        {
            EndCombat(true);
        }
        return true;
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


    private IEnumerator EnemyAttack()
    {
        Enemy e = Combatants[TurnIndex].gameObject.GetComponent<Enemy>();
        e.ChooseAttack();
        e.GetComponent<Combatant>().StartAttackAnimation();
        BattleInfoText.text = e.CurrentAttackText;
        while (AttackDelayTimer > 0)
        {
            AttackDelayTimer -= Time.deltaTime;
            yield return null;
        }
        e.Attack();
        AttackDelayTimer = ATTACK_DELAY;
        yield return new WaitUntil(() => e.AttackFinished);
        yield return new WaitUntil(CheckDeaths);
        if (InCombat) { NextTurn(); }
    }

    public void Retreat()
    {
        if (GetActivePlayer() != null) {
            CUI.ChangeState(8);
            StartCoroutine(nameof(RetreatAnimation));
        }
    }

    private IEnumerator RetreatAnimation()
    {
        yield return new WaitForSeconds(1);
        if (Random.Range(1, 20) >= 10 + MaxEnemySpeed() - Combatants[TurnIndex].Speed)
        {
            BattleInfoText.text = "You successfully retreated!";
            yield return new WaitForSeconds(1);
            EndCombat(true); // if you run away you dont get loot
            yield break;
        } else
        {
            BattleInfoText.text = "You couldn't get away!";
            yield return new WaitForSeconds(1);
        }
        CUI.ChangeState(1);
    }

    private int MaxEnemySpeed()
    {
        int maxSpeed = 0;
        foreach (Combatant c in Enemies)
        {
            maxSpeed = Mathf.Max(maxSpeed, c.Speed);
        }
        return maxSpeed;
    }

    public void ShowHealthbars(bool enabled)
    {
        foreach (Combatant c in Combatants)
        {
            c.gameObject.transform.Find("Healthbar").gameObject.SetActive(enabled);
        }
    }
}
