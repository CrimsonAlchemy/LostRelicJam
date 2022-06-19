using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;

    public bool paused = false;
    public bool inMainMenu = false;

    public void InMainMenu()
    {
        inMainMenu = false;
    }

    private void Start()
    {
        paused = false;
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();
        }

        if (paused)
        {
            if (!inMainMenu)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void TogglePaused()
    {
        paused = !paused;
    }

    public void ResumeGame()
    {
        TogglePaused();
    }

    public void BackToMainMenu()
    {
        paused = false;

        LevelManager.instance.LoadNextLevel("RelicRoomOpening");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game!");
        TogglePaused();
        Application.Quit();
    }

}
