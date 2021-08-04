using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_SnakeBehaviour : EnemyBase
{

    private Rigidbody2D rb;
    private Vector2 moveDir;

    public SpriteRenderer SnakeSprite;
    private bool objectFlip;

    public LayerMask GroundLayer;
    public Vector2 BoxDimG;     //Box Dimensions Ground
    public Vector2 BoxDimW;     //Box Dimensions Wall
    public Transform GroundBox;
    public Transform WallBox;


    private void Awake()
    {
        moveDir = Vector2.left;
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

    private void TurnCheck()
    {
        Collider2D groundBox = Physics2D.OverlapBox(GroundBox.position, BoxDimG, 1, GroundLayer);
        Collider2D wallBox = Physics2D.OverlapBox(WallBox.position, BoxDimW, 1, GroundLayer);

        //if (objectFlip == true)
            //gameObject.transform.rotation.y



       //    if (groundBox == false || wallBox == true)
       //    gameObject.transform.rotation.y += 180;
    }



    //protected virtual void Movement()
    //{
    //    //Vector2 moveVelocity = new Vector2()
    //    rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
    //    //rb.AddForce(GetComponent<EnemyBase>().moveSpeed)

    //}
}
