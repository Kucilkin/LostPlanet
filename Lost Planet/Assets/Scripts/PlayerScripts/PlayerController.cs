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
    [SerializeField]
    public int MaxJumps;//maximale Spr?nge
    [SerializeField]
    private int jumpCounter; //Sprungz?hler

    private Animator anim;
    private Rigidbody2D RB;
    public GameObject playerModel;
    //Ground:
    public LayerMask GroundLayer;
    public Vector2 CheckBox;
    public Transform FeetTrans;
    //Dash:
    bool isDashing;
    public float DashForce = 15f;
    public float StartDashTimer;

    float CurrentDashTimer;
    float DashDirection;
    [SerializeField]
    public float DashCoolDown = 5f;
    private float nextDashTime;
    //Flip:
    public bool FacingLeft;

    

    void Start()
    {
        jumpCounter = MaxJumps;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal"); //Eingabesignal f?rs laufen

        if (RB.velocity.y <= 0)
            GroundCheck(); // GroundCheck aufrufen

        if (xInput < 0 && !FacingLeft)
        {
            Flip();
        }
        else if (xInput > 0 && FacingLeft)
        {
            Flip();
        }

        //Springen:
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            Vector2 JumpPower = RB.velocity;
            JumpPower.y = JumpForce;
            RB.velocity = JumpPower;
            Debug.Log("Jump");
            jumpCounter--;
            Debug.Log("JumpCounter: " + jumpCounter);
        }

        //Dash:
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumpCounter <= 1 && xInput != 0 && Time.time > nextDashTime)
        {
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            RB.velocity = Vector2.zero;
            DashDirection = xInput;
            
            Debug.Log("TimeTime: " + Time.time);
            nextDashTime = Time.time + DashCoolDown;
            jumpCounter = 0;
        }

        if (isDashing)
        {
            RB.velocity = transform.right * DashForce;
            Debug.Log("velocity: " + RB.velocity);
            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                isDashing = false;
            }
        }

        Animations();
        GravityReset();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
            RB.velocity = new Vector2(xInput * Speed, RB.velocity.y); //Vorf?rtsbewegung
    }

    //Drehen:
    void Flip()
    {
        FacingLeft = !FacingLeft;
        transform.Rotate(0, 180f, 0);
    }

    //Groundcheck:
    void GroundCheck()
    {

        Collider2D checkBox = Physics2D.OverlapBox(FeetTrans.position, CheckBox, 1, GroundLayer);
        if (checkBox)
        {
            jumpCounter = MaxJumps;
            Debug.Log("Groundcheck");
        }
    }

    //GroundcheckBox:
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(FeetTrans.position, CheckBox);
    }

    //Dash:
    //IEnumerator Dash(float direction)
    //{
    //    isDashing = true;
    //    RB.velocity = new Vector2(RB.velocity.x, 0f);
    //    RB.AddForce(new Vector2(DashForce * direction, 0f), ForceMode2D.Impulse);
    //    float gravity = RB.gravityScale;
    //    RB.gravityScale = 0; //gravity auf 0
    //    yield return new WaitForSeconds(0.4f);
    //    isDashing = false;
    //    RB.gravityScale = 5; //gravity normal
    //}

    void Animations()
    {
        anim.SetFloat("xInputAbs", Mathf.Abs(xInput));
        anim.SetFloat("yVelocity", RB.velocity.y);
    }

    void GravityReset()
    {
        if (Input.GetKeyDown(KeyCode.G))
            RB.gravityScale = 5;
    }
}
