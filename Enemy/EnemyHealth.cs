using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator animator;
    public bool isDead = false;
    
     private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamage");
        if (hitPoints <= 0)
            Dead();
        else
        {
            animator.SetTrigger("shoot");
            hitPoints -= damage;
        }
    }

    private void Dead()
    {
        isDead = true;
        animator.SetTrigger("dead");
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Enemy>().enabled = false;
        if(gameObject.tag == "Boss")
            BroadcastMessage("ChangeStateAfterBossDead");
    }
}
