using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

public class EnemyStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject inimigo;
    public Enemy enemy;
    public Animator animator;
    public NavMeshAgent agent;
    private bool death;
    //public GameObject win;
    //private bool gameOver = false;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //enemy = GetComponent<Enemy>();
        death = false;
        

    }

    private void Update()
    {
        if (death)
        {
            agent.isStopped = true;
            

        }
    }

    public void MakeDammage(int dammage)
    {
        currentHealth = currentHealth - dammage;

        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(inimigo);



            animator.SetTrigger("BossDeath");
            death = true;
            enemy.aimSpeed = 0;
           





        }


    }

     
    
    
}