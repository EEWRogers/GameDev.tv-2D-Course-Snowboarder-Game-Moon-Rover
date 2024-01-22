using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelspin : MonoBehaviour
{
    [SerializeField] float wheelSpinSpeed = 1f;
    void Update()
    {
        RotateWheel();
    }

    private void RotateWheel()
    {
        transform.Rotate(0,0,wheelSpinSpeed);
    }
}
