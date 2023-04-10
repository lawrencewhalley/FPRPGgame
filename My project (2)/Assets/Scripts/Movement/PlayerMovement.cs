using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public float originalSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;
    public cameraSettings cameraSettings;
    public int staminaDrainRate;

    [SerializeField]
    private Transform cameraTransform;

    private CharacterController characterController;
    private Animator animator;
    private float ySpeed;
    private float originalStepOffSet;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool sprinting;
    public CharacterStats characterStats;


    [SerializeField] private StaminaScript StaminaBar;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalStepOffSet = characterController.stepOffset;
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticallInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffSet;
            ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("isGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                animator.SetBool("isFalling", true);
            }

        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            if (characterStats.currentStamina >= 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    CancelInvoke();
                    speed = sprintSpeed;
                    animator.SetBool("sprinting", true);
                    animator.SetBool("isRunning", false);

                    InvokeRepeating("decreaseStamina", 1.0f, 1.0f);

                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    CancelInvoke();
                    speed = originalSpeed;
                    animator.SetBool("sprinting", false);
                    animator.SetBool("isRunning", true);
                    InvokeRepeating("increaseStamina", 1.0f, 1.0f);
                }
            }
            else if (characterStats.currentStamina <= 0)
            {
                speed = originalSpeed;
                animator.SetBool("sprinting", false);
                animator.SetBool("isRunning", true);
                InvokeRepeating("increaseStamina", 1.0f, 1.0f);
            }
            else if (characterStats.currentStamina <= 0)
            {
                speed = originalSpeed;
            }

            animator.SetBool("isRunning", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, cameraSettings.mouseSensitivity * Time.deltaTime);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void decreaseStamina()
    {
        if (characterStats.currentStamina >= 0)
        {
            StaminaBar.updateStaminaBar(characterStats.Stamina.GetValue(), characterStats.currentStamina);
            characterStats.currentStamina -= staminaDrainRate;
        }
    }
    void increaseStamina()
    {
        if (characterStats.currentStamina <= 100)
        {
            StaminaBar.updateStaminaBar(characterStats.Stamina.GetValue(), characterStats.currentStamina);
            characterStats.currentStamina += staminaDrainRate;
        }
        else
        {
            return;
        }
    }

}
