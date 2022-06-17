using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicCutsceneManager : MonoBehaviour
{
    public static RelicCutsceneManager instance;
    public GameObject relicCutscene;
    GameObject player;
    public GameObject animationPlayer;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayRelic_Cutscene()
    {
        relicCutscene.SetActive(true);
        player.GetComponent<PlayerMovement>().canMove = false;
        Destroy(player);
    }

}
