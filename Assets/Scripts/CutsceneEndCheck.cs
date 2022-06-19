using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneEndCheck : MonoBehaviour
{
    public bool isEndingScene = false;
    public bool endingOpeningScene = false;
    //bool canDamagePlayer = false;
    private void Update()
    {
        if (GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            //Debug.Log("Test Ending Cutscene");
            if (isEndingScene)
            {
                GameObject.FindObjectOfType<RyanBeattie.PlayerSystems.Player>().canDamage = true;

                AudioManager.instance.PlayOutroMusic();
            }
            else
            {
                //gameObject.SetActive(false);

            }
            
            if (endingOpeningScene)
            {
                LevelManager.instance.LoadNextLevel("DarkZone");
            }
        }
        
    }
}
