using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingCutsceneManager : MonoBehaviour
{
    public static EndingCutsceneManager instance;

    public GameObject playersEnteringScene;
    GameObject player;
    

    private void Awake()
    {
        instance = this;
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OpeningCutscene()
    {
        FindPlayer();
        playersEnteringScene.SetActive(true);
        player.GetComponent<PlayerMovement>().canMove = false;
        player.SetActive(false);
    }

}