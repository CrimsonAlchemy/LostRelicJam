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
        private bool paused;
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

            startPoint = this.transform;
            timestamp = Time.time + 2f;

            movePoints.Add(startPoint.position);
            GetPositionPoints();
        }

        private void Update()
        {

            //if (timestamp <= Time.time && !moving)
            //{
            //    timestamp = Time.time + 1f;
            //    Debug.Log("1 second delay");
            //    moving = true;
            //}

            if (!paused)
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
                        moveDirection = new Vector3(movePoints[movePoints.Count-1].x, movePoints[movePoints.Count-1].y + point.distance, movePoints[movePoints.Count-1].z);
                        break;
                    case "Right":
                        moveDirection = new Vector3(movePoints[movePoints.Count-1].x + point.distance, movePoints[movePoints.Count-1].y, movePoints[movePoints.Count-1].z);
                        break;
                    case "Down":
                        moveDirection = new Vector3(movePoints[movePoints.Count-1].x, movePoints[movePoints.Count-1].y - point.distance, movePoints[movePoints.Count-1].z);
                        break;
                    case "Left":
                        moveDirection = new Vector3(movePoints[movePoints.Count-1].x - point.distance, movePoints[movePoints.Count-1].y, movePoints[movePoints.Count-1].z);
                        break;
                    default:
                        break;
                }

                movePoints.Add(moveDirection);
            }
        }




        void Moving()
        {
            Vector3 goingTO = movePoints[currentPoint] - transform.position;

            if (Vector2.Distance(transform.position, movePoints[currentPoint]) < 0.1f)
            {
                transform.position = movePoints[currentPoint];
                //StartCoroutine(PauseMoving());
                currentPoint++;
                if (currentPoint >= movePoints.Count)
                {
                    currentPoint = 0;
                }
            }
            goingTO.Normalize();
            theRigidbody.velocity = goingTO * moveSpeed;
        }

        //private IEnumerator PauseMoving()
        //{
        //    paused = true;
        //    yield return new WaitForSeconds(1f);
        //    paused = false;
        //} 
    }
}