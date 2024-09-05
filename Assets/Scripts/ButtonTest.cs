using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{
    

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Main");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Time.timeScale = 1f;
            RestartCurrentScene();
        }

        
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }

        
       

    }

    public void RestartCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QRcode()
    {

    }

    
}
