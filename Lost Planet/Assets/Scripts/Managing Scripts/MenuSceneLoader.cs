using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour        //Outdated script. Has been replaced by UIManger script as this one became obsolete.
{
    //Kevin's script

    /// <summary>
    /// Load Scene 1 when play button is pressed
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Load Credits scene when credits button is pressed
    /// </summary>
    //public void ShowCredits()
    //{
    //    SceneManager.LoadScene(4);
    //}

    /// <summary>
    /// Close the game or end play mode depending on execution method when quit button is pressed
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    /// <summary>
    /// Returns to the Main Menu Scene when this button is pressed.
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
