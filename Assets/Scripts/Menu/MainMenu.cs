using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f; // Time goeas normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // The scene changes by going up by 1
    }


    public void QuitGame() // when this is called the game closes
    {
        Application.Quit();
        Debug.Log("quit");
    }
   
}
