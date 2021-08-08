using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    public GameObject UIManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(0);
        //UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(SceneManager.GetActiveScene().buildIndex +1);


    }
}
