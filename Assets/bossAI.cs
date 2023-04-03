using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public AudioClip BOSS;

    public float timeBetweenAttack = 1f;
    public bool alreadyAttacked = false;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator anim;
    private AudioSource audioSource;
    public AudioClip thud;
    public GameObject terrain;
    DamageHandler dh;
    CameraShake cs;
    private void Awake()
    {
        player = GameObject.Find("Mc").transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource=GetComponent<AudioSource>();
        cs= terrain.GetComponent<CameraShake>();
        PlayThud();
        dh=GetComponent<DamageHandler>();
        

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (playerInSightRange && !playerInAttackRange&&!dh.isdying)
        {
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange &&!dh.isdying)
        {
            AttackPlayer();
        }

        if (!playerInSightRange && !playerInAttackRange&&!dh.isdying)
        {
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        anim.Play("Fast Run");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttack);
            // Attack code here
            string[] attacks = { "Mutant Punch", "Mutant Jumping" };
        string attackToPlay = attacks[Random.Range(0, attacks.Length)];
        anim.Play(attackToPlay);
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
        audioSource.clip=BOSS;
        audioSource.Play();

    }

    void Rumble(){
        cs.shake(1f);
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