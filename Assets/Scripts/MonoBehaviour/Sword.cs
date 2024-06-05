using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using UnityEngine;

// Copyright (c) 2024 Love Lysell Berglund

public class Sword : MonoBehaviour
{
    // Options
    [Header("References")]
    [SerializeField] private SwordScriptableObject sword;
    [SerializeField] private Collider hitCollider;

    // Static references

    // Private variables
    private bool hitColliderNull;
    private bool swordScriptableObjectNull;
    private bool cooldownActive;
    private SwordScriptableObject.ComboState[] combo;
    private int comboState;
    private bool progressCombo;
    private bool attacking;
    private bool airCombo;
    private bool previousIsGrounded;
    private IEnumerator comboStateReset;
    private readonly List<GameObject> collidingObjects = new();

    // Start is called before the first frame update
    void Start()
    {
        hitColliderNull = hitCollider == null;
        swordScriptableObjectNull = sword == null;
        if (hitColliderNull) { Debug.LogWarning("No hit collider specified"); }
        if (swordScriptableObjectNull) { Debug.LogWarning("No scriptable object specified"); }
        if (!hitCollider.isTrigger) { Debug.LogWarning("isTrigger must be set on the hit collider"); }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitColliderNull || swordScriptableObjectNull) { return; }

        if (PlayerMovement.Instance.IsGrounded != previousIsGrounded)
        {
            Time.timeScale = 1f;
            airCombo = false;
            combo = sword.groundCombo;
        }

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            StartCoroutine(Attack());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (!collidingObjects.Contains(otherGameObject))
        {
            collidingObjects.Add(otherGameObject);
            if (!cooldownActive) { return; }
            if (!otherGameObject.TryGetComponent(out IDamageable damageable)) { return; }
            float damage = sword.damage * combo[comboState].damageMultiplier;
            damageable.Damage(damage);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Remove works even if the object did not exist in the list
        collidingObjects.Remove(other.gameObject);
    }

    IEnumerator Attack()
    {
        attacking = true;

        if (comboStateReset != null)
        {
            StopCoroutine(comboStateReset);
        }

        if (progressCombo)
        {
            comboState = (comboState + 1) % combo.Length;
        }
        else
        {
            comboState = 0;
            if (cooldownActive) { attacking = false; yield break; }
        }

        yield return new WaitUntil(() => cooldownActive == false);

        comboStateReset = ComboStateReset();
        StartCoroutine(comboStateReset);

        if (comboState == 0)
        {
            airCombo = !PlayerMovement.Instance.IsGrounded;
            if (airCombo)
            {
                Time.timeScale = sword.airComboTimeScale;
            }
            combo = airCombo ? sword.airCombo : sword.groundCombo;
        }

        foreach (GameObject other in collidingObjects)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) { continue; }
            float damage = sword.damage * combo[comboState].damageMultiplier;
            damageable.Damage(damage);
        }

        if (combo[comboState].animationType == SwordScriptableObject.AnimationType.Position)
        {
            StartCoroutine(AnimationPosition(combo[comboState].targetTypeValue, combo[comboState].animationLength));
        }
        else if (combo[comboState].animationType == SwordScriptableObject.AnimationType.Rotation)
        {
            StartCoroutine(AnimationRotation(combo[comboState].targetTypeValue, combo[comboState].animationLength));
        }
        else
        {
            Debug.LogError("Unsupported combo animation type");
        }

        attacking = false;
    }

    IEnumerator ComboStateReset()
    {
        yield return new WaitForSeconds(sword.cooldown - sword.comboWindow);
        progressCombo = true;
        yield return new WaitForSeconds(sword.comboWindow);
        progressCombo = false;
    }

    IEnumerator AnimationRotation(Vector3 rotation, float length)
    {
        cooldownActive = true;
        StartCoroutine(transform.localEulerAngles.LerpOverTime(
            (x) => { transform.localEulerAngles = x; },
            transform.localEulerAngles + rotation,
            length
        ));
        yield return new WaitForSeconds(length);
        float endLength = sword.cooldown - length;
        StartCoroutine(transform.localEulerAngles.LerpOverTime(
            (x) => { transform.localEulerAngles = x; },
            transform.localEulerAngles - rotation,
            endLength
        ));
        yield return new WaitForSeconds(endLength);
        cooldownActive = false;
    }

    IEnumerator AnimationPosition(Vector3 position, float length)
    {
        cooldownActive = true;
        Vector3 startlocalPosition = transform.localPosition;
        StartCoroutine(transform.localPosition.LerpOverTime(
            (x) => { transform.localPosition = x; },
            transform.localPosition + position,
            length
        ));
        yield return new WaitForSeconds(length);
        float endLength = sword.cooldown - length;
        StartCoroutine(transform.localPosition.LerpOverTime(
            (x) => { transform.localPosition = x; },
            startlocalPosition,
            endLength
        ));
        yield return new WaitForSeconds(endLength);
        cooldownActive = false;
    }
}
