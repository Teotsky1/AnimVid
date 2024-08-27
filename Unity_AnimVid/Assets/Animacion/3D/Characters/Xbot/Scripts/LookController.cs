using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    [SerializeField] private VectorDamp lookVector;
    [SerializeField] private Transform lookRig;
    [SerializeField] private float sensitivity;
    [SerializeField] private Vector2 VerticalRotationLimit;



    private float rotationY;


    public void Look(InputAction.CallbackContext ctx)
    {
        lookVector.TargetVal = ctx.ReadValue<Vector2>() / new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        lookVector.Update();
        lookRig.RotateAround(lookRig.position, transform.up, lookVector.CurrentVal.x * sensitivity * 360f);
        rotationY -= lookVector.CurrentVal.y * sensitivity * 360;
        rotationY = Mathf.Clamp(rotationY, VerticalRotationLimit.x, VerticalRotationLimit.y);
        Vector3 euler = lookRig.eulerAngles;
        lookRig.localEulerAngles = new Vector3(rotationY, euler.y, euler.z);
    }
}
