using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject PlayerProj;   //Player Projectile Prefab

    [SerializeField]
    private float shotCooldown;     //The flat delay between shots
    private float currentCooldown;  //The current delay between shots
    private Transform gunPos;        //Variable for the "Gunbarrel"
    static private float damage = 1f;  //Damage Value of current weapon

    static public float Damage { get { return damage; } }

    void Start()
    {
        gunPos = GetComponent<Transform>();     //Getting the position of the "Gunbarrel"
        shotCooldown = 0.25f;    //Defining initial delay between shots

    }
    private void FixedUpdate()
    {
        Shoot();    //Should always be executed when Cooldown is over and Mouse 1 is pressed
    }

    void Shoot()
    {
        //Shooting
        if (currentCooldown <= 0)       //If the shot cooldown is 0 seconds or below -> be able to shoot 
        {
            if (Input.GetButton("Fire1"))    //Spawn a player projectile when Mouse 1 is pressed
                Instantiate(PlayerProj, gunPos.position, Quaternion.identity);
            currentCooldown = shotCooldown;     //Reset the shot cooldown after each shot
        }
        else
            currentCooldown -= Time.deltaTime;  //If current cooldown is < 0 -> decrease by 1 second real time
    }

}
