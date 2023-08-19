using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    private CombatController CC;
    public int XPDropped { get; protected set; }
    public string Name { get; protected set; }

    public bool Clickable = false;

    public string CurrentAttack { get; protected set; }
    public string CurrentAttackText { get; protected set; }


    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ChooseAttack();
    public void Attack()
    {
        Invoke(CurrentAttack, 0);
    }

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }

    public Combatant GetRandomTarget()
    {
        return CC.Players[Random.Range(0, CC.Players.Count)];
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
