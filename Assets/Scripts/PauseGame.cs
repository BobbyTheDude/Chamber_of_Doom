using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Debug.Log("Paused.");
            }
            else
            {
                Time.timeScale = 1;
                gamePaused = false;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
            }
        }
    }
    public void unPause()
    {
        Time.timeScale = 1;
        gamePaused = false;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }
}
