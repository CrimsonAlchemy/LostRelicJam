using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RelicCutsceneManager : MonoBehaviour
{
    public static RelicCutsceneManager instance;
    public GameObject relicCutscene;
    public GameObject introCutscene;
    GameObject player;
    public GameObject animationPlayer;

    public PlayableDirector introPlayableDirector;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayRelic_Cutscene()
    {
        relicCutscene.SetActive(true);
        FindPlayer();
        player.GetComponent<PlayerMovement>().canMove = false;
        player.SetActive(false);
    }

    public void PlayIntro_Cutscene()
    {
        introCutscene.SetActive(true);
        FindPlayer();
        player.GetComponent<PlayerMovement>().canMove = false;
        player.SetActive(false);
    }

    //public void StopPlayingIntroCutscene()
    //{
    //    if (introPlayableDirector.playableGraph.IsDone())
    //    {
    //        introCutscene.SetActive(false);
    //    }
    //}

}
