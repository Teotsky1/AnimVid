using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DamageSender: IFactionMember
{
    void SendDamage(DamageReciber Target);

}
