using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public Zombie()
    {
        Name = "Zombie";
        XPDropped = 1;
    }

    public override void Attack()
    {
        int rng = Random.Range(1, 100);
        if (rng <= 60)
        {
            Punch();
        } else
        {
            DrainingBite();
        }
    }

    private void Punch()
    {
        DealTrueDamage(8, GetRandomTarget());
        Debug.Log("Punch");
    }

    private void DrainingBite()
    {
        DealTrueDamage(6, GetRandomTarget());
        gameObject.GetComponent<Combatant>().Heal(6);
        Debug.Log("Draining Bite");
    }
}
