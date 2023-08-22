using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    private CombatController CC;
    public int XPDropped { get; protected set; }
    public string Name { get; protected set; }

    public bool Clickable = false;

    public bool AttackFinished { get; protected set; }
    public string CurrentAttack { get; protected set; }
    public string CurrentAttackText { get; protected set; }


    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();
        Debug.Log(CC);
        AttackFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ChooseAttack();
    public void Attack()
    {
        AttackFinished = false;
        Invoke(CurrentAttack, 0);
    }

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }

    public void DealTrueDamage(int damage, List<Combatant> targets)
    {
        foreach (Combatant target in targets)
        {
            target.TakeTrueDamage(damage);
        }
    }

    public Combatant GetRandomTarget()
    {
        Debug.Log(CC);
        return CC.Players[Random.Range(0, CC.Players.Count)];
    }
    public List<Combatant> GetAllPlayers()
    {
        return CC.Players;
    }
    public List<Combatant> GetAllTargets()
    {
        return CC.Players.Concat(CC.Enemies).ToList();
    }

    public void UpdateClickedEnemy()
    {
        CC.EnemyClicked = gameObject.GetComponent<Combatant>();
    }

    private void OnMouseDown()
    {
        if (Clickable) { CC.EnemyClicked = gameObject.GetComponent<Combatant>(); }
    }
}
