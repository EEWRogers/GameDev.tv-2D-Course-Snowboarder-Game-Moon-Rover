using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFX : MonoBehaviour
{
    [SerializeField] ParticleSystem wheelParticleFX;
    [SerializeField] float wheelSpinSpeed = 1f;
    void Update()
    {
        RotateWheel();
    }

    private void RotateWheel()
    {
        transform.Rotate(0,0,wheelSpinSpeed);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        wheelParticleFX.Play();
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        wheelParticleFX.Stop();
    }
}
