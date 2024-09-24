using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DamageReciber : IFactionMember
{
    void RecieveDamage(DamageSender perpetrator, DamagePayload payload);
}
