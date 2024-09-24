using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour, DamageSender
{
    
    [SerializeField] private float damageAmount;
    [SerializeField] private DamagePayload.DamageSeverity damageSeverity;
    public int Faction => 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out DamageReciber reciever))
        {
            SendDamage(reciever);
        }
    }


    public void SendDamage(DamageReciber Target)
    {
        Target.RecieveDamage(this, new DamagePayload { damage = -damageAmount , severity = damageSeverity});
    }
}
