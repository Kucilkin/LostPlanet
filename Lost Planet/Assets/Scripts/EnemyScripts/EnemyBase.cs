using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private float damage;       //The Damage the enemy deals through contact
    public float moveSpeed;     //The movement speed of the enemy

    public float Damage { get { return damage; } }  //Getter for the damage value
    /// <summary>
    /// Movement Method for every enemy. Gets overriden by each enemy type as they move differently
    /// </summary>
    protected virtual void Movement()
    {

    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(GetComponent<EnemyBase>().Damage);
    }
=======
    private float damage;
    public float moveSpeed;

    public float Damage { get { return damage; } }
>>>>>>> main
}
