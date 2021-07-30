using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_SnakeBehaviour : EnemyBase
{

    private Rigidbody2D rb;
    private Vector2 moveDir = Vector2.left;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Movement();
    }
   

    
    protected override void Movement()
    {
        //rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
        rb.AddForce(moveDir * moveSpeed, ForceMode2D.Force);

    }
}
