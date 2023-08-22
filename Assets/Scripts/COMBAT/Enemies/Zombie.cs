using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Enemy
{
    public Zombie()
    {
        Name = "Zombie";
        XPDropped = 1;
    }

    public override void ChooseAttack()
    {
        int rng = Random.Range(1, 100);
        if (rng <= 60)
        {
            CurrentAttack = nameof(Punch);
            CurrentAttackText = "Punch";
        }
        else
        {
            CurrentAttack = nameof(DrainingBite);
            CurrentAttackText = "Draining Bite";
        }
    }


    private void Punch()
    {
        DealTrueDamage(8, GetRandomTarget());
    }

    private void DrainingBite()
    {
        DealTrueDamage(6, GetRandomTarget());
        gameObject.GetComponent<Combatant>().Heal(6);
    }
}
