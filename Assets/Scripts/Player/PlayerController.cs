using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 4.1f;
    [SerializeField] float zClamp = 2f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float gravity = -20f;
    float verticalVelocity;
    Rigidbody rigidBody;
    Vector2 movement;
    const string jumpString = "Jump";
    bool jumpRequested = false;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 finalMove = CalculateMovementAndJumping();
        rigidBody.MovePosition(rigidBody.position + finalMove);
        
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }

    // private void HandleMovement()
    // {
    //     Vector3 currentPosition = rigidBody.position;
    //     Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
    //     Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);
    //     newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
    //     newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

    //     rigidBody.MovePosition(newPosition);
    // }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            jumpRequested = true;
        }
    }
    // private void HandleJumping()
    // {
    //     Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
    //     bool isGrounded = Physics.Raycast(rayOrigin, Vector3.down, 0.2f);

    //     if (isGrounded)
    //     {
    //         verticalVelocity = 0; // Reset velocity when on ground
    //         if (jumpRequested)
    //         {
    //             verticalVelocity = jumpForce; // Give the "kick"
    //             animator.SetTrigger(jumpString);
    //         }
    //     }
    //     else
    //     {
    //         verticalVelocity += gravity * Time.fixedDeltaTime;
    //     }

    //     Vector3 move = new Vector3(0, verticalVelocity * Time.fixedDeltaTime, 0);
    //     rigidBody.MovePosition(rigidBody.position + move);

    //     jumpRequested = false;
    // }

    private Vector3 CalculateMovementAndJumping()
    {
        Vector3 horizontalMove = new Vector3(movement.x, 0f, movement.y) * (moveSpeed * Time.fixedDeltaTime);

        bool isGrounded = rigidBody.position.y <= 0.01f; 

        if (isGrounded)
        {
            if (verticalVelocity < 0) verticalVelocity = 0;
            
            if (jumpRequested)
            {
                verticalVelocity = jumpForce;
                animator.StopPlayback();
                animator.SetTrigger(jumpString);
            }
        }
        else
        {
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }
        
        jumpRequested = false;

        Vector3 verticalMove = new Vector3(0, verticalVelocity * Time.fixedDeltaTime, 0);
        Vector3 combinedMove = horizontalMove + verticalMove;
        
        Vector3 targetPos = rigidBody.position + combinedMove;

        if (targetPos.y < 0) 
        {
            targetPos.y = 0;
            verticalVelocity = 0;
        }

        targetPos.x = Mathf.Clamp(targetPos.x, -xClamp, xClamp);
        targetPos.z = Mathf.Clamp(targetPos.z, -zClamp, zClamp);

        // Return the delta (difference)
        return targetPos - rigidBody.position;
    }
}
