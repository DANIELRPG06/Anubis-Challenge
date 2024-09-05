using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public GameObject avisoDeInteracao;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject death; 
    private bool gameOver = false;
    public TextMeshProUGUI pocoes;
    private int contagemPocoes;
    public int cura;
    public GameObject sword;
    public NewDash newDash;
   
   
    


    void Start()
    {
        avisoDeInteracao.SetActive(false);
        contagemPocoes = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }
    private void Update()
    {
        
        pocoes.text = contagemPocoes.ToString();
        if(contagemPocoes > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            contagemPocoes = contagemPocoes - 1;
            currentHealth = currentHealth + cura;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetCurrentHealth(currentHealth);
        }

        
        
    }

    public void TakeDammage(int dammage)
    {
        currentHealth = currentHealth - dammage;

        healthBar.SetCurrentHealth(currentHealth);

        
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameOver = true;

                
                Time.timeScale = 0f;


               death.SetActive(true);

             
            }
            
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pocao"))
        {
            avisoDeInteracao.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                contagemPocoes = contagemPocoes + 1;
                avisoDeInteracao.SetActive(false);
                Destroy(other.gameObject);
            }
        }
       

        if (other.gameObject.CompareTag("Documento"))
        {
            avisoDeInteracao.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                
                avisoDeInteracao.SetActive(false);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Tumba"))
        {
            avisoDeInteracao.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                newDash.enabled = true;
                sword.SetActive(true);
                avisoDeInteracao.SetActive(false);
                
            }
        }


    }

    






    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Pocao"))
        {
            avisoDeInteracao.SetActive(false);
        }

        if (other.gameObject.CompareTag("Documento"))
        {
            avisoDeInteracao.SetActive(false);
        }

        if (other.gameObject.CompareTag("Tumba"))
        {
            avisoDeInteracao.SetActive(false);
        }

    }
}
