using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject mainMenuCreditsPanel;
    public GameObject mainMenuControlsPanel;
    public GameObject mainMenuPlayer;

    bool controlsOpen = false;
    bool creditsOpen = false;

    private void Start()
    {
        mainMenuCreditsPanel.SetActive(false);
        mainMenuControlsPanel.SetActive(false);
    }

    public void OnClick_OpenCredits()
    {
        creditsOpen = !creditsOpen;
        if(creditsOpen)
            mainMenuCreditsPanel.SetActive(true);
        if(!creditsOpen)
            mainMenuCreditsPanel.SetActive(false);
    }

    public void OnClick_ExitGame()
    {
        Debug.Log("Quitting the game!");
        Application.Quit();
    }

    public void OnClick_StartGame()
    {
        this.gameObject.SetActive(false);
        mainMenuCreditsPanel.SetActive(false);
        mainMenuControlsPanel.SetActive(false);
        mainMenuPlayer.SetActive(false);
        FindObjectOfType<RelicCutsceneManager>().PlayIntro_Cutscene();
    }

    public void OnClick_Controls()
    {
        controlsOpen = !controlsOpen;

        if(controlsOpen)
            mainMenuControlsPanel.SetActive(true);
        if (!controlsOpen)
            mainMenuControlsPanel.SetActive(false);
    }

}
