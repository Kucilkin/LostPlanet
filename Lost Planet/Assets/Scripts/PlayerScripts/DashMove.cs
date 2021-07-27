using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float DashSpeed;
    private float dashTime;
    public float StartDashTime;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = StartDashTime;
    }

    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = StartDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * DashSpeed;
                }
                else if(direction == 2)
                {
                    rb.velocity = Vector2.right * DashSpeed;
                }
            }
        }
    }
}
