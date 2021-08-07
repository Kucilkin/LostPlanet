using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_BatBehaviour : EnemyBase
{
    private Rigidbody2D rb;
    [SerializeField]
    private Transform player;
    private Vector2 playerDetection;
    private Vector2 targetDir;
    [SerializeField]
    private float impulseDelay;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    //Securing a Rigidbody reference for movement method
        player = FindObjectOfType<PlayerController>().transform;
    }
    private void FixedUpdate()
    {
        playerDetection = player.position - transform.position;
        if (playerDetection.magnitude <= 10)
            StartCoroutine("BatMovement");
    }

    private IEnumerator BatMovement()
    {

        rb.AddForce(-transform.up * impulseStr, ForceMode2D.Impulse);
        yield return new WaitForSeconds(impulseDelay / 2);
        rb.AddForce(transform.up * impulseStr, ForceMode2D.Impulse);
        //rb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(impulseDelay);
        if (targetDir == default)
            targetDir = playerDetection;

        rb.AddForce(targetDir.normalized * impulseStr, ForceMode2D.Impulse);
        rb.AddForce(targetDir.normalized * moveSpeed, ForceMode2D.Force);
    }

}
