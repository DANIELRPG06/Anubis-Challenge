using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    public GameObject creditos;

    public void Start()
    {
        creditos.SetActive(false);
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Test");
        Time.timeScale = 1.0f;
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu Principal");
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void Creditos()
    {
        creditos.SetActive(true);
    }


    
}
