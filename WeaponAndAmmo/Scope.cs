using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    [SerializeField] Canvas scope;
    [SerializeField] Canvas cross;
    [SerializeField] Camera fpsCamera;
    [SerializeField] DeathAndPauseHandler deathHandler;
    [SerializeField] float timeOfScopinIn = 0.5f;
    [SerializeField] float scopeFOV = 20f;

    WeaponZoom weaponZoom;
    Weapon weapon;
    bool isChanigingZoom = false;

    void Start()
    {
        weaponZoom = GetComponent<WeaponZoom>();
        weapon= GetComponent<Weapon>();
    }

    
    void Update()
    {
        
       if (weaponZoom.zoomed == true && weaponZoom.canChangeZoom == false && !isChanigingZoom)
       {
          StartCoroutine(ActivateScope());
       }
            
       if (weaponZoom.zoomed == false && weaponZoom.canChangeZoom == false && !isChanigingZoom)
       {
          DisableScope();
       }
    }

    private void DisableScope()
    {
        isChanigingZoom = true;
        fpsCamera.fieldOfView = weaponZoom.zoomedOutFOV;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        scope.enabled = false;
        cross.enabled = true;
        weapon.anim.SetBool("shoot", false);
        isChanigingZoom = false;
        Debug.Log("Dezaktywacja");
    }

    IEnumerator ActivateScope()
    {
        isChanigingZoom = true;
        yield return new WaitForSeconds(timeOfScopinIn);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        scope.enabled = true;
        cross.enabled = false;
        fpsCamera.fieldOfView = scopeFOV;
        isChanigingZoom = false;
        Debug.Log("aktywacja");
    }
}
