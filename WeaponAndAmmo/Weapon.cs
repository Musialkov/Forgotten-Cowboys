using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] float timeToDestroyHitImpract = 1f;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI textMesh;
    AudioSource gunBum;

    public Animator anim;
    public bool canShoot = true;
    private void OnEnable()
    {
        canShoot = true;
  
    }
    private void OnDisable()
    {
        textMesh.text = "";
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        gunBum = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmount(ammoType) > 0 && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
        DisplayAmmo();
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmount(ammoType);
        textMesh.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        anim.SetBool("shoot", true);
        canShoot = false;
        gunBum.Play();
        PlayFlash();
        Raycast();
        ammoSlot.ReduceCurrentAmmo(ammoType);
        yield return new WaitForSeconds(timeBetweenShots);
        anim.SetBool("shoot", false);
        canShoot = true;
    }

    private void PlayFlash()
    {
        flash.Play();
    }

    private void Raycast()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);
        if (isHit)
        {
            Debug.Log(hit.transform.name);
            HitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void HitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, timeToDestroyHitImpract);
    }
}
