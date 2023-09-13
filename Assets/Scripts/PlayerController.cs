using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * Component of the Vehicle, takes in user
 * imput to move and thurn the vehicle
 * 
 * May Wang
 * September 11, 2023 Version 1
 *******************************************/

public class PlayerController : MonoBehaviour
{
    private float speed;            // holds the forward movement of the vehicle
    private float turnSpeed;        // holds the turn speed of the vehicle
    private float verticalInput;    // gets a value [-1, 1] from user key press up/down or W/S
    private float horizontalInput;  // gets a value [-1, 1] from user key press left/right A/S

    private Rigidbody rb;           // points to vehicle rigidbody component

    // Initializes speed before the first frame update
    void Start()
    {
        speed = 20.0f;
        turnSpeed = 50.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput * 500);           // * 500 added to give a balance of the force with realism
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        Scorekeeper.Instance.AddToScore(verticalInput);
    }

    // Called from PlayerActionInput when user presses WASD or arrow keys
    private void OnMove(InputValue input)
    {
        verticalInput = input.Get<Vector2>().y;
        horizontalInput = input.Get<Vector2>().x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Scorekeeper.Instance.SubtractFromScore();
        }
    }
}