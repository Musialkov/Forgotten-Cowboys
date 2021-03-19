using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] StoryLine story;

    float distanceToPlayer = Mathf.Infinity;
    EnemyHealth enemyHealth;
    Enemy enemyAi;
    NavMeshAgent navMeshAgent;
    Animator animator;
    bool duringAttack = false;
    void Start()
    {
        enemyAi = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(enemyAi.target.position, transform.position);

        if (enemyAi.isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToPlayer < enemyAi.distanceRange)
        {
            enemyAi.isProvoked = true;
        }
    }



    private void EngageTarget()
    {
        if(!enemyHealth.isDead)
        {
            enemyAi.FaceTarget();
        }
            
        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
            if(!duringAttack)
               StartCoroutine(ChooseAttack()); 
        }

        if (distanceToPlayer >= navMeshAgent.stoppingDistance && !enemyHealth.isDead)
        {
            ChaseTarget();
        }

    }

    IEnumerator ChooseAttack()
    {
        duringAttack = true;
        int choice = UnityEngine.Random.Range(0, 3);
        float waitTime = 1f;
        switch(choice)
        {
            case 0:
                animator.SetTrigger("atack_1");
                break;
            case 1:
                animator.SetTrigger("atack_2");
                break;
            case 2:
                animator.SetTrigger("atack_3");
                break;
        }
        yield return new WaitForSeconds(waitTime);
        duringAttack = false;
    }

    private void AttackTarget()
    {
        animator.SetBool("atack", true);
    }

    private void ChaseTarget()
    {
        animator.SetBool("atack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(enemyAi.target.position);
    }

    public void ChangeStateAfterBossDead()
    {
        story.AfterBossDead();
    }
}