using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesabilitarTutorial : MonoBehaviour
{
   
    public GameObject objectToDisable;
    public GameObject objectToEnable;
    public GameObject textElementT;
    public GameObject enemyBar;
    public AudioClip newMusic; 
    private AudioSource audioSource;
    public GameObject blackbox;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
                objectToEnable.SetActive(true);
                textElementT.SetActive(false);
                enemyBar.SetActive(true);
                blackbox.SetActive(false);
                SwitchMusic();

            }
        }
    }

    private void SwitchMusic()
    {
        if (audioSource != null && newMusic != null)
        {
            audioSource.Stop();
            audioSource.clip = newMusic; 
            audioSource.Play();
        }
    }
}

