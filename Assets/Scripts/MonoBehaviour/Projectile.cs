using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

public class Projectile : MonoBehaviour
{
    // Options
    [Header("References")]
    [SerializeField] private ProjectileScriptableObject projectile;

    // Private variables
    private bool projectileScriptableObjectNull;
    private LayerMask hitLayerMask;

    // Properties
    public LayerMask HitLayerMask
    {
        get { return hitLayerMask; }
        set { hitLayerMask = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        projectileScriptableObjectNull = projectile == null;
        if (projectileScriptableObjectNull) { Debug.LogWarning("No scriptable object specified"); }
    }

    void OnCollisionEnter(Collision col)
    {
        if (projectileScriptableObjectNull) { return; }
        GameObject otherGameObject = col.gameObject;
        if (!otherGameObject.TryGetComponent(out IDamageable damageable)) { return; }
        float damage = projectile.damage;
        damageable.Damage(damage);
    }
}