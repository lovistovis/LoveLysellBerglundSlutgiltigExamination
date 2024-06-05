using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[RequireComponent(typeof(Rigidbody))]
public class WalkingEnemy : MonoBehaviour
{
    // Options
    [SerializeField] private float damage;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float walkDistance;
    [SerializeField, Range(0, 1)] private float lerpFactor;
    [SerializeField] private Vector2 direction;

    // Static references
    private Rigidbody rb;

    // Private variables
    Vector3 startPos;
    bool directionFlipped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromStartPos = (rb.position - startPos).magnitude;
        if (distanceFromStartPos > walkDistance)
        {
            directionFlipped = !directionFlipped;
        }

        Vector3 targetVelocity = new(direction.x, 0, direction.y);
        float factor = directionFlipped ? -1 : 1;
        targetVelocity *= factor;
        rb.velocity += (targetVelocity - rb.velocity) * lerpFactor;
    }
}
