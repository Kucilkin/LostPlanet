using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //Kevin's script

    [SerializeField]
    private float damage;       //The Damage the enemy deals through contact
    public float moveSpeed;     //The movement speed of the enemy
    public float impulseStr;    //If needed, the enemy has a little push when initially moving so it doesn't accelerate slowly

    public float Damage { get { return damage; } }  //Getter for the damage value
    /// <summary>
    /// Movement Method for every enemy. Gets overriden by each enemy type as they move differently
    /// </summary>
    protected virtual void Movement() {    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")   //On Collision with the Player -> Call the GetDamaged Method of the player's HealthSystem Script
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(GetComponent<EnemyBase>().Damage);
    }
}
