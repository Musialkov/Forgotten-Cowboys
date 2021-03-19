using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoslots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int GetCurrentAmount(AmmoType ammoType)
    {
        return GetAmmoType(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoType(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoType(ammoType).ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoType(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoslots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
