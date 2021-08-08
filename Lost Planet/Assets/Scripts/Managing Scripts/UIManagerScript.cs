using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    private bool paused;
    [SerializeField]
    private float gameOverDelay;
    public GameObject PauseMenu;
    public GameObject GameOverScreen;
    //public GameObject Player;
    public GameObject BGM;

    void Start()
    {
        paused = false;
        PauseMenu.SetActive(paused);    //Make sure the pause screen is deactivated at start of scene
        GameOverScreen.SetActive(false);    //Make sure the game over screen is deactivated at start of scene
    }

    void Update()
    {
        PauseGame();    //Constantly check if escape got pressed
    }

    /// <summary>
    /// Pauses the game when Escape is pressed and stops time
    /// </summary>
    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //if escape is pressed 
        {
            paused = !paused;                   //invert the bool value of paused
            PauseMenu.SetActive(paused);        //and set the state of pause menu to bools value
        }
        if (paused == true)                     //additionally freeze the game when it's paused and unfreeze if not
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    /// <summary>
    /// Sets the paused bool to false and resumes the game
    /// </summary>
    public void ResumeBtn()
    {
        paused = !paused;
        PauseMenu.SetActive(paused);
    }

    /// <summary>
    /// Quits the active scene and loads the main menu
    /// </summary>
    public void QuitBtn()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads active scene from beginning to retry the stage
    /// </summary>
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Starts the game over routine
    /// </summary>
    public void GameOver()
    {
        StartCoroutine("C_GameOverRoutine");
    }

    /// <summary>
    /// Coroutine that pauses the game and shows the game over screen after a few seconds after the last hit
    /// </summary>
    /// <returns></returns>
    private IEnumerator C_GameOverRoutine()
    {
        //Destroy(Player);
        Destroy(BGM);
        yield return new WaitForSeconds(gameOverDelay); //wait for delay before showing game over screen
        GameOverScreen.SetActive(true); //Show the game over screen
    }
}
