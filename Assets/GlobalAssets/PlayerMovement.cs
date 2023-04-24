using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace Assets
{
    internal class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float groundDrag;

        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;
        [SerializeField] private float airMultiplier;
        [SerializeField] bool readyToJump;

        [SerializeField] private float walkSpeed = 7;
        [SerializeField] private float sprintSpeed = 10;
        [SerializeField] private float crouchSpeed = 3;
        [SerializeField] private float cameraspeed = 1f;


        [Header("Keybinds")]
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;

        [Header("Ground Check")]
        [SerializeField] private float playerHeight;

        public Transform orientation;

        [SerializeField] private float horizontalInput;
        [SerializeField] private float verticalInput;

        private Vector3 moveDirection;

        private Rigidbody rb;
        [SerializeField] private Camera cam;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;

            readyToJump = true;
        }

        private void Update()
        {



            // ground check
            InputHandler();
            SpeedControl();


        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void InputHandler()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            // when to jump
            if (Input.GetKey(jumpKey) && readyToJump)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            }
            // when to crouch
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Crouch();
            }
            else
            {
                Stand();
            }
        }

        private void MovePlayer()
        {
            // calculate movement direction
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }

        private void SpeedControl()
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

        private void Jump()
        {
            // reset y velocity
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        private void ResetJump()
        {
            readyToJump = true;
        }

        private void Crouch()
        {
            // set player height to 1
            playerHeight = 1f;
            // half the ground distance


            // set the player height to 0.3
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
            {
                // set the player height to 0.5 smoothly
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 10);
            }
            // set the move speed to crouch speed
            moveSpeed = crouchSpeed;

            // move camera's down
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0, 0.7f, 0), Time.deltaTime * 10);

        }

        private void Stand()
        {
            // set player height to 2
            playerHeight = 2;


            // set the player height to 2
            transform.localScale = new Vector3(1, 1, 1);
            foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
            {
                // set the player height to 1 smoothly
                child.localScale = Vector3.Lerp(child.localScale, new Vector3(1, 1, 1), Time.deltaTime * 10);
            }
            // set the move speed to walk speed
            moveSpeed = walkSpeed;

            // move camera's up
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0, 1, 0), Time.deltaTime * 10);
        }



    }
}