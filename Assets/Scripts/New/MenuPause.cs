using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    PlayerStats stats;
    PlayerMovementV2 m_PlayerMovementV2;
    
    public GameObject pauseMenu;
    private bool isPaused;
    
    

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        m_PlayerMovementV2 = GetComponent<PlayerMovementV2>();
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }

    }

    private void PauseGame()
    {
        stats.enabled = false;
        m_PlayerMovementV2.enabled = false;
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
    }
    private void ResumeGame() 
    {
        stats.enabled = true;
        m_PlayerMovementV2.enabled = true;
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    

}
