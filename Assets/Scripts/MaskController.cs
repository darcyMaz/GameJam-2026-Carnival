using UnityEngine;
using UnityEngine.InputSystem;

public class MaskController : MonoBehaviour
{
    public GameManager gm;

    private InputSystem_Actions input_system;
    private InputAction mask;

    private IllusionStates state = IllusionStates.Illusory;
    private Animator animator;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
        gm = FindFirstObjectByType<GameManager>();
        if (gm == null)
            Debug.LogError("GameManager NOT FOUND in Awake()");
    }

    private void OnEnable()
    {
        input_system.Player.Enable();

        mask = input_system.Player.Mask;
        mask.performed += SwapMask;
        mask.Enable();
    }

    private void OnDisable()
    {
        mask.performed -= SwapMask;
        mask.Disable();
        input_system.Player.Disable();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (gm == null)
        {
            Debug.LogError("GameManager not found!");
            return;
        }

        // Sync world with starting mask state
        gm.MaskSwapped((int)state);
        animator.SetBool("MaskOn", true);
    }

    private void SwapMask(InputAction.CallbackContext context)
    {
        state = state == IllusionStates.Illusory
            ? IllusionStates.Visible
            : IllusionStates.Illusory;

        gm.MaskSwapped((int)state);
        animator.SetBool("MaskOn", state == IllusionStates.Visible);
    }
}