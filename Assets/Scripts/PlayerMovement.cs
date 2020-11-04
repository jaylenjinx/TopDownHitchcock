﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    //public Transform transform;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    //float lookingDirection = 0f;
    public Joystick joystick;

    public float runSpeed = 20.0f;
    //public float lookingForce = 20f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = SimpleInput.GetAxis("Horizontal"); // -1 is left
        vertical = SimpleInput.GetAxis("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);


        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}