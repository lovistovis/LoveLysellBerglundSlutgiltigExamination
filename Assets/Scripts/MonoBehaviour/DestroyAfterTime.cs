using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

public class DestroyAfterTime : MonoBehaviour
{
    // Options
    [SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyGameObject), time);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
