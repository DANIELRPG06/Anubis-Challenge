using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    PlayerMovementV2 moveScript;

    public float dashSpeed;
    public float dashTime;
    private Animator anim;
    private bool isDashingOnCooldown = false;
    public float cooldownTime;
    public Image cooldownIndicator;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        moveScript = GetComponent<PlayerMovementV2>();
        cooldownIndicator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isDashingOnCooldown)
        {
            StartCoroutine(Dashing());

            anim.SetTrigger("IsDashing");

            isDashingOnCooldown = true;

            StartCoroutine(DashCooldown());

            cooldownIndicator.enabled = false;
        }
    }

    IEnumerator Dashing()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            //moveScript.controller.Move(moveScript.moveDirection * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isDashingOnCooldown = false;
        cooldownIndicator.enabled = true;
    }

    
}
