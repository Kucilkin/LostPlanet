using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement:
    public float Speed; // Playerspeed
    private float xInput; // Spielereingabe
    //Springen:
    public float JumpForce; //Sprungkraft
    public int MaxJumps; //maximale Sprünge
    private int jumpCounter; //Sprungzähler

    public Rigidbody2D RB;
    public GameObject playerModel;
    //Ground:
    public LayerMask GroundLayer;
    public Vector2 CheckBox;
    public Transform FeetTrans;
    //Dash:
    public float dashDistance = 15f;
    bool isDashing;
    float doubleTaptime;
    KeyCode lastKeyCode;
    //Flip:
    bool facingRight = false;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal"); //Eingabesignal fürs laufen
        GroundCheck(); // GroundCheck aufrufen

        if (xInput < 0 && !facingRight)
        {
            flip();
        }
        else if (xInput > 0 && facingRight)
        {
            flip();
        }

        //Springen:
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            Vector2 JumpPower = RB.velocity;
            JumpPower.y = JumpForce;
            RB.velocity = JumpPower;
            Debug.Log("Jump");
            jumpCounter--;
        }

        //Dash Left:
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTaptime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
            }
            else
            {
                doubleTaptime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }

        //Dash Right:
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTaptime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
            }
            else
            {
                doubleTaptime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.D;
        }
    }

    private void FixedUpdate()
    {
        if (xInput != 0 && !isDashing)
            RB.velocity = new Vector2(xInput * Speed, RB.velocity.y); //Vorfärtsbewegung
    }

    //Drehen:
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);
    }

    //Groundcheck:
    void GroundCheck()
    {
        Collider2D checkBox = Physics2D.OverlapBox(FeetTrans.position, CheckBox, 1, GroundLayer);
        if (checkBox)
        {
            jumpCounter = MaxJumps;
        }
    }

    //GroundcheckBox:
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(FeetTrans.position, CheckBox);
    }

    //Dash:
    IEnumerator Dash(float direction)
    {
        isDashing = true;
        RB.velocity = new Vector2(RB.velocity.x, 0f);
        RB.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = RB.gravityScale;
        RB.gravityScale = 0; //gravity auf 0
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        RB.gravityScale = gravity; //gravity normal
    }
}
