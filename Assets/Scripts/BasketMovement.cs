using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Paul Kent Yochum
// Basket Movement Script
// 4/16/2022


public class BasketMovement : MonoBehaviour
{

    private Rigidbody2D Basket;    
    public float speed, xBound;


    void Start()
    {
        Basket = GetComponent<Rigidbody2D>();    // Reference to private rigidBody2D component 
    }

  
    void FixedUpdate()     // Fixed for movement with RigidBody
    {
        float s = Input.GetAxisRaw("Horizontal");    // Checking if we are moving left or right

        if (s > 0)     
        {
            Basket.velocity = Vector2.right * speed;    // Checks if we are moving to the right
        }
        else if (s < 0)
        {
            Basket.velocity = Vector2.left * speed;    // Checks to see if we are moving left
        }
        else
            Basket.velocity = Vector2.zero;    // Not moving

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBound, xBound), transform.position.y);    // Set area bounds based off variable
    }
}
