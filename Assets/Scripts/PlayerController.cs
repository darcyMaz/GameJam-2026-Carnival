using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float speedMovement = 10f;
    // float jumpForce = 1f;
    private SpriteRenderer sr;
    Rigidbody2D rb;

    private InputSystem_Actions input_system;
    private InputAction move;
    // private InputAction fire;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        move = input_system.Player.Move;
        move.Enable();

        //fire = input_system.Player.Fire;
        //fire = input_system.FindAction("Fire");
        //fire.Enable();

        //fire.performed += Fire;
    }
    private void OnDisable()
    {
        move.Disable();
        //fire.Disable();

        //fire.performed -= Fire;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();

        sr.flipX = (movement.x == 0) ? sr.flipX : (movement.x < 0) ? true : false;
        transform.Translate(Vector2.right * speedMovement * movement.x * Time.deltaTime);
    }

    /*

    private void Fire(InputAction.CallbackContext context)
    {
        if (context.started) Debug.Log("Fire");
        if (context.performed) Debug.Log("Done");
    }
    */
}
