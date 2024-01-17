using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationStrength = 75f;
    Rigidbody2D rigidbody2d;
    PlayerInput playerInput;
    InputAction rotateAction;

    void Awake() 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        rotateAction = playerInput.actions["Rotate"];
    }

    void FixedUpdate() 
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        rigidbody2d.AddTorque(rotateAction.ReadValue<float>() * rotationStrength);
    }
}
