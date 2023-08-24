using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : Enemy
{
    public Skeleton()
    {
        Name = "Skeleton";
        XPDropped = 1;
    }

    public override void ChooseAttack()
    {
        int rng = Random.Range(1, 100);
        if (rng <= 65)
        {
            CurrentAttack = nameof(Snipe);
            CurrentAttackText = "Snipe";
        }
        else
        {
            CurrentAttack = nameof(TripleShot);
            CurrentAttackText = "Triple Shot";
        }
    }


    private void Snipe()
    {
        DealTrueDamage(9, GetRandomTarget());
        AttackFinished = true;
    }

    private void TripleShot()
    {
        StartCoroutine(nameof(TripleShotRoutine));
    }

    IEnumerator TripleShotRoutine()
    {
        Combatant target = GetRandomTarget();
        for (int i = 0; i < 3; i++)
        {
            DealTrueDamage(5, target);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        AttackFinished = true;
    }
}
