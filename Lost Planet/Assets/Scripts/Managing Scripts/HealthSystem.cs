using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Kevin's script

    [SerializeField]
    public float MaxHP;    //Maximum HP  
    public float CurrHP;   //Current HP

    public bool LocatedOnPlayer;

    public GameObject HealthBar;    //HealthBar reference (only relevant for the Player)
    public GameObject UIManager;    //UIManager reference (relevant for calling Game Over)

    private bool IsInvincible;
    [SerializeField]
    private float invincibilityTimer;
    public Animator AnimIFrames;

    private void Start()
    {
        CurrHP = MaxHP;
        if (LocatedOnPlayer == true)    //If this script is located on the Player, modify the HealthBar's Value
            HealthBar.GetComponent<HealthBar>().SetMaxHealth(MaxHP);
    }
    /// <summary>
    /// Subtracts _damage value from current HP of the entity this method gets called by
    /// </summary>
    /// <param name="_damage">The value the HP should be reduced by</param>
    public void GetDamaged(float _damage)
    {
        if (IsInvincible == true)
            return;
        CurrHP -= _damage;
        if (LocatedOnPlayer == true)    //if this script is located on the Player, update the health bar
        {
            HealthBar.GetComponent<HealthBar>().UpdateHealth(CurrHP);
            StartCoroutine("InvincibilityRoutine");
        }
        if (CurrHP <= 0)
            Die();
    }
    /// <summary>
    /// Gets called when the entity has no HP left. Plays the Death animation and Destroys the object afterwards
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
        if (LocatedOnPlayer == true)
            UIManager.GetComponent<UIManagerScript>().GameOver();   //If the Player dies, call Game Over routine in UIManager
    }

    public IEnumerator InvincibilityRoutine()
    {
        IsInvincible = true;
        AnimIFrames.SetBool("IFramesActive", true);
        yield return new WaitForSeconds(invincibilityTimer);
        AnimIFrames.SetBool("IFramesActive", false);
        IsInvincible = false;
    }
}
