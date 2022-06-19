using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool ReloadLevel;
    public Animator anim;


    //float curFadeTime = 1f;

    private void Awake()
    {
        instance = this;
    }

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

    public void RestartLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        StartCoroutine(ShadowDeathSwitchScene(curScene.name));
    }

    public void LoadNextLevel(string levelToLoad)
    {
        if(ReloadLevel)
            StartCoroutine(SwitchScene(SceneManager.GetActiveScene().ToString()));
        else
        {
            StartCoroutine(SwitchScene(levelToLoad));
            //SwitchScene(levelToLoad);
        }
            //SceneManager.LoadScene(levelToLoad);
    }


    public IEnumerator SwitchScene(string newScene)
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(newScene);
    }

    public IEnumerator ShadowDeathSwitchScene(string newScene)
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(6.5f);
        SceneManager.LoadScene(newScene);
    }

}
