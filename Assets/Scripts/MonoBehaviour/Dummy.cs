using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

[RequireComponent(typeof(Collider))]
public class Dummy : MonoBehaviour, IDamageable
{
    // Options
    [SerializeField] private GameObject damageParticlePrefab;

    // Static references

    // Private variables

    private bool damageParticlePrefabNull;

    // Start is called before the first frame update
    void Start()
    {
        damageParticlePrefabNull = damageParticlePrefab == null;
        if (damageParticlePrefabNull) { Debug.LogWarning("No damage particle prefab specified"); }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float damage)
    {
        if (damageParticlePrefabNull) { return; }
        Instantiate(damageParticlePrefab, transform.position, Quaternion.identity);
    }
}
