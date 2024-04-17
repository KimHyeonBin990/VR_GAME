using UnityEngine;

public class KeyboardMouseController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 60.0f;
    public float jumpForce = 5.0f;

    private float yRotation = 0.0f;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private bool jump = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Cursor locking helps with the mouse looking more natural
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Use basic WASD keys to get movement input
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInput = transform.TransformDirection(moveInput);

        // Simple gravity and jump (when space is pressed)
        if (characterController.isGrounded)
        {
            moveDirection = moveInput * moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                jump = true;
            }
        }
        else
        {
            // Apply gravity
            moveDirection += Physics.gravity * Time.deltaTime;
            moveDirection.x = moveInput.x * moveSpeed;
            moveDirection.z = moveInput.z * moveSpeed;
        }

        // Move the player
        characterController.Move(moveDirection * Time.deltaTime);

        // Mouse rotation input for looking left and right
        yRotation += Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void OnDisable()
    {
        // Unlock the cursor when the game is paused or over
        Cursor.lockState = CursorLockMode.None;
    }
}