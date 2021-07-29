using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_SnakeBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

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
        //Vector2 moveVelocity = new Vector2()
        rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
        //rb.AddForce(GetComponent<EnemyBase>().moveSpeed)

    }
}
