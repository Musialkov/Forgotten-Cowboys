using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    ShowDistantMessage showMessage;

    private void Start()
    {
        showMessage = GetComponent<ShowDistantMessage>();
    }
    private void Update()
    {
        PickupAmmo();
    }

    private void PickupAmmo()
    {
        if (Input.GetKeyDown(KeyCode.F) && showMessage.targetSeeMessage)
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
