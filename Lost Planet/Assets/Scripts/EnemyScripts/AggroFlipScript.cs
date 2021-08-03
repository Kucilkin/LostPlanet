using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroFlipScript : MonoBehaviour
{
    public GameObject Bat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GetComponentInParent<En_BatBehaviour>().aggro = true;
    }
}
