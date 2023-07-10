using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enchantment : MonoBehaviour
{
    private string Name;

    public Enchantment(string name)
    {
        Name = name;
    }

}
