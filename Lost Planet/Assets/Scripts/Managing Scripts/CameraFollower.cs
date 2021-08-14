using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Player;    //Position of the Player 
    public Vector3 offset;      //Distance the Camera should have from the Player
    [SerializeField]
    private bool snapToXAxis;
    [SerializeField]
    private bool snapToYAxis;



    private void LateUpdate()
    {
        if (snapToYAxis == true && snapToXAxis == false)
        transform.position = new Vector3(Player.position.x, transform.position.y, 0) + offset;  /*Constantly make the Camera follow the Players x Position, but remain stationary on
                                                                                                 the other Axes. Lateupdate so there is no Jitter*/
        else if (snapToXAxis == true && snapToYAxis == false)
            transform.position = new Vector3(transform.position.x, Player.position.y, 0) + offset;
        else if (snapToXAxis && snapToYAxis == true)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0) + offset;
        else if (snapToXAxis && snapToYAxis == false)
            transform.position = new Vector3(Player.position.x, Player.position.y, 0) + offset;



    }
}
