using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //Kevin's script

    public Transform Player;    //Position of the Player 
    public Vector3 offset;      //Distance the Camera should have from the Player
    [SerializeField]
    private bool snapToXAxis;   //Option to snap camera to X axis
    [SerializeField]
    private bool snapToYAxis;   //Option to snap camera to Y axis

    private void LateUpdate()
    {
        if (Player == null)
            return;
        if (snapToYAxis == true && snapToXAxis == false)
        transform.position = new Vector3(Player.position.x, transform.position.y, 0) + offset;  /*Constantly make the Camera follow the player's x Position, but remain stationary on
                                                                                                 the other Axes. Lateupdate so there is no Jitter*/
        else if (snapToXAxis == true && snapToYAxis == false)
            transform.position = new Vector3(transform.position.x, Player.position.y, 0) + offset;  //Make the Camera follow the player's y position while remaining stationary on others
        else if (snapToXAxis && snapToYAxis == true)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0) + offset;   //Make the Camera follow the player's x AND y positions
        else if (snapToXAxis && snapToYAxis == false)
            transform.position = new Vector3(Player.position.x, Player.position.y, 0) + offset;     //Make the Camera remain stationary

        //I made all other options just so I have a modular camera script I can use more often in different projects c:
    }
}
