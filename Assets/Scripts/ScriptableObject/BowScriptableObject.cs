using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[CreateAssetMenu(fileName = "Bow", menuName = "ScriptableObject/Bow", order = 1)]
public class BowScriptableObject : ScriptableObject
{
    [Header("Properties")]
    // public float damageMultiplier;
    public float cooldown;
    public Vector3 velocity;
    // public GameObject projectilePrefab;
}
