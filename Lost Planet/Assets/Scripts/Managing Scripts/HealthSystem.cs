using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Kevin's script

    [SerializeField]
    public float MaxHP;    //Maximum HP  
    public float CurrHP;   //Current HP

    public bool LocatedOnPlayer;    //Bool value that if checked in inspector, activates functions that should only be executed when this script is located on the player

    public GameObject HealthBar;    //HealthBar reference (only relevant for the Player)
    public GameObject UIManager;    //UIManager reference (relevant for calling Game Over)

    private bool IsInvincible;      //Invincibility state
    [SerializeField]
    private float invincibilityTimer;   //Invincibility duration
    public Animator AnimIFrames;        //Animator for Invincibility Frames

    public Vector2 DeathZoneValue;      //Death Zone Threshold. Player dies instantly when overstepping this border

    private void Start()
    {   
        CurrHP = MaxHP;
        if (LocatedOnPlayer == true)    //If this script is located on the Player, modify the HealthBar's Value
            HealthBar.GetComponent<HealthBar>().SetMaxHealth(MaxHP);
    }
    private void Update()
    {
        if (LocatedOnPlayer == true && gameObject.transform.position.y <= DeathZoneValue.y)
            GetDamaged(100);    //If the player falls below a certain Y Position, Damage them by 100, killing them instantly
    }
    /// <summary>
    /// Subtracts _damage value from current HP of the entity this method gets called by
    /// </summary>
    /// <param name="_damage">The value the HP should be reduced by</param>
    public void GetDamaged(float _damage)
    {
        if (IsInvincible == true)
            return;     //if invincibility is active, ignore consequences of enemy collision
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
    /// <summary>
    /// Activates Invincibility for Duration of invincibility timer
    /// </summary>
    /// <returns></returns>
    public IEnumerator InvincibilityRoutine()
    {
        IsInvincible = true;        //Activate invincibility state
        AnimIFrames.SetBool("IFramesActive", true);     //Play IFrame Animation
        yield return new WaitForSeconds(invincibilityTimer);    //Invincibility timer
        AnimIFrames.SetBool("IFramesActive", false);    //Stop IFrame Animation
        IsInvincible = false;       //Deactivate invincibility state
    }
}
