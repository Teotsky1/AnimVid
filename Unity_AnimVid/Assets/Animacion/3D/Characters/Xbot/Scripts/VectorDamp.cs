using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]


public struct VectorDamp
{
    private Vector2 currentVal;
    private Vector2 targetVal;
    private Vector2 velo;
    [SerializeField] private float smoothT;
    [SerializeField] private float clampMag;
    [SerializeField] private bool clamp;


    public VectorDamp(bool clamp)
    {
        currentVal = Vector2.zero;
        targetVal = Vector2.zero;
        velo = Vector2.zero;
        smoothT = 0;
        clampMag = 0;
        this.clamp = clamp;


    }


    public void Update()
    {
        currentVal = Vector2.SmoothDamp(currentVal, 

            clamp ? Vector2.ClampMagnitude(targetVal,clampMag): targetVal,
            
            ref velo, smoothT);
    }

    public Vector2 CurrentVal   => currentVal;

    public Vector2 TargetVal { set => targetVal = value;}

    public bool Clamp { set => clamp = value; }
}
