using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public InputMaster controls;
    private Rigidbody2D rb2D;

    [Header("Movement Properties")]
    private Vector2 direction;  //vector2 input from InputMaster for left and right buttons pressed for movement of player.
    public float playerSpeed = 5;


    [Header("Jump Properties")]
    private float isJumping = 0; //float input from InputMaster for jump button press
    public float jumpForce = 10.0f; //force of jump
    private bool hasJumped = false; //delete once we get a ground check implimented.


    [Header("Environment Check Properties")]
    public float groundDistance = 0.2f;
    public LayerMask groundlayer;

   

    [Header("Status Flags")]
    public bool isOnGround;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        controls = new InputMaster();
        controls.Player.Jump.performed += contex => isJumping =contex.ReadValue<float>();
        controls.Player.Jump.canceled += contex => isJumping = contex.ReadValue<float>();
        controls.Player.Movement.performed += context => direction = context.ReadValue<Vector2>(); //sets direction Vector2 to + or - values depending on direction once keys are pressed
        controls.Player.Movement.canceled += context => direction = context.ReadValue<Vector2>();  //sets direction Vector2 to 0 once keys are released

    }

   

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        rigidbodyAddForces();

    }

    private void rigidbodyAddForces()
    {
        
        rb2D.AddRelativeForce(direction * playerSpeed, ForceMode2D.Impulse); //Takes input direction, speed setting and applies it to object/player rigidbody.

        rigidbodyAddForceJump();
    }

    private void rigidbodyAddForceJump()
    {
        if (isJumping > 0 && !hasJumped)
        {
            rb2D.AddRelativeForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            hasJumped = true;
        }
        else if (isJumping == 0)
        {
            hasJumped = false;
        }
    }




    /*
        void jumpInputDetection(bool jumpingDetect)
        {
            Debug.Log("Hip hop hippity Hop!");
            if (jumpingDetect)
            {
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }
        */
    private void OnEnable()
    {
        controls.Enable();

    }
    private void OnDisable()
    {
        controls.Disable();
    }

}
