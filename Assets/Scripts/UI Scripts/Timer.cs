using UnityEngine;

public class Timer : MonoBehaviour
{
    private Animator animator;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If a certain animation bool is true, where the time is up, then call the death function from GM.
    }

    public void SwapMask(int illusionState)
    {
        IllusionStates IllusionState = (IllusionStates)illusionState;

        // if mask is off and the illusionstate is illusory then put the mask back on, i.e. set the anim bool to false
        // if mask is on and the illsuionstate is hidden then take the mask off, i.e. set the anim bool to true

        if (animator.GetBool("MaskOff") && IllusionState == IllusionStates.Illusory)
        {
            animator.SetBool("MaskOff", false);
        }
        else if (!animator.GetBool("MaskOff") && IllusionState == IllusionStates.Visible)
        {
            animator.SetBool("MaskOff", true);
        }
        else
        {
            Debug.Log("A Timer Script is trying to understand whether the mask is on or off, but is out of sync with the GameManager.");
        }
    }

    public void TimeIsUp()
    {
        if (gm == null) { return; }
        gm.ResetGame();
    }

}
