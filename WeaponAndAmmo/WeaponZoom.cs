using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera; 
    [SerializeField] float mouseSensivityOut = 2f;
    [SerializeField] float mouseSensivityIn = 1f;
    [SerializeField] float timeBetweenZoom = 0.5f;

    public float zoomedOutFOV = 60f;
    public float zoomedInFOV = 20f;
    public bool zoomed = false;
    public bool canChangeZoom = true;

    FirstPersonController fpsController;
    Animator animator;
    

    private void OnDisable()
    {
        zoomed = false;
        canChangeZoom = true;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        fpsController = GetComponentInParent<FirstPersonController>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (zoomed == false && canChangeZoom == true)
            {
                StartCoroutine(ZoomIn());
            }
            if(zoomed == true && canChangeZoom == true)
            {
                StartCoroutine(ZoomOut());
            }
        }
    }

   IEnumerator ZoomOut()
    {
        canChangeZoom = false;
        zoomed = false;
        animator.SetBool("zoomed", zoomed);
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.ChangeMouseSensitivity(mouseSensivityOut, mouseSensivityOut);
        yield return new WaitForSeconds(timeBetweenZoom);
        canChangeZoom = true;
    }

    IEnumerator ZoomIn()
    {
        canChangeZoom = false;
        zoomed = true;
        animator.SetBool("zoomed", zoomed);   
        fpsCamera.fieldOfView = zoomedInFOV;          
        fpsController.ChangeMouseSensitivity(mouseSensivityIn, mouseSensivityIn);
        yield return new WaitForSeconds(timeBetweenZoom);
        canChangeZoom = true;
    }

    

}
