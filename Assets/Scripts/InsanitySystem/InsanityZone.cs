using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.InsanitySystem
{
    [RequireComponent(typeof(Collider2D))]
    public class InsanityZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerSystems.Player player = collision.GetComponent<PlayerSystems.Player>();

            if(player != null)
            {
                if (player.playerType == PlayerSystems.PlayerType.Human)
                {
                    Debug.Log($"I'm a Human! I am safe in the light!");
                    InsanitySystem.instance.Counting = false;
                }
                if (collision.GetComponent<PlayerSystems.Player>().playerType == PlayerSystems.PlayerType.Shadow)
                {
                    Debug.Log($"Shadow has touched some light! You Are Dead!");
                    //TODO Kill the shadow functionality here
                }
            }


        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerSystems.Player player = collision.GetComponent<PlayerSystems.Player>();

            if (player != null)
            {
                if (collision.GetComponent<PlayerSystems.Player>().playerType == PlayerSystems.PlayerType.Human)
                {
                    Debug.Log($"I'm a Human! Oh No! Shadow monsters are after me, better get to the light!");
                    InsanitySystem.instance.Counting = true;
                }
                if (collision.GetComponent<PlayerSystems.Player>().playerType == PlayerSystems.PlayerType.Shadow)
                {
                    Debug.Log($"I'm a Shadow! I need to stay in the darkness!");
                }
            }

        }
    }

}
