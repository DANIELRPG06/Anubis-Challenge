
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewDash : MonoBehaviour
{
    public CharacterController controller;
    public float dashForce;
    public float dashDuration;
    public float cooldownDuration; 
    private float currentDashTime;
    private float currentCooldownTime; 
    private bool isDashing = false;
    private bool isCooldown = false; 
    public GameObject image;
    public GameObject imageEmpty;
   


    private void Start()
    {
        currentDashTime = dashDuration;
        currentCooldownTime = 0f; 
        image.SetActive(true);
        imageEmpty.SetActive(true);
    }

    void Update()
    {
        // Handle cooldown timing
        if (isCooldown)
        {
            image.SetActive(false);
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime <= 0)
            {
                isCooldown = false; 
                image.SetActive(true);
            }
        }

      
        if (Input.GetMouseButtonDown(1) && !isDashing && !isCooldown)
        {
            StartDash();
        }

        if (isDashing)
        {
            
            /*if (TargetLock.isTargeting)
            {
                TargetLockDash();
            }
            else
            {
                ApplyDashForce();
            }*/

            ApplyDashForce();

            currentDashTime -= Time.deltaTime;
            if (currentDashTime <= 0)
            {
                EndDash();
            }
        }
    }

    public void StartDash()
    {
        isDashing = true;
        currentDashTime = dashDuration;
    }

    public void ApplyDashForce()
    {
        Vector3 direction = transform.forward; 

        if (controller != null)
        {
            controller.SimpleMove(direction * dashForce);
        }
    }

    public void EndDash()
    {
        isDashing = false;
        isCooldown = true; 
        currentCooldownTime = cooldownDuration; 
        currentDashTime = dashDuration;
    }

    /*public void TargetLockDash()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ApplyDashForce(transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ApplyDashForce(-transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ApplyDashForce(transform.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ApplyDashForce(-transform.forward);
        }
    }*/
}