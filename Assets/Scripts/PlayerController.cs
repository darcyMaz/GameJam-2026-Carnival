using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speedMovement = 8f;
    [SerializeField] float jumpMultiplier = 10f; // Adjusted from 1f

    [Header("Audio Clips")]
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip switchMaskSound;
    public AudioClip fallSound;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
    private InputAction jump;
    private Collider2D coll;
    private InputSystem_Actions input_system;
    private InputAction move;

    public LayerMask groundLayer;
 

    // State tracking variables
    private bool wasGrounded;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
        audioSource = GetComponent<AudioSource>(); 
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        input_system.Player.Enable();
        move = input_system.Player.Move;
        jump = input_system.Player.Jump;

        move.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        input_system.Player.Disable();
        move.Disable();
        jump.Disable();
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(
          coll.bounds.center,
          coll.bounds.size,
          0f,
          Vector2.down,
          0.1f,
          groundLayer
      );
    }

    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();

        // VISUALS
        sr.flipX = (movement.x == 0) ? sr.flipX : (movement.x < 0);
        bool walkBool = (movement.x != 0);
        animator.SetBool("Walk", walkBool);

        // MOVEMENT
        // rb.transform.Translate(Vector2.right * speedMovement * movement.x * Time.deltaTime);
        rb.linearVelocity = new Vector2(movement.x * speedMovement, rb.linearVelocity.y);

        bool groundedNow = isGrounded();

        // JUMP LOGIC & SOUND
        if (groundedNow && jump.WasPressedThisFrame())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
            PlaySound(jumpSound);
        }

        // LANDING SOUND
        if (!wasGrounded && groundedNow)
        {
            if (rb.linearVelocity.y <= 0.1f)
            {
                PlaySound(landSound);
            }
        }

        // WALKING SOUND
        if (groundedNow && movement.x != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying && audioSource.clip == walkSound)
            {
                audioSource.Stop();
            }
        }
        wasGrounded = groundedNow;
    }

    // OneShot sounds (sounds that play on top of others)
    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // PUBLIC METHODS

    // Call this from your Mask script logic
    public void PlaySwitchMaskSound()
    {
        PlaySound(switchMaskSound);
    }

    // Call this from your KillZone/GameExit script logic
    public void PlayFallSound()
    {
        PlaySound(fallSound);
    }
}