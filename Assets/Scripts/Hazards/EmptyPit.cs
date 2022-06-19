using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.Hazards
{
    public class EmptyPit : MonoBehaviour
    {

        public GameObject shadowFallingAnim;
        public Sprite human;
        public Sprite shadow;

        //This to play the human or shadow animation.
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                //shadowFallingAnim.transform.position = collision.transform.position;
                if(collision.GetComponent<PlayerSystems.Player>().playerType == RyanBeattie.PlayerSystems.PlayerType.Human)
                {
                    shadowFallingAnim.GetComponent<SpriteRenderer>().sprite = human;
                }
                else
                {
                    shadowFallingAnim.GetComponent<SpriteRenderer>().sprite = shadow;

                }
                shadowFallingAnim.transform.position = transform.position;
                PlayerSystems.Player.A_PlayerDeath?.Invoke();
                Destroy(collision.gameObject);
                shadowFallingAnim.SetActive(true);


                //LevelManager.instance.RestartLevel();

                //TODO Audio Testing for pit fall
                AudioManager.instance.StopFeetsteps();
                AudioManager.instance.StopHeartbeat();
            }
        }
    }
}

