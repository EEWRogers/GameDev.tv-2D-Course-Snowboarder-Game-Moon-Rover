using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationStrength = 75f;
    [SerializeField] float defaultSpeed = 20;
    [SerializeField] float boostSpeed = 22f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rigidbody2d;
    PlayerInput playerInput;
    InputAction rotateAction;
    InputAction boostAction;


    void Awake() 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        rotateAction = playerInput.actions["Rotate"];
        boostAction = playerInput.actions["Boost"];
    }

    void Start() 
    {
        if (surfaceEffector2D == null) { return; }
        surfaceEffector2D.speed = defaultSpeed;
    }

    void Update() 
    {
        if (boostAction.IsPressed())
        {
            Boost();
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    void FixedUpdate() 
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        rigidbody2d.AddTorque(rotateAction.ReadValue<float>() * rotationStrength);
    }

    void Boost()
    {
        surfaceEffector2D.speed = boostSpeed;
    }
}
