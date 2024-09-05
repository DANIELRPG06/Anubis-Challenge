using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject win;
    private bool gameOver = false;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        

    }

    public void MakeDammage(int dammage)
    {
        currentHealth = currentHealth - dammage;

        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameOver = true;


            Time.timeScale = 0f;


            win.SetActive(true);
        }


    }

     
    
    
}