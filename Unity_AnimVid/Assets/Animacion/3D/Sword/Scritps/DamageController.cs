using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class DamageController : MonoBehaviour, DamageReciber
{
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    public int Faction => 0;

    public void RecieveDamage(DamageSender perpetrator, DamagePayload payload)
    {
        bool isAlivex = GetComponent<CharacterStates>().UpdateHealth(payload.damage);
        Vector3 damageDir = transform.InverseTransformPoint(payload.position).normalized;
        if (isAlivex)
        {
            if (Mathf.Abs(damageDir.x) > Mathf.Abs(damageDir.z))
            {
                Anim.SetFloat("DamageX", damageDir.x * (float)payload.severity);
                Anim.SetFloat("DamageY", 0);
            }
            else
            {
                Anim.SetFloat("DamageX", 0);
                Anim.SetFloat("DamageY", damageDir.z * (float)payload.severity);
            }
            Anim.SetTrigger("Damage");
        }
        else
        {
            Anim.SetTrigger("Die");
        }
       
    }
}
