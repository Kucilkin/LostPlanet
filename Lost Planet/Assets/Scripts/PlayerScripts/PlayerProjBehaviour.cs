using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBehaviour : MonoBehaviour
{
    //Kevin's script

    [SerializeField]
    private float projVelocity;     //Velocity of the projectile
    public GameObject Player;       //Player Reference
    public Vector3 ShotDir;         //Shooting Direction
    public float DespawnTimer;      //Time after which the projectile destroys itself

    //public bool FacingLeftPR;

    void Start()
    {
        Destroy(gameObject, DespawnTimer);  //Destroy the bullet after X seconds of not hitting anything

        #region Old Code
        //ShotDir = Player.transform.right;
        //FacingLeftPR = Player.GetComponent<PlayerController>().FacingLeft;
        //Debug.Log("Is Player facing left: " + FacingLeftPR);
        //if (FacingLeftPR == true)
        //    ShotDir = -transform.right;
        //if (FacingLeftPR == false)
        //    ShotDir = transform.right;

        //if (Player.GetComponent<PlayerController>().FacingLeft == false)
        //    ShotDir = new Vector3(1, 0, 0);
        //else if (Player.GetComponent<PlayerController>().FacingLeft == true)
        //    ShotDir = new Vector3(-1, 0, 0);
        #endregion
    }

    void Update()
    {
        Bulletpattern();
        #region Old Code
        //xInputPR = Input.GetAxisRaw("Horizontal");

        //if (xInputPR < 0 && !FacingLeftPR)
        //{
        //    FacingLeftPR = !FacingLeftPR;
        //}
        //else if (xInputPR > 0 && FacingLeftPR)
        //{
        //    FacingLeftPR = !FacingLeftPR;
        //}
        #endregion
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(PlayerGun.Damage);     //if the bullet collides with an enemy, reduce its HP by damage value of PlayerGun

        Destroy(gameObject);    //Destroy itself after any collision
    }

    public void Bulletpattern()
    {
        Debug.Log("Shot Direction: " + ShotDir);
        transform.position += ShotDir * projVelocity * Time.deltaTime;  //Constantly move towards Shot Direction, which has been set in PlayerGun

        #region Old Code
        //if (FacingLeftPR == true)
        //    transform.position += transform.right * projVelocity * Time.deltaTime;
        //if (FacingLeftPR == false)
        //    transform.position += -transform.right * projVelocity * Time.deltaTime;

        //Player.GetComponentInChildren<PlayerGun>().ShotDir
        //if (Player.GetComponent<PlayerController>().FacingLeft == false)
        //    transform.position += transform.right * projVelocity * Time.deltaTime; //Make the bullet move right multiplied by our speed per second
        //else if (Player.GetComponent<PlayerController>().FacingLeft == true)
        //    transform.position -= transform.right * projVelocity * Time.deltaTime;

        //transform.position += -transform.right * projVelocity * Time.deltaTime; //Make the bullet move left multiplied by our speed per second
        #endregion
    }
}
