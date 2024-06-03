using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObject/Sword", order = 1)]
public class SwordScriptableObject : ScriptableObject
{
    [Header("Properties")]
    public float damage;
    public float cooldown;
    public float comboWindow;
    [Range(0, 1)] public float airComboTimeScale;
    public ComboState[] groundCombo;
    public ComboState[] airCombo;

    [Serializable]
    public enum AnimationType
    {
        Position,
        Rotation
    }

    [Serializable]
    public struct ComboState
    {
        public float damageMultiplier;
        public float animationLength;
        public AnimationType animationType;
        public Vector3 targetTypeValue;
    }
}
