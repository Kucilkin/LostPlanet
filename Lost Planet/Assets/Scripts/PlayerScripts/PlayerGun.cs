using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    //Kevin's script

    public GameObject PlayerProj;   //Player Projectile Prefab

    [SerializeField]
    private float shotCooldown;     //The flat delay between shots
    private float currentCooldown;  //The current delay between shots
    private Transform gunPos;        //Variable for the "Gunbarrel"
    static private float damage = 1f;  //Damage Value of current weapon

    static public float Damage { get { return damage; } }   //Getter for damage value

    void Start()
    {
        gunPos = GetComponent<Transform>();     //Getting the position of the "Gunbarrel"
        shotCooldown = 0.25f;    //Defining initial delay between shots
    }
    private void FixedUpdate()
    {
        #region Old Code
        //if (Player.GetComponent<PlayerController>().FacingRight == true)
        //    ShotDir = new Vector3(1,0,0);
        //else
        //    ShotDir = -transform.right;
        #endregion
        Shoot();
    }

    void Shoot()
    {
        if (currentCooldown <= 0)       //If the shot cooldown is 0 seconds or below -> be able to shoot 
        {
            if (Input.GetButton("Fire1"))    //Spawn a player projectile when Mouse 1 is pressed
            {
                PlayerProjBehaviour proj = Instantiate(PlayerProj, gunPos.position, Quaternion.identity).GetComponent<PlayerProjBehaviour>();   //Save spawned bullet as an object
                proj.ShotDir = transform.right;     //Set the ShotDir of saved projectile at each shot. Always transform.right because when player flips so do their x values
                currentCooldown = shotCooldown;     //Reset the shot cooldown after each shot
            }
        }
        else
            currentCooldown -= Time.deltaTime;  //If current cooldown is > 0 -> decrease by 1 each second in real time
    }

}
