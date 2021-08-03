using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private float maxHP;    //Maximum HP  
    private float currHP;   //Current HP
=======
    private float maxHP;
    private float currHP;
>>>>>>> main

    private void Start()
    {
        currHP = maxHP;
    }
<<<<<<< HEAD
    /// <summary>
    /// Subtracts _damage value from current HP of the entity this method gets called by
    /// </summary>
    /// <param name="_damage">The value the HP should be reduced by</param>
=======

>>>>>>> main
    public void GetDamaged(float _damage)
    {
        currHP -= _damage;
        if (currHP <= 0)
            Die();
    }
<<<<<<< HEAD
    /// <summary>
    /// Gets called when the entity has no HP left. Plays the Death animation and Destroys the object afterwards
    /// </summary>
=======

>>>>>>> main
    public void Die()
    {
        Destroy(gameObject);
    }
}
