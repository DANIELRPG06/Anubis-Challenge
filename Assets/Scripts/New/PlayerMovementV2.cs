using UnityEngine;
using UnityEngine.UI;
public class PlayerMovementV2 : MonoBehaviour
{
    CharacterController controller;
    public Transform cam;
    private Vector2 move;
    public float moveSpeed;
    public float turnSmoothTime;
    private float turnSmoothVelocity;
    private Animator animator;
    public float sprintSpeed;
    private float defaultSpeed;
    public float gravityForce;
    private Vector3 velocity;
    TargetLock targetLock;
    public float timeBetweenAttacks = 0.5f;
    private int attackIndex = 0;
    private float attackTimer = 0f;
    public float comboResetTime = 1.0f;
    private float comboTimer = 0f;
    public Slider staminaSlider;
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public float sprintStaminaCost = 20f;
    public float attackStaminaCost = 10f; 
    public float staminaRegenDelay = 1.0f;
    private float staminaRegenTimer = 0f;
    public float attackSpeed;
    private bool isAttacking;
    private bool isRunning;

    private void Start()
    {
        targetLock = GetComponent<TargetLock>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        defaultSpeed = moveSpeed;
        currentStamina = maxStamina;
    }

    private void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(move.x, 0, move.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (controller.isGrounded)
            {
                velocity.y = 0f;
            }
            else
            {
                velocity.y += gravityForce * Time.deltaTime;
            }

            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime + velocity);

            animator.SetBool("IsWalking", true);
            animator.SetFloat("Horizontal", move.x);
            animator.SetFloat("Vertical", move.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && direction.magnitude >= 0.1f && currentStamina > 0)
        {
            isRunning = true;
            moveSpeed = sprintSpeed;
            animator.SetBool("IsRunning", true);
            currentStamina -= sprintStaminaCost * Time.deltaTime;
            staminaRegenTimer = 0f;
        }
        else
        {
            isRunning = false;
            moveSpeed = defaultSpeed;
            animator.SetBool("IsRunning", false);
        }

        attackTimer += Time.deltaTime;
        comboTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Attack(); 
        }

        if (comboTimer >= comboResetTime)
        {
            ResetCombo();
        }

        if (currentStamina < maxStamina && staminaRegenTimer >= staminaRegenDelay)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }
        staminaRegenTimer += Time.deltaTime;

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaSlider.value = currentStamina;

        if (isAttacking)
        {
            moveSpeed = attackSpeed;
        }

        if (!isAttacking && !isRunning)
        {
            moveSpeed = defaultSpeed;
        }
    }

    void Attack()
    {
        if (attackTimer >= timeBetweenAttacks || attackIndex == 0)
        {
            attackTimer = 0f;

            switch (attackIndex)
            {
                case 0:
                    animator.SetTrigger("Atk1");
                    break;
                case 1:
                    animator.SetTrigger("Atk2");
                    break;
                case 2:
                    animator.SetTrigger("Atk3");
                    break;
            }

            attackIndex = (attackIndex + 1) % 3;
            comboTimer = 0f;
            isAttacking = true;
        }
    }

    void ResetCombo()
    {
        isAttacking = false;
        attackIndex = 0;
        animator.SetTrigger("Idle");
        animator.ResetTrigger("Atk1");
        animator.ResetTrigger("Atk2");
        animator.ResetTrigger("Atk3");
    }

    
    public void ConsumeStamina()
    {
        if (currentStamina >= attackStaminaCost)
        {
            currentStamina -= attackStaminaCost;
            staminaRegenTimer = 0f; 
        }
    }
}