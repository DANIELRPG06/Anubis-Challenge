using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class PlayerStats : MonoBehaviour
{
    public GameObject avisoDeInteracao;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject death; 
    //private bool gameOver = false;
    public TextMeshProUGUI pocoes;
    private int contagemPocoes;
    public int cura;
    public GameObject sword;
    public NewDash newDash;
    public GameObject respawnOne;
    public GameObject respawnTwo;
    public Boss_Door bossDoor;
    //CharacterController characterController;
    public Enemy enemy;
    public Button introButton;
    public GameObject bau;
    public GameObject notificacao;
    public float tempoAtivo;
    private Collider tumbaCollider;








    void Start()
    {
        bau.SetActive(false);
        introButton.interactable = false;
        avisoDeInteracao.SetActive(false);
        contagemPocoes = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        notificacao.SetActive(false);
        //characterController = GetComponent<CharacterController>();
       
        
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



       // if (bossDoor.todosMortos && currentHealth <= 0)
       // {
            //respawnTwof();
            //enemy.RespawnBoss();
        //}
        if (currentHealth <= 0)
        {
            RestartLevel();


        }

           
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            RestartLevel();
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
                StartCoroutine(AtivarDesativar());
            }
        }

        if (other.gameObject.CompareTag("Tumba"))
        {
            avisoDeInteracao.SetActive(true);
            tumbaCollider = other;

            if (Input.GetKey(KeyCode.E))
            {
                newDash.enabled = true;
                sword.SetActive(true);
                avisoDeInteracao.SetActive(false);
                introButton.interactable = true;
                bau.SetActive(true);
                StartCoroutine(AtivarDesativar());
                Physics.IgnoreCollision(tumbaCollider, GetComponent<Collider>());


            }
        }

        


    }

    private IEnumerator AtivarDesativar()
    {
        
        notificacao.SetActive(true);
        yield return new WaitForSeconds(tempoAtivo);
        notificacao.SetActive(false);
    }


    /*public void respawnOnef()
    {
         characterController.enabled = false;
         gameObject.transform.position = respawnOne.transform.position;
         currentHealth = maxHealth;
         healthBar.SetCurrentHealth(currentHealth);
         characterController.enabled = true;


    }

     public void respawnTwof()
     {
         characterController.enabled = false;
         gameObject.transform.position = respawnTwo.transform.position;
         currentHealth = maxHealth;
         healthBar.SetCurrentHealth(currentHealth);
         characterController.enabled = true;

     }*/





    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pocao"))
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

    public void RestartLevel()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;

       
        SceneManager.LoadScene(currentSceneName);
    }
}
