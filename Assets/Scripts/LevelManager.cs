using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
