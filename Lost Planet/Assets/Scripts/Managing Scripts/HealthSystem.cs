using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public float maxHP;    //Maximum HP  
    public float currHP;   //Current HP
    public GameObject HealthBar;

    private void Start()
    {
        currHP = maxHP;
        if (this.gameObject.tag == "Player")
            HealthBar.GetComponent<HealthBar>().SetMaxHealth(maxHP);
    }
    /// <summary>
    /// Subtracts _damage value from current HP of the entity this method gets called by
    /// </summary>
    /// <param name="_damage">The value the HP should be reduced by</param>

    public void GetDamaged(float _damage)
    {
        currHP -= _damage;
        if (this.gameObject.tag == "Player")
            HealthBar.GetComponent<HealthBar>().UpdateHealth(currHP);
        if (currHP <= 0)
            Die();
    }
    /// <summary>
    /// Gets called when the entity has no HP left. Plays the Death animation and Destroys the object afterwards
    /// </summary>

    public void Die()
    {
        Destroy(gameObject);
    }
}
