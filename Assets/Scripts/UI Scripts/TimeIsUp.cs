using UnityEngine;

public class TimeIsUp : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Timer>().TimeIsUp();
    }
}
