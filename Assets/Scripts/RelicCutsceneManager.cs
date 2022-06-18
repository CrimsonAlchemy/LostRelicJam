using UnityEngine;
using UnityEngine.Playables;

public class RelicCutsceneManager : MonoBehaviour
{
    public static RelicCutsceneManager instance;
    public GameObject relicCutscene;
    public GameObject introCutscene;
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
}
