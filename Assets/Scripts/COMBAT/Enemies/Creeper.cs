using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creeper : Enemy
{

    private int ChargeLevel; // if this reaches 3, kaboom

    public Creeper()
    {
        Name = "Creeper";
        XPDropped = 1;
        ChargeLevel = 0;
    }

    private void Awake()
    {
        StartCoroutine(nameof(Flash));
    }

    public override void ChooseAttack()
    {
        int rng = Random.Range(1, 100);
        if (rng <= 55)
        {
            if (ChargeLevel < 2)
            {
                CurrentAttack = nameof(ChargeUp);
                CurrentAttackText = "Charge Up";
            }
            else
            {
                CurrentAttack = nameof(Explode);
                CurrentAttackText = "Explode";
            }
        }
        else
        {
            CurrentAttack = nameof(Headbutt);
            CurrentAttackText = "Headbutt";
        }
    }


    private void Headbutt()
    {
        DealTrueDamage(7, GetRandomTarget());
        AttackFinished = true;
    }

    private void ChargeUp()
    {
        ChargeLevel++;
        AttackFinished = true;
    }

    private void Explode()
    {
        DealTrueDamage(40, GetAllTargets());
        GetComponent<Combatant>().IsAlive = false;
        AttackFinished = true;
    }

    IEnumerator Flash()
    {
        Color color = Color.white;
        while (GetComponent<Combatant>().IsAlive)
        {
            while (ChargeLevel == 0) { yield return null; }
            for (int i = 0; i < 20; i++)
            {
                if (i < 10) 
                { 
                    color.g -= 0.07f;
                    color.b -= 0.07f;
                }
                else 
                { 
                    color.g += 0.07f;
                    color.b += 0.07f;
                }
                gameObject.GetComponent<SpriteRenderer>().color = color;
                yield return new WaitForSecondsRealtime(0.1f / ChargeLevel);
            }
        }
    }
}
