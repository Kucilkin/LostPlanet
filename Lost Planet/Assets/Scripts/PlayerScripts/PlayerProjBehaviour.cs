using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBehaviour : MonoBehaviour
{
    [SerializeField]
    private float projVelocity;
    public GameObject Player;
    public Vector3 ShotDir;
    public float DespawnTimer;

    //public bool FacingLeftPR;

    void Start()
    {
        Destroy(gameObject, DespawnTimer);  //Destroy the bullet after 1.5 seconds of not hitting anything


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
    }

    void Update()
    {
        Bulletpattern();

        //xInputPR = Input.GetAxisRaw("Horizontal");

        //if (xInputPR < 0 && !FacingLeftPR)
        //{
        //    FacingLeftPR = !FacingLeftPR;
        //}
        //else if (xInputPR > 0 && FacingLeftPR)
        //{
        //    FacingLeftPR = !FacingLeftPR;
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(PlayerGun.Damage);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void Bulletpattern()
    {
        Debug.Log("Shot Direction: " + ShotDir);
        transform.position += ShotDir * projVelocity * Time.deltaTime;

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
    }
}
