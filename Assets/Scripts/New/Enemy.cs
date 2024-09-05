using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    public float animationDistanceThreshold;
    public float stopDuration;
    public float aimSpeed;
    public float dashSpeed;
    public float dashTime;  
    private bool Dashing = false;
   

    private void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private IEnumerator StopAgent()
    {
        agent.isStopped = true; 
        yield return new WaitForSeconds(stopDuration); 
        agent.isStopped = false; 
    }
    private void Aim()
    {
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
            agent.SetDestination(target.position);
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
}
