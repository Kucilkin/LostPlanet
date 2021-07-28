using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    private float currHP;

    private void Start()
    {
        currHP = maxHP;
    }

    public void GetDamaged(float _damage)
    {
        currHP -= _damage;
        if (currHP <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
