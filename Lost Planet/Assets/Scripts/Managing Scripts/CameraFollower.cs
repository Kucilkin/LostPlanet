using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Player;    //Position of the Player 
    public Vector3 offset;      //Distance the Camera should have from the Player

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y, 0) + offset;  /*Constantly make the Camera follow the Players x Position, but remain stationary on
                                                                                                 the other Axes. Lateupdate so there is no Jitter*/
    }
}
