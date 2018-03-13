using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionType : IComparable<PotionType> {


    public string name;
    public string effectType;
    public int lootValue;
    public int effectPower;

    public PotionType(string newName, string newEffectType, int newLootValue, int newEffectPower  )
    {
        name = newName;
        effectType = newEffectType;
        lootValue = newLootValue;
        effectPower = newEffectPower;
    }

    public int CompareTo(PotionType other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return lootValue - other.lootValue;
    }
}
