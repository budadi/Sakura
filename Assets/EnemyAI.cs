using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    public float timeBetweenAttack = 1f;
    public bool alreadyAttacked = false;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator anim;
    private AudioSource audioSource;
    public AudioClip thud;
    public GameObject terrain;

    CameraShake cs;
    private void Awake()
    {
        player = GameObject.Find("Mc").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource=GetComponent<AudioSource>();
        cs= terrain.GetComponent<CameraShake>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        if (!playerInSightRange && !playerInAttackRange)
        {
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        anim.SetBool("isWalk", true);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        anim.SetBool("isWalk", false);
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttack);
            // Attack code here
            anim.Play("EnemyAttack1");
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void StopChasingPlayer()
    {
        anim.SetBool("isWalk", false);
        agent.SetDestination(transform.position);
    }

    void PlayThud(){
        audioSource.clip=thud;
        audioSource.Play();

    }

    void Rumble(){
        cs.shake(0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopChasingPlayer();
        }
    }
}