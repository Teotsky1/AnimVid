using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    [SerializeField] float maxHealth;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public bool UpdateHealth(float HealthDelta)
    {
        if(currentHealth >= HealthDelta)
        {
            currentHealth += HealthDelta;
            return true;
        }
        Debug.Log("Dead");
        return false;
    }
}
