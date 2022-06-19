using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionTrigger : MonoBehaviour
{
    public bool isLightZone;
    public bool isDarkZone;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isLightZone)
            {
                LevelManager.instance.LoadNextLevel("RelicRoomEnding");
                //collision.GetComponent<PlayerMovement>().canMove = false;
                collision.GetComponent<RyanBeattie.PlayerSystems.Player>().canDamage = false;
            }
            if (isDarkZone)
            {

                LevelManager.instance.LoadNextLevel("LightZone");
                //collision.GetComponent<PlayerMovement>().canMove = false;
                collision.GetComponent<RyanBeattie.PlayerSystems.Player>().canDamage = false;
            }
            
        }
    }
}
