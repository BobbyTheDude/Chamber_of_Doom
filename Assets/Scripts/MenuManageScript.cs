using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManageScript : MonoBehaviour
{
    public void LevelOne()
    {
        Debug.Log("Note: Moving to Level One.");
        SceneManager.LoadScene("Level1");
    }
    public void LevelTwo()
    {
        Debug.Log("Note: Moving to Level Two.");
        SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {
        Debug.Log("Note: Quitting application.");
        Application.Quit();
    }
    public void MainMenu()
    {
        Debug.Log("Note: Going back to Main Menu.");
        SceneManager.LoadScene("Startup");
    }
}
