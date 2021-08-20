using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moritz's Script

public class DeathZone : MonoBehaviour
{
    public HealthSystem HealthSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Spieler Tot");
            HealthSystem.Die();
        }
    }
}
