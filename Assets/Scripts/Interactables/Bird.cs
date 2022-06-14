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
        public bool patrolling = false;
        [SerializeField] GameObject textbox;
        public float moveSpeed = 2f;

        [Space(10)]
        [Header("Bird Move Points")]
        [Tooltip("This is a single transform point in the world where the bird will be in an idle state.")]
        public Transform idlePoint;
        [Tooltip("These are several transforms for the bird to travel between.")]
        public Transform[] patrolPoints;
        public Transform[] shadowAbsorbPoints;

        private int currentPatrolPoint;
        private Vector3 moveDirection;

        Rigidbody2D theRigidbody;
        GameObject player;

        bool shadowAbsorbAnim = false;
        bool resting = true;
        float restingTime = 0f;
        float maxRestingTime = 3.0f;

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
            BirdCurrentState();
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
                        textbox.SetActive(true);
                    }
                    else
                    {
                        PlayerExitingBirdsShadow();
                    }
                }
            }
        }

        public GameObject absorbEffectPrefab;
        void PlayerInBirdsShadow()
        {
            if(player != null)
            {
                player.SetActive(false);
                playerInShadow = true;
                canInteract = true;

                PlayerSystems.ShadowDamageManager.instance.Counting = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                FindObjectOfType<CameraFollow>().player = gameObject.transform;

                //Testing
                GameObject asorbEffect;
                asorbEffect = absorbEffectPrefab;
                asorbEffect.GetComponent<AbsorbEffect>().shadowMovePoints = shadowAbsorbPoints;
                Instantiate(asorbEffect, player.transform.position, Quaternion.identity);
            }
        }

        void PlayerExitingBirdsShadow()
        {
            FindObjectOfType<CameraFollow>().player = player.transform;
            player.GetComponent<PlayerMovement>().enabled = true;


            playerInShadow = false;
            resting = true;
            restingTime = 0;
            currentPatrolPoint = 0;

            player.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            player.SetActive(true);

            //Testing
            AbsorbEffect[] effects = FindObjectsOfType<AbsorbEffect>();
            foreach (var effect in effects)
            {
                Destroy(effect.gameObject);
            }

        }

        void Moving()
        {
            if (!shadowAbsorbAnim)
            {
                moveDirection.Normalize();
                theRigidbody.velocity = moveDirection * moveSpeed;
            }
        }

        #region Birds Different States
        void BirdCurrentState()
        {
            if (playerInShadow)
            {
                PatrolState();
            }
            if (!playerInShadow)
            {
                RestingState();
            }
        }
        void RestingState()
        {
            if(Vector2.Distance(transform.position, idlePoint.position) > 0.2f && resting)
            {
                moveDirection = idlePoint.position - transform.position;
                Moving();
            }
            if(Vector2.Distance(transform.position, idlePoint.position) < 0.2f && resting)
            {
                transform.position = idlePoint.position;
                if(restingTime < maxRestingTime)
                {
                    restingTime += Time.deltaTime;
                }
            }
            if(restingTime >= maxRestingTime)
            {
                FlyingAroundState();
            }
        }
        void FlyingAroundState()
        {
            moveDirection = patrolPoints[currentPatrolPoint].position - transform.position;
            resting = false;
            restingTime = maxRestingTime;

            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.3f)
            {
                currentPatrolPoint++;
                if (currentPatrolPoint >= patrolPoints.Length)
                {
                    resting = true;
                    currentPatrolPoint = 0;
                    restingTime = 0;
                    RestingState();
                }
            }
            Moving();
        }
        void PatrolState()
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
        #endregion
    }
}