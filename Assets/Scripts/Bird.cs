using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.Iteractables
{
    public class Bird : MonoBehaviour
    {
        [Header("General Details")]
        public bool canInteract = false;
        public bool playerInShadow = false;
        [SerializeField] GameObject textbox;
        public float moveSpeed = 5f;

        [Space(10)]
        [Header("Bird Move Points")]
        [Tooltip("This is a single transform point in the world where the bird will be in an idle state.")]
        public Transform idlePoint;
        [Tooltip("These are several transforms for the bird to travel between.")]
        public Transform[] patrolPoints;

        private int currentPatrolPoint;
        private Vector3 moveDirection;
        Rigidbody2D theRigidbody;
        GameObject player;

        private void Start()
        {
            if(theRigidbody == null)
                theRigidbody = GetComponent<Rigidbody2D>();
            if(player == null)
                player = FindObjectOfType<RyanBeattie.PlayerSystems.Player>().gameObject;
        }

        private void Update()
        {
            Interact();
            PatrolToPoints();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canInteract = true;
                textbox.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canInteract = false;
                textbox.SetActive(false);
            }
        }

        public void Interact()
        {
            if (canInteract/* || playerInShadow*/)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerInShadow = !playerInShadow;

                    if (playerInShadow)
                    {
                        PlayerInBirdsShadow();
                    }
                    else
                    {
                        PlayerExitingBirdsShadow();
                    }
                }
            }
        }

        void PlayerInBirdsShadow()
        {
            if(player != null)
            {
                player.SetActive(false);
                playerInShadow = true;
                canInteract = true;
            }
        }

        void PlayerExitingBirdsShadow()
        {
            playerInShadow = false;
            currentPatrolPoint = 0;
            player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            player.SetActive(true);
        }

        void Moving()
        {
            moveDirection.Normalize();
            theRigidbody.velocity = moveDirection * moveSpeed;
        }

        void PatrolToPoints()
        {
            //To loop between patrol points.
            if (playerInShadow)
            {
                InsanitySystem.InsanitySystem.instance.Counting = false;

                moveDirection = patrolPoints[currentPatrolPoint].position - transform.position;

                if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.3f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }
                }
                Moving();
            }

            //To move the bird to the Idle resting position in the level.
            if (!playerInShadow)
            {
                moveDirection = idlePoint.position - transform.position;
                if(Vector2.Distance(transform.position, idlePoint.position) > 0.2f)
                {
                    Moving();
                }
                else
                {
                    transform.position = idlePoint.position;
                }
            }
        }
    }
}

