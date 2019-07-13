using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public InputMaster controls;
    private Rigidbody2D rb2D;
    private Vector2 direction;
    private bool isJumping;
    [SerializeField] float playerSpeed = 5;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        controls = new InputMaster();
        controls.Player.Jump.performed += contex => jumpInput();
        controls.Player.Movement.performed += context => movementInput(context.ReadValue<Vector2>());
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {


        moveAlongHome();

    }

    private void moveAlongHome()
    {

        // float playerVelocity = playerSpeed * direction;

        //  rb2D.velocity = new Vector2(direction, playerSpeed);

        if (direction.x > 0 || direction.x < 0)
        {
           
            rb2D.AddRelativeForce(direction * playerSpeed, ForceMode2D.Impulse);
        }
        else
        {
            //var oppositeForce = -(direction * playerSpeed);
          //  rb2D.AddForce(-direction * playerSpeed, ForceMode2D.Impulse);
          
        }
    }

    private void movementInput(Vector2 dir) {
        Debug.Log("Move along home"  + dir);
        
        direction = dir;
        
    }



    void jumpInput()
    {
        Debug.Log("Hip hop hippity Hop!");
        isJumping = true;
    }

    private void OnEnable()
    {
        controls.Enable();

    }
    private void OnDisable()
    {
        controls.Disable();
    }

}
