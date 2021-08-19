using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    //Kevin's script

    private bool paused;    //bool value for pause state
    [SerializeField]
    private float gameOverDelay;    //Delay before Game Over screen should be shown
    public GameObject PauseMenu;    //Pause Menu Reference
    public GameObject GameOverScreen;   //GameOverScreen Reference
    //public GameObject Player;
    public GameObject BGM;      //Background Music Reference
    public AudioSource DeathCry;    //Deathsound of Player

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
    /// Loads the scene with given Index
    /// </summary>
    /// <param name="_sceneIdx">Build Index of desired scene to be switched to</param>
    public void LoadDesiredScene(int _sceneIdx)
    {
        SceneManager.LoadScene(_sceneIdx);
    }

    /// <summary>
    /// Load Scene 1 when play button is pressed
    /// </summary>
    public void PlayGameBtn()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Pauses the game when Escape is pressed and stops time
    /// </summary>
    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //if escape is pressed...
        {
            paused = !paused;                   //...invert the bool value of paused...
            PauseMenu.SetActive(paused);        //...and set the state of pause menu to bools value...
        }
        if (paused == true)                     //...additionally freeze the game when it's paused and unfreeze if not
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
    public void QuitToMainMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Quits the Application (ends playing mode when in Unity editor)
    /// </summary>
    public void QuitGameBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
        DeathCry.Play();
        yield return new WaitForSeconds(gameOverDelay); //wait for delay before showing game over screen
        GameOverScreen.SetActive(true); //Show the game over screen
    }
}
