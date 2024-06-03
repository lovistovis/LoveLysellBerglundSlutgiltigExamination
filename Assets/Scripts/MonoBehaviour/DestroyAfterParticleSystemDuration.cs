using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[RequireComponent(typeof(ParticleSystem))]
public class DestroyAfterParticleSystemDuration : MonoBehaviour
{
    // Options
    [SerializeField] private float extra;
    [SerializeField] private bool addLifetime;

    // Static references
    private new ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        float time = particleSystem.main.duration + extra;
        if (addLifetime)
        {
            time += particleSystem.main.startLifetime.constant;
        }
        Invoke(nameof(DestroyGameObject), time);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
