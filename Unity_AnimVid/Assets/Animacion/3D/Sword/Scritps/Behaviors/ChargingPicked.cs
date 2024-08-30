using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingPicked : StateMachineBehaviour
{
    [SerializeField] private string inputParameter;
    [SerializeField] private string animatedCurveValue;
    [SerializeField] private float defaultValue;
    [SerializeField] private string outputParameter;


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(outputParameter, Mathf.Lerp(defaultValue, animator.GetFloat(animatedCurveValue), animator.GetFloat(inputParameter)));
    }
}
