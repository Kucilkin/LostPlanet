using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_SnakeBehaviour : MonoBehaviour
{
    [SerializeField]
    protected float maxHP = 5f;
    protected float currHP;
    [SerializeField]
    protected float moveSpeed;
    protected float damage;

    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //maxHP = 3f;
        currHP = maxHP;
        damage = 8f;
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
            //Execute Player's "Damaged" Method
    }

    public void GetDamaged(float _damage)
    {
        currHP -= _damage;
        if (currHP <= 0)
            Destroy(gameObject);
            //Execute "Dying" Method
    }
    protected virtual void Movement()
    {
        rb.MovePosition(transform.position - transform.right * moveSpeed);
    }
}
