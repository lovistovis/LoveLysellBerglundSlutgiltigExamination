using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
- Gammal kod från annat projekt. ):
*/

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private CharacterController controller;
    private float rotationX;

    public bool canMove = true;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityValue;
    [SerializeField] private float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        rotationX = 0;

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (canMove)
        {
            // Move values
            playerVelocity.x = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
            playerVelocity.z = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");

            // Camera and player rotation
            rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }

        // Jump possible if grounded
        if (Input.GetButton("Jump") && canMove && controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * 3.0f * gravityValue);
        }

        // Apply gravity if in the air
        if (!controller.isGrounded)
        {
            playerVelocity.y -= gravityValue * Time.deltaTime;
        }

        // If on ground and moving down set y velocity to 0
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float playerVelocityY = playerVelocity.y;
        playerVelocity = (transform.forward * playerVelocity.x) + (transform.right * playerVelocity.z);

        playerVelocity.y = playerVelocityY;

        // Move the controller
        controller.Move(playerVelocity * Time.deltaTime);
    }
}