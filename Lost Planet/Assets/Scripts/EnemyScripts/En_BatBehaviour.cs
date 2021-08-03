using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_BatBehaviour : EnemyBase
{
    private Rigidbody2D rb;
    [SerializeField]
    private Transform player;
    private Vector2 targetDir;
    //public bool aggro;

    private void Awake()
    {
       //ggro = false;
        rb = gameObject.GetComponent<Rigidbody2D>();    //Securing a Rigidbody reference for movement method
        player = FindObjectOfType<PlayerController>().transform;
        targetDir = player.position - transform.position;
    }
    private void FixedUpdate()
    {
        if (targetDir.magnitude <= 15)
            StartCoroutine("BatMovement");

        //if (aggro == true)
    }

    private IEnumerator BatMovement()
    {
        rb.AddForce(-transform.up * moveSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        rb.AddForce(targetDir.normalized * moveSpeed, ForceMode2D.Force);

    }

}
