using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;
    [SerializeField] int meleeIndex = 3;
    Weapon weapon;

    void Start()
    {
        SetWeaponActive();
        weapon = FindObjectOfType<Weapon>();
    }

    void Update()
    {
        int previousWeapon = currentWeaponIndex;

        CheckKeyAndScroolInput();

        if (previousWeapon != currentWeaponIndex)
        {
            SetWeaponActive();
            if (currentWeaponIndex != meleeIndex)
                weapon = FindObjectOfType<Weapon>();
            else
                weapon = null;
        }
    }

    private void CheckKeyAndScroolInput()
    {
        if (currentWeaponIndex != meleeIndex)
        {
            if (weapon.canShoot == true)
            {
                CheckKeyInput();
                CheckScrollInput();
            }
        }
        else
        {
            CheckKeyInput();
            CheckScrollInput();
        }
    }

    private void CheckScrollInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0 && GetZoomed(currentWeaponIndex) == false)
        {
            if(currentWeaponIndex >= transform.childCount - 1)
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && GetZoomed(currentWeaponIndex) == false)
        {
            if(currentWeaponIndex <= 0)
            {
                currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currentWeaponIndex--;
            }
        }
    }

    private void CheckKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && GetZoomed(currentWeaponIndex) == false)
            currentWeaponIndex = 0;
    
        if (Input.GetKeyDown(KeyCode.Alpha2) && GetZoomed(currentWeaponIndex) == false)
            currentWeaponIndex = 1;
      
        if (Input.GetKeyDown(KeyCode.Alpha3) && GetZoomed(currentWeaponIndex) == false)
            currentWeaponIndex = 2;

        if (Input.GetKeyDown(KeyCode.Alpha4) && GetZoomed(currentWeaponIndex) == false)
            currentWeaponIndex = 3;     
    }

    private bool GetZoomed(int index)
    {
        if(index == transform.childCount - 1)
        {
            return false;
        }
        return transform.GetChild(index).GetComponent<WeaponZoom>().zoomed;
    }
    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
