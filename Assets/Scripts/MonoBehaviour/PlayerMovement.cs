using System;
using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

// Copyright (c) 2024 Love Lysell Berglund

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Singleton<PlayerMovement>
{
    // Options
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform groundPoint;
    [Header("Movement")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField, Range(0, 1)] private float smoothLerpFactor;

    [Header("Ground")]

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField, Range(0, 0.2f)] private float groundRaycastDistance;
    [Header("Camera")]
    [SerializeField] private float sensitivity;

    // Static references
    private Rigidbody rb;

    // Private variables
    private Vector3 velocity;
    private float rotationX;
    private float horizontalInput;
    private float verticalInput;
    private bool canMove = true;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool isGrounded = false;

    // Properties
    public bool IsGrounded
    {
        get => isGrounded;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GroundedCheck();
        // Jump possible if grounded
        isJumping = Input.GetButton("Jump") && canMove && isGrounded;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (canMove)
        {
            // Camera and player rotation
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;

        if (canMove)
        {
            // Moving
            float currentWalkSpeed = isRunning ? runSpeed : walkSpeed;
            float moveX = currentWalkSpeed * verticalInput;
            float moveZ = currentWalkSpeed * horizontalInput;
            Vector3 targetVelocity = new Vector3(moveX, velocity.y, moveZ);
            // Set velocity with smoothing factor
            velocity = Vector3.Lerp(velocity, targetVelocity, smoothLerpFactor);
        }

        if (isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpForce);
            isJumping = false;
        }

        velocity = velocity.FaceTowards(transform.forward, transform.right);

        rb.velocity = velocity;
        rb.angularVelocity = Vector3.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = groundPoint.position;
        float size = 0.01f;
        Gizmos.DrawWireCube(position, new Vector3(size, size, size));
        Gizmos.DrawRay(position, new Vector3(0f, -groundRaycastDistance, 0f));
    }

    bool GroundedCheck()
    {
        return Physics.Raycast(groundPoint.position, Vector3.down, groundRaycastDistance, groundLayerMask);
    }
}