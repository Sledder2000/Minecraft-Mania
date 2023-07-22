using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private CombatController CC;
    public int XPDropped { get; protected set; }
    public string Name { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Attack();

    public void DealTrueDamage(int damage, Combatant target)
    {
        target.TakeTrueDamage(damage);
    }

    public Combatant GetRandomTarget()
    {
        return CC.Players[Random.Range(0, CC.Players.Count)];
    }
}
