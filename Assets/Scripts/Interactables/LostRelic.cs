using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RyanBeattie.Iteractables
{
    public class LostRelic : MonoBehaviour
    {
        public bool canInteract = false;
        [SerializeField] GameObject textbox;
        public bool isEndGame;

        public bool IntButtonClicked;

        private void Update()
        {
            Interact();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canInteract = true;
                textbox.SetActive(true);
                //InteractButton.enabled = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canInteract = false;
                textbox.SetActive(false);
                //InteractButton.enabled = false;
            }
        }

        public void Interact()
        {
            if (canInteract)
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0) || IntButtonClicked)
                {
                    //Debug.Log("Interacted with the Lost Relic.");
                    if (!isEndGame)
                    {
                        RelicCutsceneManager.instance.PlayRelic_Cutscene();
                        canInteract = false;
                    }
                    if (isEndGame)
                    {
                        EndingCutsceneManager.instance.ConnectingScene();
                        canInteract = false;
                    }

                    IntButtonClicked = false;
                }
            }
        }

        public void ButtonClick()
        {
            IntButtonClicked = true;
        }
    }

}
