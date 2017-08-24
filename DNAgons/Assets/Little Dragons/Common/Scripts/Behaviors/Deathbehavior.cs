using UnityEngine;
using System.Collections;

public class Deathbehavior : StateMachineBehaviour {

  

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetComponent<DragonController>().DragonType == DragonController.DragoType.Mouse)
        {
            animator.transform.GetChild(4).transform.localPosition = Vector3.Lerp(animator.transform.GetChild(4).transform.localPosition, Vector3.zero, Time.deltaTime * 5);
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && animator.GetComponent<DragonController>().DragonType == DragonController.DragoType.Mouse)
        {
            animator.transform.GetChild(4).transform.localPosition = new Vector3(0, -0.095f, 0);
        }
    }


}
