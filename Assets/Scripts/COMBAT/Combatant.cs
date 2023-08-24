using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour, IComparable {
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int XP { get; private set; } = 0;
    public int Speed { get; private set; } = 10;
    public bool IsPlayer; //{ get; private set; }
    public bool IsAlive /*{ get; private set; }*/ = true;
    public bool ActionTaken { get; private set; } = true;
    public Healthbar HPBar;
    private DamageIndicatorManager DIM;
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        HPBar = gameObject.transform.Find("Healthbar").GetComponent<Healthbar>();
        if (gameObject.GetComponent<Player>() == null)
        {
            IsPlayer = false;
        }
        else
        {
            IsPlayer = true;
        }
        DIM = GameObject.Find("DamageIndicatorManager").GetComponent<DamageIndicatorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHP(int value)
    {
        if (value > 0)
        {
            MaxHP = value;
            HP = MaxHP; // might have to change later
            HPBar.UpdateHealthbar();
        }
    }

    public void SetSpeed(int value)
    {
        if (value > 0)
        {
            Speed = value;
        }
    }

    public void ChangeXP(int amount)
    {
        XP += amount;
    }

    public void TakePhysicalDamage(int damage)
    {
        
    }

    public void TakeMagicDamage(int damage)
    {

    }

    public void TakeImpactDamage(int damage)
    {

    }

    public void TakeTrueDamage(int damage)
    {
        if (damage > 0)
        {
            HP = Mathf.Max(0, HP - damage);
        }
        if (HP <= 0)
        {
            Debug.Log("DEAD");
            IsAlive = false;
            gameObject.SetActive(false);
        }
        HPBar.UpdateHealthbar();
        DIM.IndicateDamage(damage, gameObject.transform.position, false);
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            HP = Mathf.Min(MaxHP, HP + amount);
            HPBar.UpdateHealthbar();
        }
        DIM.IndicateDamage(amount, gameObject.transform.position, true);
    }

    public int CompareTo(object other)
    {
        if (other == null || !(other is Combatant))
        {
            return 0;
        }
        Combatant otherCombatant = (Combatant)other;
        if (this.Speed == otherCombatant.Speed)
        {
            if (this.IsPlayer && !otherCombatant.IsPlayer) { return -1; }
            if (otherCombatant.IsPlayer && !this.IsPlayer) { return 1; }
        }
        return otherCombatant.Speed - this.Speed;
    }


    public void StartAttackAnimation()
    {
        StartCoroutine(nameof(AttackAnimation));
    }
    private IEnumerator AttackAnimation()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 newPos = new(pos.x, pos.y + 5, 0);
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                gameObject.transform.position = newPos;
            } else
            {
                gameObject.transform.position = pos;
            }
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
