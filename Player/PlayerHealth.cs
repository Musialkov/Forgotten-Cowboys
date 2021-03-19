using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI currentHealth;
    public DeathAndPauseHandler deathHandler;
    public bool notTouchable = false;

    private void Start()
    {
        currentHealth.text = hitPoints.ToString();
    }
    public void TakeDamage(float damage)
    {
        if(notTouchable == false)
        {
            if (hitPoints > 0)
            {
                GetComponent<DisplayDamage>().ShowDamageCanvas();
                hitPoints -= damage;
                currentHealth.text = hitPoints.ToString();
            }
            else
            {
                PlayerDead();
            }
        }
        
    }

    private void PlayerDead()
    {
        deathHandler = GetComponent<DeathAndPauseHandler>();
        deathHandler.HandleDeath();
    }
}
