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

    private InputSystem_Actions input_system;
    private InputAction move;

    public LayerMask groundLayer;
    private float groundCheckDistance = 1.1f; // Adjusted from 2.2f

    // State tracking variables
    private bool wasGrounded;
    private bool hasJumped; 

    private void Awake()
    {
        input_system = new InputSystem_Actions();
        audioSource = GetComponent<AudioSource>(); // Get the audio component
    }

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

    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();

        // VISUALS
        sr.flipX = (movement.x == 0) ? sr.flipX : (movement.x < 0);
        bool walkBool = (movement.x != 0);
        animator.SetBool("Walk", walkBool);

        // MOVEMENT
        rb.transform.Translate(Vector2.right * speedMovement * movement.x * Time.deltaTime);

        bool groundedNow = isGrounded();

        // JUMP LOGIC & SOUND
        if (groundedNow && movement.y > 0)
        {
            if (!hasJumped)
            {
                // Apply Force
                rb.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
                
                // Play Jump Sound
                PlaySound(jumpSound);
                
                hasJumped = true;
            }
        }

        // Reset the jump lock when player releases the Up key
        if (movement.y == 0)
        {
            hasJumped = false;
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