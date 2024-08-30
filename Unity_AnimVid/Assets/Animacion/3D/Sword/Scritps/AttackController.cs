using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]

public class AttackController : MonoBehaviour
{
    private Animator anim;


    private bool ActiveAttack()
    {
        return anim.GetFloat("ActiveAttack") > 0.5f;
    }
    public void LightAttack(InputAction.CallbackContext ctx)
    {
        if (!ctx.ReadValueAsButton()) return;
        //if (ActiveAttack()) return;

        anim.SetTrigger("Attack");
        anim.SetBool("Heavy", false);
    }

    public void HeavyAttack(InputAction.CallbackContext ctx) 
    {
        bool clicked = ctx.ReadValueAsButton();
        if (clicked) 
        {
            anim.SetTrigger("Attack");
            anim.SetBool("Heavy", true);
            anim.SetFloat("Charging", 1f);
        }
        else
        {
            anim.SetFloat("Charging", 0f);
        }
       
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
