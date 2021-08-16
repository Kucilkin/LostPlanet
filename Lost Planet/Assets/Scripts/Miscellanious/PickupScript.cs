using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    public GameObject UIManager;    //reference for the UIManager so Scenes can be switched
    public GameObject PlayerHP;
    public int NextSceneIDX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Diamond")
                UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(NextSceneIDX);  //If the Player collides with this Object, the next scene should be loaded
            if (gameObject.tag == "HPHeart")
            {
                PlayerHP.GetComponent<HealthSystem>().CurrHP += 35f;
                if (PlayerHP.GetComponent<HealthSystem>().CurrHP > PlayerHP.GetComponent<HealthSystem>().MaxHP)
                {
                    PlayerHP.GetComponent<HealthSystem>().CurrHP = PlayerHP.GetComponent<HealthSystem>().MaxHP;
                    Destroy(gameObject);
                }
            }

        }
        //UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(SceneManager.GetActiveScene().buildIndex +1);


    }
}
