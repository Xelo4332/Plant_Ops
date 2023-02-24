using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour // Kacper
{
    public static bool GameIsPaused = false;
    public GameObject _mainUI;
    public GameObject _otherUI;
    public GameObject _pausemenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when "ESC" is pressed...
        {

            if (GameIsPaused) // If the game is paused then resume
            {
                Resume();
            }
            else // and if the game isnt paused then pause it
            {
                Pause();
            }
        }
    }
   public  void Resume() // when game resumed
    {
        //_mainUI.SetActive(true); // turns on the game UI
        //_otherUI.SetActive(true); // turns on some other game UI
        _pausemenuUI.SetActive(false); // turns off the pause menu UI
        Time.timeScale = 1f; // time goes normally
        GameIsPaused = false; // sets the GameIsPaused variable to false
    }

    void Pause() // when game is paused
    {
        //_mainUI.SetActive(false);  // turns off the game UI
        //_otherUI.SetActive(false); // same with some other UI
        _pausemenuUI.SetActive(true); // turns on the Pause UI
        Time.timeScale = 0f; // time goes to 0 = pause
        GameIsPaused = true; // same as above but it becomes true instead
    }

    
}
