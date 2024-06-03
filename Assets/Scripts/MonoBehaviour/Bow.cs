using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

public class Bow : MonoBehaviour
{
    // Options
    [Header("References")]
    [SerializeField] private BowScriptableObject bow;
    [SerializeField] private GameObject projectile;

    // Static references

    // Private variables
    private bool projectileNull;
    private bool bowScriptableObjectNull;
    private bool cooldownActive;

    // Start is called before the first frame update
    void Start()
    {
        projectileNull = projectile == null;
        bowScriptableObjectNull = bow == null;
        if (projectileNull) { Debug.LogWarning("No projectile prefab specified"); return; }
        if (bowScriptableObjectNull) { Debug.LogWarning("No scriptable object specified"); return; }
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileNull || bowScriptableObjectNull) { return; }

        if (Input.GetMouseButtonDown(1) && !cooldownActive)
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject projectileGameObject = Instantiate(projectile, transform.position, transform.rotation);
        projectileGameObject.GetComponent<Rigidbody>().velocity = bow.velocity;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        cooldownActive = true;
        yield return new WaitForSeconds(bow.cooldown);
        cooldownActive = false;
    }
}
