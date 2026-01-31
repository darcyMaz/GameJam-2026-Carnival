using UnityEngine;
using UnityEngine.InputSystem;

public class MaskController : MonoBehaviour
{ 
    // Get input action for masks X
    // Create event function that switch sprites when a button is pressed    1/2
    // For now just change colour X
    // Also send message to gamemanager to change state of park attractions to real from illusory X

    // 

    public GameManager GameManager;

    private InputSystem_Actions input_system;
    private InputAction mask;

    private SpriteRenderer sr;

    private IllusionStates state;
    private int IllusionStatesIndex = 0;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwapMask(InputAction.CallbackContext context)
    {
        // Debug.Log("Mask swap!");

        // Cycles through IllusionStates.
        IllusionStatesIndex = (IllusionStatesIndex + 1) % System.Enum.GetNames(typeof(IllusionStates)).Length;
        state = (IllusionStates)IllusionStatesIndex;
        GameManager.MaskSwapped(IllusionStatesIndex);
    }
}
