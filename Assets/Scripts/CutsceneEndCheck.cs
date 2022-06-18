using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneEndCheck : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            Debug.Log("Test Ending Cutscene");
            gameObject.SetActive(false);
        }
        
    }
}
