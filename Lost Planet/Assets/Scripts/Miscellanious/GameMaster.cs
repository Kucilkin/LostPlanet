using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //aktulle Position
    public static GameObject CurrentCheckpoint;
    //Player GameObejct
    public GameObject Player;


    private void Awake()
    {
        if (CurrentCheckpoint != null)
        {


            Player.transform.position = CurrentCheckpoint.transform.position;
            Debug.Log("checkpoint set by GameMaster");
        }
            
    }

    public void RespawnPlayer()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
    }
}
