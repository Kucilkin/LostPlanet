using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    public GameObject UIManager;    //reference for the UIManager so Scenes can be switched
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   //If the Player collides with this Object, the next scene should be loaded
            UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(0);
        //UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(SceneManager.GetActiveScene().buildIndex +1);


    }
}
