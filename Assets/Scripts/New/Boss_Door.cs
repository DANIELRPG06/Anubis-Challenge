using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Door : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    public bool todosMortos;
    public Animator animator;

    private void Start()
    {
        todosMortos = false;
        
    }
    private void Update()
    {
       
        CheckForMissingObjects();

       

    }

   
    private void CheckForMissingObjects()
    {
       
        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach (GameObject obj in objectList)
        {
            if (obj == null)
            {
                objectsToRemove.Add(obj); 
            }
        }

        
        foreach (GameObject obj in objectsToRemove)
        {
            RemoveObject(obj);
        }
    }

    
    public void RemoveObject(GameObject obj)
    {
        if (objectList.Contains(obj))
        {
            objectList.Remove(obj);

           

           
            if (objectList.Count == 0)
            {
                todosMortos = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && todosMortos)
        {
            animator.SetTrigger("OpenDoor");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && todosMortos)
        {
            animator.SetTrigger("CloseDoor");
        }
    }





}
