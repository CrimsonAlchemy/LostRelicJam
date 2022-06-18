using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool ReloadLevel;
    public Animator anim;

    private void Start()
    {
        anim.Play("FadeIn");
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(SwitchScene(SceneManager.GetActiveScene().ToString()));
        //}
    }

    public void LoadNextLevel(string levelToLoad)
    {
        if(ReloadLevel)
            SwitchScene(SceneManager.GetActiveScene().ToString());
        else
            SceneManager.LoadScene(levelToLoad);
    }


    public IEnumerator SwitchScene(string newScene)
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1f);

        LoadNextLevel(newScene);
    }

}
