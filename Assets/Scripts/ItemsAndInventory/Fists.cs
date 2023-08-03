using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Weapon
{
    public Fists() : base("Fists", GameObject.Find("ItemSprites").GetComponent<ItemSprites>().Fists, 99999999)
    {
        Damage = 5;
    }
}
