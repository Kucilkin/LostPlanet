using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y, 0) + offset;
    }
}
