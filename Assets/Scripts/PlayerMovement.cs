using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the character controller component
    public CharacterController controller;

    // Normal speed for the character
    public float speed = 12f;

    // Variable to store the vertical velocity of the player
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {

        // Get the horizontal and vertical input from the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the move direction based on the horizontal and vertical input
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the character controller in the calculated direction
        controller.Move(move * speed * Time.deltaTime);

        // Move the character controller in the calculated y direction
        controller.Move(velocity * Time.deltaTime);
    }
}
