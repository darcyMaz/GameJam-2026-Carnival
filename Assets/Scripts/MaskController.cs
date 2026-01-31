using UnityEngine;
using UnityEngine.InputSystem;

public class MaskController : MonoBehaviour
{
    // Get input action for masks X
    // Create event function that switch sprites when a button is pressed    1/2
    // For now just change colour X
    // Also send message to gamemanager to change state of park attractions to real from illusory

    public GameManager GameManager;

    private InputSystem_Actions input_system;
    private InputAction mask;

    private SpriteRenderer sr;
    private Color32[] colors;
    private int colorIndex;

    private IllusionStates state;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
        state = IllusionStates.Illusory;
        // Set the sprite to be the simple mask.
    }

    private void OnEnable()
    {
        mask = input_system.Player.Mask;
        mask.Enable();

        mask.performed += SwapMask;
    }

    private void OnDisable()
    {
        mask.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        colorIndex = 0;
        colors = new Color32[2];

        colors[0] = new Color32(178,75,75,255);
        colors[1] = new Color32(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 isSwapped = mask.ReadValue<Vector2>();


    }

    private void SwapMask(InputAction.CallbackContext context)
    {
        // Debug.Log("Mask swap!");
        colorIndex = (colorIndex+1) % colors.Length;
        sr.color = colors[colorIndex];

        // if () GameManager.MaskSwapped();
    }
}
