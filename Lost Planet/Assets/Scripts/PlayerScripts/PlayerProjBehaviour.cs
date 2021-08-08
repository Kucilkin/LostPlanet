using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBehaviour : MonoBehaviour
{
    [SerializeField]
    private float projVelocity;
    public GameObject Player;
    public Vector3 ShotDir;


    void Start()
    {
        //if (Player.GetComponent<PlayerController>().FacingRight == true)
        //    ShotDir = transform.right;
        //else if (Player.GetComponent<PlayerController>().FacingRight == false)
        //    ShotDir = -transform.right;
        Destroy(gameObject, 1.5f);  //Destroy the bullet after 1.5 seconds of not hitting anything
    }

    void Update()
    {
        Bulletpattern();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(PlayerGun.Damage);
            Destroy(gameObject);

        }
    }

    public void Bulletpattern()
    {
        //Player.GetComponentInChildren<PlayerGun>().ShotDir
        if (Player.GetComponent<PlayerController>().FacingRight == true)
            transform.position += transform.right * projVelocity * Time.deltaTime; //Make the bullet move upwards multiplied by our speed per second
        else if (Player.GetComponent<PlayerController>().FacingRight == false)
            transform.position += (transform.right * -1) * projVelocity * Time.deltaTime; //Make the bullet move upwards multiplied by our speed per second

    }
}
