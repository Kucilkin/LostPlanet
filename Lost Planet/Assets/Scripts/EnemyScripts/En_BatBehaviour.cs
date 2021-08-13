using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_BatBehaviour : EnemyBase
{
    private Rigidbody2D rb;
    [SerializeField]
    private Transform player;       //Player Position

    [SerializeField]
    private Animator animFlying;

    private Vector2 playerDetection;    //A Vector to determine the distance from Bat to Player
    public float PlayerDetectionRange;
    private Vector2 targetDir;  //Position the Bat charges at
    [SerializeField]
    private float impulseDelay; //Duration between movement "impulses"

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    //Securing a Rigidbody reference for movement method
        player = FindObjectOfType<PlayerController>().transform;    //Securing the player's Position
    }
    private void FixedUpdate()
    {
        playerDetection = player.position - transform.position; //Constantly draws a Vector bewtween own and the player's Position
        if (playerDetection.magnitude <= PlayerDetectionRange)    //As soon as player's distance to Bat is below 10 -> Enable Movement
            StartCoroutine("BatMovement");
    }
    /// <summary>
    /// The Bat's Movement Method.
    /// </summary>
    /// <returns></returns>
    private IEnumerator BatMovement()
    {

        rb.AddForce(-transform.up * impulseStr, ForceMode2D.Impulse);   //First, move down from the ceiling where the Bat is located
        yield return new WaitForSeconds(impulseDelay / 2);      //Wait before next Move (Divided by 2 just to make it shorter than the next Move)
        animFlying.SetBool("OnAggro", true);
        rb.AddForce(transform.up * impulseStr, ForceMode2D.Impulse);    //Try to counteract the momentum from the initial push
        //rb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(impulseDelay);
        if (targetDir == default)
            targetDir = playerDetection;
        Destroy(gameObject, 3);

        rb.AddForce(targetDir.normalized * impulseStr, ForceMode2D.Impulse);
        rb.AddForce(targetDir.normalized * moveSpeed, ForceMode2D.Force);
    }

}
