using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerControlle : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    private bool isRunning;
   


    private bool isAttacking = false;

    public float maxStamina = 10f;
    public float currentStamina;
    public float staminaRecoveryRate = 2f;
    public float sprintStaminaCost = 2f;

    private Animator anim;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = false;

   


    public CharacterController characterController;
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentStamina = maxStamina;


    }

    void Update()
    {

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion
        //Animations/////////////////////////////////////////////////
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);

        isRunning = v > 0 && Input.GetKey(KeyCode.LeftShift) && currentStamina > 1;

        anim.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            currentStamina -= sprintStaminaCost * Time.deltaTime;
            if (currentStamina < 1)
            {
                currentStamina = 0;
                isRunning = false;
            }
        }
        else
        {
            currentStamina += staminaRecoveryRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            anim.SetTrigger("IsAttacking");
            isAttacking = true;
            StartCoroutine(AttackAnimation());



        }
        else
        
        
        //////////////////////////////////////////////////////////////
        

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        if (isRunning && currentStamina > 1)
        {
            currentStamina -= sprintStaminaCost * Time.deltaTime;
            if (currentStamina < 1)
            {
                currentStamina = 0;
                isRunning = false;
            }
        }
        else
        {

            currentStamina += staminaRecoveryRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void SpeedStop()
    {
        walkSpeed = 0f;
        runSpeed = 0f;

    }

    public void SpeedBack()
    {
        walkSpeed = 6;
        runSpeed = 12;

    }

    IEnumerator AttackAnimation()
    {
       
        yield return new WaitForSeconds(1f); 
        isAttacking = false;
    }

    
}
