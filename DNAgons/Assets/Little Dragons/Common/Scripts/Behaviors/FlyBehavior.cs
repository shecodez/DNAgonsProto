﻿using UnityEngine;
using System.Collections;

public class FlyBehavior : StateMachineBehaviour {
    int restore = 10;
    Transform dragoTransform;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetFloat("DragoFloat", 0);
        dragoTransform = animator.transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (!animator.IsInTransition(0))
        {
            // if it is falling and start to fly
            if (animator.applyRootMotion != true)
            {
               animator.GetComponent<Rigidbody>().drag = Mathf.Lerp(animator.GetComponent<Rigidbody>().drag, restore, Time.deltaTime * 10f);
                if (animator.GetComponent<Rigidbody>().drag > restore - 0.1f)
                {
                    animator.applyRootMotion = true;
                    animator.GetComponent<Rigidbody>().drag = 0;
                }

                //From Fall to Fly Uptade the Foward speed
                dragoTransform.position = Vector3.Lerp(dragoTransform.position, dragoTransform.position + animator.velocity * animator.GetFloat("Vertical")/dragoTransform.GetComponent<DragonController>().GroundSpeed/animator.GetFloat("FlySpeed"), Time.deltaTime);

            }
        }
    }
}
