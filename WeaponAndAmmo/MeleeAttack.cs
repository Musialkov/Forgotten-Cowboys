using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    public bool notTouchable = false;
    PlayerHealth playerHealth;
    MeleeWeapon meleeWeapon;
    Animator anim;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        anim = GetComponent<Animator>();
        meleeWeapon = GetComponent<MeleeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if(Input.GetMouseButton(1))
        {
            BlockOn();
        }
        else
        {
            BlockOff();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack1");
    }
    private void BlockOn()
    {
        anim.SetBool("block", true);
        playerHealth.notTouchable = true;
    }
    private void BlockOff()
    {
        anim.SetBool("block", false);
        playerHealth.notTouchable = false;
    }

    private void MakeDamage()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, meleeWeapon.range);
        if (isHit)
        {
            Debug.Log(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(meleeWeapon.damage);
        }
        else
        {
            return;
        }
    }
}
