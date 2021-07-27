using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement:
    public float Speed; // Playerspeed
    private float xInput; // Spielereingabe
    private float towardsY = 0f; // Winkel zu dem dem sich der PLayer um eigene Achse dreht
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

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal"); //Eingabesignal fürs laufen
        //GroundCheck(); // GroundCheck aufrufen

        //Drehen:
        //if (xInput > 0f) // nach rechts gehen
        //    towardsY = 0f;
        //else if (xInput < 0f) // nach links gehen
        //    towardsY = 180f;

        //playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, Quaternion.Euler(0f, towardsY, 0f), Time.deltaTime * 10f);

        //Springen:
        if (Input.GetAxisRaw("Jump") > 0f && jumpCounter > 0)
        {
            Vector2 JumpPower = RB.velocity;
            JumpPower.y = JumpForce;
            RB.velocity = JumpPower;
            jumpCounter--;
        }

    }

    private void FixedUpdate()
    {
        if(xInput != 0)
        RB.velocity = new Vector2(xInput * Speed, RB.velocity.y); //Vorfärtsbewegung
    }

    //Groundcheck:
    //void GroundCheck()
    //{
    //    Collider2D checkBox = Physics2D.OverlapBox(FeetTrans.position, CheckBox, 1, GroundLayer);
    //    if (checkBox)
    //    {
    //        jumpCounter = MaxJumps;
    //    }
    //}

    //GroundcheckBox:
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(FeetTrans.position, CheckBox);
    //}
}
