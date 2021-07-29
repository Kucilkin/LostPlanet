using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private float damage;
    public float moveSpeed;

    public float Damage { get { return damage; } }
}
