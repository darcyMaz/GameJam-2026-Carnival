using UnityEngine;
using UnityEngine.InputSystem;

public class MaskController : MonoBehaviour
{

    public GameManager gm;
    // public GameObject GMObject;

    private InputSystem_Actions input_system;
    private InputAction mask;

    private SpriteRenderer sr;

    private IllusionStates state;
    private int IllusionStatesIndex = 0;

    private Animator Animator;

    private void Awake()
    {
        input_system = new InputSystem_Actions();
        state = IllusionStates.Illusory;
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
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwapMask(InputAction.CallbackContext context)
    {
        // Cycles through IllusionStates.
        IllusionStatesIndex = (IllusionStatesIndex + 1) % System.Enum.GetNames(typeof(IllusionStates)).Length;
        state = (IllusionStates)IllusionStatesIndex;
        gm.MaskSwapped(IllusionStatesIndex);

        bool toSetMask = Animator.GetBool("MaskOn") ? false : true;
        Animator.SetBool("MaskOn", toSetMask);
    }
}
