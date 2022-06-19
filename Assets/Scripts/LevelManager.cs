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

    public void ShadowDeath_RestartLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        StartCoroutine(ShadowDeathSwitchScene(curScene.name));
    }

    public void PlayerDeath_ReloadLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        StartCoroutine(PlayerDeathSwitchScene(curScene.name));
    }

    public void LoadNextLevel(string levelToLoad)
    {
        if(ReloadLevel)
            StartCoroutine(SwitchScene(SceneManager.GetActiveScene().ToString()));
        else
        {
            StartCoroutine(SwitchScene(levelToLoad));
        }

    }

    public void PitFall_ReloadLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        StartCoroutine(PitFallSwitchScene(curScene.name));
    }

    public IEnumerator SwitchScene(string newScene)
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(newScene);
    }

    public IEnumerator ShadowDeathSwitchScene(string newScene)
    {
        yield return new WaitForSeconds(1f);
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(newScene);
    }

    public IEnumerator PlayerDeathSwitchScene(string newScene)
    {
        yield return new WaitForSeconds(2f);
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(newScene);
    }
    public IEnumerator PitFallSwitchScene(string newScene)
    {
        yield return new WaitForSeconds(1.2f);
        anim.Play("FadeOut");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(newScene);
    }

}
