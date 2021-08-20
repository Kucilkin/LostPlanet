using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupScript : MonoBehaviour
{
    //Kevin's script

    public GameObject UIManager;    //reference for the UIManager so Scenes can be switched
    public GameObject PlayerHP;     //Player reference
    public GameObject HealthBarRef; //Health Bar reference so health bar can be updated when health is replenished
    public int NextSceneIDX;        //Index of Scene that should be loaded when diamond is touched. Configurable in Inspector so every scene can be chosen individually

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger");
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Diamond")
                UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(NextSceneIDX);  //If the Player collides with a Diamond, the next scene should be loaded

            if (gameObject.tag == "HPHeart")
            {
                //float maxPlayerHP = PlayerHP.GetComponent<HealthSystem>().MaxHP;    //Max HP value of Player
                //float currPlayerHP = PlayerHP.GetComponent<HealthSystem>().CurrHP;  //Current HP value of Player
                PlayerHP.GetComponent<HealthSystem>().CurrHP += 30f;        //If the player collides with a Heart, replenish HP by 30

                if (PlayerHP.GetComponent<HealthSystem>().CurrHP > PlayerHP.GetComponent<HealthSystem>().MaxHP)
                    PlayerHP.GetComponent<HealthSystem>().CurrHP = PlayerHP.GetComponent<HealthSystem>().MaxHP;     //However, if the current HP exceed max HP, set current HP to max HP

                HealthBarRef.GetComponent<HealthBar>().UpdateHealth(PlayerHP.GetComponent<HealthSystem>().CurrHP);  //When HP is replenished, update the health bar to current HP
                Debug.Log("30 HP replenished! Current HP: " + PlayerHP.GetComponent<HealthSystem>().CurrHP);
                Destroy(gameObject);    //Destroy the heart object
            }
        }
        //UIManager.GetComponent<UIManagerScript>().LoadDesiredScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
