using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

public class LayerHandler : Singleton<LayerHandler>
{
    // Options
    [Header("Global Layer Masks")]
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;
}
