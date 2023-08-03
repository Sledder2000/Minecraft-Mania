using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int BaseDmgReduction;
    private double PercentDmgReduction;

    public Armor(string name, Sprite icon, int durability, int bdr, double pdr) : base(name, icon, durability)
    {
        BaseDmgReduction = bdr;
        PercentDmgReduction = pdr;
    }

    public int getBaseDmgReduction()
    {
        return BaseDmgReduction;
    }

    public double getPercentDmgReduction()
    {
        return PercentDmgReduction;
    }
}
