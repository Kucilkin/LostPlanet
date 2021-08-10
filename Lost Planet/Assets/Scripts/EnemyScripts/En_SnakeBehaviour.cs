using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_SnakeBehaviour : EnemyBase
{
    //Members for movement
    private Rigidbody2D rb;     //Rigidbody reference
    private Vector2 moveDir;    //Movement Direction 

    //Members for object turning
    private bool objectFlip;    //Bool Value for object flip
    public LayerMask GroundLayer;   //Layer to be checked for collision
    public Vector2 BoxDimG;     //Box Dimensions Ground
    public Vector2 BoxDimW;     //Box Dimensions Wall
    public Transform GroundBox; //Position of Groundcheckbox
    public Transform WallBox;   //Position of Wallcheckbox


    private void Awake()
    {
        moveDir = Vector2.left; //Default Move Direction when spawning
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        TurnCheck();
    }

    protected override void Movement()
    {
        //rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
        rb.AddForce(moveDir * impulseStr, ForceMode2D.Impulse); //When first starting to move, get a little push to not accelerate slowly
        rb.AddForce(moveDir * moveSpeed, ForceMode2D.Force);    //Move towards moveDir at constant speed
    }
    /// <summary>
    /// Checks if the Object needs to flip on the verical axis.
    /// </summary>
    private void TurnCheck()
    {
        Collider2D groundBox = Physics2D.OverlapBox(GroundBox.position, BoxDimG, 1, GroundLayer);   //Set up a Checkbox for Ground-collision-check
        Collider2D wallBox = Physics2D.OverlapBox(WallBox.position, BoxDimW, 1, GroundLayer);       //Set up a Checkbox for Wall-coliision-check



        if (groundBox == false || wallBox == true)  //As soon as either the groundbox doesn't touch the ground or the wallbox touches the ground: flip the bool value
        {
            objectFlip = !objectFlip;
            if (objectFlip == true)     //if the flip is true: Flip the object on the vertical axis so it faces right
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else                        //else flip it back so it faces left
                transform.rotation = Quaternion.Euler(0, 0, 0);

            moveDir.x *= -1;    //Invert the X-position the Snake moves towards by multiplying it by -1 (if it's currently -1 then negative * negative = positive and vice versa)
            rb.AddForce(moveDir * impulseStr, ForceMode2D.Impulse);     //Add another small push at every turn so it doesn't accelerate slowly
        }
    }

    private void OnDrawGizmos()
    {
        //Draw the Checkboxes for visualisation
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(WallBox.position, BoxDimW);
        Gizmos.DrawWireCube(GroundBox.position, BoxDimG);
    }

    //protected virtual void Movement()
    //{
    //    //Vector2 moveVelocity = new Vector2()
    //    rb.MovePosition(transform.position - transform.right * GetComponent<EnemyBase>().moveSpeed);
    //    //rb.AddForce(GetComponent<EnemyBase>().moveSpeed)

    //}
}
