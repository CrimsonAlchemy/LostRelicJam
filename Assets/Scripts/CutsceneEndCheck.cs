using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneEndCheck : MonoBehaviour
{
    public bool isEndingScene = false;
    public bool endingOpeningScene = false;

    private void Update()
    {
        if (GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            //Debug.Log("Test Ending Cutscene");
            if (isEndingScene)
            {
                AudioManager.instance.PlayOutroMusic();
            }
            else
            {
                gameObject.SetActive(false);

            }
            
            if (endingOpeningScene)
            {
                LevelManager.instance.LoadNextLevel("DarkZone");

            }
            
        }
        
    }
}
