using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjBehaviour : MonoBehaviour
{
    [SerializeField]
    private float projVelocity;

    void Start()
    {
        Destroy(gameObject, 1.5f);  //Destroy the bullet after 1.5 seconds of not hitting anything
    }

    void Update()
    {
        Bulletpattern();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<En_SnakeBehaviour>().GetDamaged(PlayerGun.Damage);
            Destroy(gameObject);

        }
    }

    public void Bulletpattern()
    {
        transform.position += transform.right * projVelocity * Time.deltaTime; //Make the bullet move upwards multiplied by our speed per second

    }
}
