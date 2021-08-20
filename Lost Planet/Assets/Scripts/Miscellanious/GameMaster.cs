using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moritz's Script
public class GameMaster : MonoBehaviour
{
    //aktulle Position
    public GameObject CurrentCheckpoint;
    //Player GameObejct
    public GameObject Player;

    public void RespawnPlayer()
    {
        Player.transform.position = CurrentCheckpoint.transform.position;
    }
}
