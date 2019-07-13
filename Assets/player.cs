using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public InputMaster controls;
    private Rigidbody2D rb2D;
    

    void Awake()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        controls = new InputMaster();
        controls.Player.Shoot.performed += contex => Shoot();
        controls.Player.Movement.performed += context => Movement(context.ReadValue<Vector2>());
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
      
    }

    private void Movement(Vector2 direction) {
        Debug.Log("Move along home"  + direction);

    }



    void Shoot()
    {
        Debug.Log("We shot the sherif!");
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
