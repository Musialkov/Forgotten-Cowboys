using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float distanceRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    AudioSource audio;

    public bool isProvoked = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnDamage()
    {
        isProvoked = true;
    }

    public void FaceTarget()
    {
        Vector3 directon = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceRange);
    }
    public void PlaySound(AudioClip audioClip)
    {
        audio.Stop();
        audio.clip = audioClip;
        audio.Play();
    }

}
