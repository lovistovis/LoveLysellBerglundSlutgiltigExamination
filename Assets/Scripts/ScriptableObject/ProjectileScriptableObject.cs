using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObject/Projectile", order = 1)]
public class ProjectileScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public float damage;
}
