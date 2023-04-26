using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementHandler : MonoBehaviour
{
    // Serialized fields
    [SerializeField] private float cameraspeed = 1f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;

    private void Start()
    {

    }

    private void Update()
    {
        // move the player in the direction of the camera using force







        // if the user presses right click, the movement of the mouse should rotate the camera
        if (Input.GetMouseButton(1))
        {
            // get the mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // rotate the camera
            playerCamera.transform.RotateAround(player.transform.position, Vector3.up, mouseX * cameraspeed);
            playerCamera.transform.RotateAround(player.transform.position, playerCamera.transform.right, -mouseY * cameraspeed);

        }
    }
}