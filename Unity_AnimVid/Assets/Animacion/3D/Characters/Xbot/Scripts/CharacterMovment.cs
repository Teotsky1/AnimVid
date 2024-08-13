using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CallBackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class CharacterMovment : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private VectorDamp motionVector = new VectorDamp(true);


    private int VelxID, VelyID;

    public void Move(CallBackContext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();

        motionVector.TargetVal = direction;

    }


    public void ToggleSprint(CallBackContext ctx) 
    {
        bool val = ctx.ReadValueAsButton();

        motionVector.Clamp = !val;

    }


    private void Awake()
    {
        VelxID = Animator.StringToHash("VelX");
        VelyID = Animator.StringToHash("VelY");
    }

    private void Update()
    {
        motionVector.Update();


        Vector2 dir = motionVector.CurrentVal;

        anim.SetFloat("VelY", dir.y);

        anim.SetFloat("VelX", dir.x);
    }


    private void OnAnimatorMove()
    {
        

        float interpolator = Mathf.Abs(Vector3.Dot(cameraTransform.forward, transform.up));
        //Camara
        Vector3 forward = Vector3.Lerp(cameraTransform.forward, cameraTransform.up, interpolator);

        Vector3 projected = Vector3.ProjectOnPlane(forward, transform.up);

        //Productopunto para saber cual es el angulo entre 2 vectores

        Quaternion rotation = Quaternion.LookRotation(projected, transform.up);  

        anim.rootRotation = Quaternion.Slerp(anim.rootRotation, rotation, motionVector.CurrentVal.magnitude);

        anim.ApplyBuiltinRootMotion();
    }
}
