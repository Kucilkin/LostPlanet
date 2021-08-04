using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset = new Vector3(5.5f, 0, -10);

    private void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
