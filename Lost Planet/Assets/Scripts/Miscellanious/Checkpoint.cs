using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameMaster GameMaster;

    void Start()
    {
        GameMaster = FindObjectOfType<GameMaster>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint 1");
            GameMaster.CurrentCheckpoint = gameObject;
        }
    }
}
