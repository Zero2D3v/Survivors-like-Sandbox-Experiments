
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    public PlayerInputActions playerControls;
    //public InputAction playerControls;

    private Vector2 moveDirection;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        //SIMPLE METHOD
        //playerControls.Enable();
        //change to .UI here for alt input***
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        //playerControls.Disable();

        move.Disable();
    }

    private Vector2 MoveDirection()
    {
        moveDirection = move.ReadValue<Vector2>();
        return moveDirection;
    }

    private void RotateToDirection()
    {
        if(moveDirection !=  Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }

    private void Update()
    {
        //moveDirection = playerControls.ReadValue<Vector2>();
        MoveDirection();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        RotateToDirection();
    }

}
