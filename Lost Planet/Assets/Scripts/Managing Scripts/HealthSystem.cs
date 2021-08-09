using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public float MaxHP;    //Maximum HP  
    public float CurrHP;   //Current HP
    public GameObject HealthBar;    //HealthBar reference (only relevant for the Player)

    private void Start()
    {
        CurrHP = MaxHP;
        if (this.gameObject.tag == "Player")    //If this script is located on the Player, modify the HealthBar's Value
            HealthBar.GetComponent<HealthBar>().SetMaxHealth(MaxHP);
    }
    /// <summary>
    /// Subtracts _damage value from current HP of the entity this method gets called by
    /// </summary>
    /// <param name="_damage">The value the HP should be reduced by</param>
    public void GetDamaged(float _damage)
    {
        CurrHP -= _damage;
        if (this.gameObject.tag == "Player")    //if this script is located on the Player, update the health bar
            HealthBar.GetComponent<HealthBar>().UpdateHealth(CurrHP);
        if (CurrHP <= 0)
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
