using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerOld : MonoBehaviour
{
    float speedMovement = 8f;
    float jumpMultiplier = 1f;
    private SpriteRenderer sr;
    Rigidbody2D rb;

    private InputSystem_Actions input_system;
    private InputAction move;

    public LayerMask groundLayer;
    private float groundCheckDistance = 2.2f;

    private Animator animator;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move = input_system.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();

        sr.flipX = (movement.x == 0) ? sr.flipX : (movement.x < 0) ? true : false;

        bool walkBool = (movement.x != 0) ? true : false;
        animator.SetBool("Walk", walkBool);

        rb.transform.Translate(Vector2.right * speedMovement * movement.x * Time.deltaTime);

        if (isGrounded()) rb.AddForceY(movement.y * jumpMultiplier, ForceMode2D.Impulse);
    }

}
