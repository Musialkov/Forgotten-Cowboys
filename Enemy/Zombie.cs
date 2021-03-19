using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    float distanceToPlayer = Mathf.Infinity;
    EnemyHealth enemyHealth;
    Enemy enemy;
    NavMeshAgent navMeshAgent;
    Animator animator;
   
    void Start()
    {
        enemy = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        
    }
    void Update()
    {
        distanceToPlayer = Vector3.Distance(enemy.target.position, transform.position);

        if (enemy.isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToPlayer < enemy.distanceRange)
        {
            enemy.isProvoked = true;
        }
    }
    private void EngageTarget()
    {
        if (!enemyHealth.isDead)
        {
            enemy.FaceTarget();
        }
        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

        if (distanceToPlayer >= navMeshAgent.stoppingDistance && !enemyHealth.isDead)
        {
            ChaseTarget();
        }

    }
    private void AttackTarget()
    {
        animator.SetBool("attack", true);      
    }

    private void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(enemy.target.position);
    }
 

}
