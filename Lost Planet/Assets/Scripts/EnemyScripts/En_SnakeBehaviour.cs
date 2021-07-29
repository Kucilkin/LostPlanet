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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<HealthSystem>().GetDamaged(GetComponent<EnemyBase>().Damage) ;
    }

    
    protected virtual void Movement()
    {
        //rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
        rb.AddForce(moveDir * moveSpeed, ForceMode2D.Force);

    }
}
