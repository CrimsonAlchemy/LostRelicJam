using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DhruvS28.LightSystem
{
    public enum dir
    {
        Up,
        Right,
        Down,
        Left
    };

    [System.Serializable]
    public class PathRecorder
    {
        public dir direction = dir.Up;
        public int distance;
    }


    public class FireflyControls : MonoBehaviour
    {
        [Header("General Details")]
        [Range(1, 15)] public float moveSpeed;

        [Space(10)]
        [Header("Defined Path")]

        [Tooltip("Add the directions in which the firefly should move ")]
        //public List<Tuple<String, int>> patrolPoints;
        public PathRecorder[] fireflyPathing;

        [Space(10)]

        private bool moving;
        private Transform startPoint;
        private Vector3 moveDirection;

        //[HideInInspector]
        public List<Vector3> movePoints;
        private int currentPoint = 0;



        private float timestamp;


        Rigidbody2D theRigidbody;
        GameObject player;



        private void Start()
        {
            if (theRigidbody == null)
                theRigidbody = GetComponent<Rigidbody2D>();
            //if (player == null)
            //    player = FindObjectOfType<RyanBeattie.PlayerSystems.Player>().gameObject;

            startPoint = this.transform;
            timestamp = Time.time + 2f;

            GetPositionPoints();
        }

        private void Update()
        {
            //FlyingAroundState();
            //CheckPosition();
            if (timestamp <= Time.time && !moving)
            {
                timestamp = Time.time + 1f;
                Debug.Log("1 second delay");
                moving = true;
            }
            Moving();
        }

        void GetPositionPoints()
        {
            foreach (var point in fireflyPathing)
            {
                //Debug.Log($"{transform.position}");
                //Debug.Log($"{point.direction} ==> {point.distance}");

                switch ((point.direction).ToString())
                {
                    case "Up":
                        moveDirection = new Vector3(transform.position.x, transform.position.y + point.distance, transform.position.z);
                        break;
                    case "Right":
                        moveDirection = new Vector3(transform.position.x + point.distance, transform.position.y, transform.position.z);
                        break;
                    case "Down":
                        moveDirection = new Vector3(transform.position.x, transform.position.y - point.distance, transform.position.z);
                        break;
                    case "Left":
                        moveDirection = new Vector3(transform.position.x - point.distance, transform.position.y, transform.position.z);
                        break;
                    default:
                        break;
                }

                movePoints.Add(moveDirection);
            }
        }

        private IEnumerator move()
        {
            //Vector3 goingTO = movePoints[currentPoint] - transform.position;

            //if (Vector2.Distance(transform.position, movePoints[currentPoint]) < 0.1f)
            //{
                yield return new WaitForSeconds(0.5f);
            //    Debug.Log(transform.position);
            //    currentPoint++;
            //    if (currentPoint >= movePoints.Count)
            //    {
            //        currentPoint = 0;
            //    }
            //}
            //goingTO.Normalize();
            //theRigidbody.velocity = goingTO * moveSpeed;

            //yield return move();
        }


        void Moving()
        {
            Vector3 goingTO = movePoints[currentPoint] - transform.position;

            if (Vector2.Distance(transform.position, movePoints[currentPoint]) < 0.1f)
            {
                transform.position = movePoints[currentPoint];
                Debug.Log(transform.position);
                currentPoint++;
                if (currentPoint >= movePoints.Count)
                {
                    currentPoint = 0;
                }
            }
            goingTO.Normalize();
            theRigidbody.velocity = goingTO * moveSpeed;
        }
    }
}