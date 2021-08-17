using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    public GameObject UIManager;    //reference for the UIManager so Scenes can be switched
    public GameObject PlayerHP;
    public GameObject HealthBarRef;
    public int NextSceneIDX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.tag == "Diamond")
                UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(NextSceneIDX);  //If the Player collides with this Object, the next scene should be loaded
            if (gameObject.tag == "HPHeart")
            {
                PlayerHP.GetComponent<HealthSystem>().CurrHP += 30f;
                if (PlayerHP.GetComponent<HealthSystem>().CurrHP > PlayerHP.GetComponent<HealthSystem>().MaxHP)
                {
                    PlayerHP.GetComponent<HealthSystem>().CurrHP = PlayerHP.GetComponent<HealthSystem>().MaxHP;
                }
                HealthBarRef.GetComponent<HealthBar>().UpdateHealth(PlayerHP.GetComponent<HealthSystem>().CurrHP);
                Debug.Log("30 HP replenished! Current HP: " + PlayerHP.GetComponent<HealthSystem>().CurrHP);
                Destroy(gameObject);
            }

        }
        //UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(SceneManager.GetActiveScene().buildIndex +1);


    }
}
