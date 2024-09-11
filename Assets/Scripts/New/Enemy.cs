using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    private Animator anim;
    public float animationDistanceThreshold;
    public float stopDuration;
    public float aimSpeed;
    public float dashSpeed;
    public float dashTime;  
    private bool Dashing = false;
    //private Vector3 initialPosition;
    //private Vector3 bossInitialPosition;
    public EnemyStats enemyStats;
    public HealthBar healthBar;
    //private bool playerDetection;
    public GameObject boss;





    private void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       // initialPosition = transform.position;
        //bossInitialPosition = boss.transform.position;
       // StartCoroutine(CheckPlayerPresence());



    }
    private IEnumerator StopAgent()
    {
        agent.isStopped = true; 
        yield return new WaitForSeconds(stopDuration); 
        agent.isStopped = false; 
    }
    private void Aim()
    {
        if (target == null) return;
        Quaternion rotTarget = Quaternion.LookRotation(target.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, aimSpeed * Time.deltaTime);
    }
    public void DashAttackImpulse()
    {
        StartCoroutine(Dash());
    }
    private IEnumerator Dash()
    {
        Dashing = true; 
        float dashTimer = 0f;
        agent.enabled = false;
        while (dashTimer < dashTime)
        {
            transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
            dashTimer += Time.deltaTime;
            yield return null;
        }
        agent.enabled = true;
        Dashing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            //playerDetection = true;

            Aim();  

            if (agent.velocity.magnitude > 0)
            {
                anim.SetInteger("MoveIndex", Random.Range(0, 2));
                anim.SetBool("IsMoving", true);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }

            if (Vector3.Distance(agent.destination, transform.position) <= animationDistanceThreshold)
            {
                StartCoroutine(StopAgent());
                anim.SetInteger("AttackIndex", Random.Range(0, 5));
                anim.SetTrigger("AttackTrigger");
            }

            transform.position = agent.nextPosition;
        }
       
       
      
        
    }

    /*private IEnumerator CheckPlayerPresence()
    {
        while (true)
        {
            if (!playerDetection)
            {
                agent.ResetPath();
                agent.isStopped = true; 
                anim.SetBool("IsMoving", false);
            }
            yield return new WaitForSeconds(0.1f); 
        }
    }*/



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerDetection = false;
            agent.isStopped = true;
            anim.SetBool("IsMoving", false);
        }
    }

    /*public void Respawn()
    {
        playerDetection = false;
        agent.isStopped = true;
        anim.SetBool("IsMoving", false);
        transform.position = initialPosition;
        enemyStats.currentHealth = enemyStats.maxHealth;
        healthBar.SetCurrentHealth(enemyStats.currentHealth);
        

    }*/

   /* public void RespawnBoss()
    {
        playerDetection = false;
        //boss.transform.position = initialPosition;
        enemyStats.currentHealth = enemyStats.maxHealth;
        healthBar.SetCurrentHealth(enemyStats.currentHealth);
    }*/


}




