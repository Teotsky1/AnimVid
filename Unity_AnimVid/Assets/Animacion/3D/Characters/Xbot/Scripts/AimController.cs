using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class AimController : MonoBehaviour
{
    [SerializeField] private AimConstraint chestAim;
    [SerializeField] private Transform aimRig;
    [SerializeField] private Transform camtransform;
    [SerializeField] private Animator animtor;

    private bool aim;

    public void Aim(InputAction.CallbackContext ctx)
    {
        bool val = ctx.ReadValueAsButton(); //Lee el Input Sistem (ClickDerecho)
        aim = val;

        chestAim.enabled = val; //Activa y Desactiva el aim constrain (Pecho)

        aimRig.gameObject.SetActive(val);
        animtor.SetBool("Aim", val);
    }


    private void Awake()
    {
        aimRig.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (aim) transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(camtransform.forward, transform.up).normalized);
    }
}
