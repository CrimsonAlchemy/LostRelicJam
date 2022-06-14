using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEffect : MonoBehaviour
{
    //public GameObject target;
    private Vector3 moveDirection;
    public Transform[] shadowMovePoints;
    public int currentPoint;
    public GameObject effect;
    //private GameObject player;
    public bool movingToPlayer;

    private void Update()
    {

        PlayParticleSwirl();

        //if (movingToPlayer)
        //{
        //    MoveToPlayer();
        //}
    }

    private void Moving()
    {
        effect.transform.position = Vector3.MoveTowards(effect.transform.position, shadowMovePoints[currentPoint].position, 15f * Time.deltaTime);
    }

    void PlayParticleSwirl()
    {
        moveDirection = shadowMovePoints[currentPoint].position - effect.transform.position;

        if (Vector2.Distance(effect.transform.position, shadowMovePoints[currentPoint].position) < 0.3f)
        {
            currentPoint++;
            if (currentPoint >= shadowMovePoints.Length)
            {
                currentPoint = 0;
                Destroy(gameObject);
            }
        }
        Moving();
    }

    //void MoveToPlayer()
    //{
    //    if(player == null)
    //    {
    //        player = FindObjectOfType<PlayerMovement>().gameObject;

    //    }
    //    if(player != null)
    //    {
    //        effect.transform.position = Vector3.MoveTowards(effect.transform.position, player.transform.position, 15f * Time.deltaTime);

    //        if(Vector2.Distance(effect.transform.position, player.transform.position) < 0.3f)
    //        {
    //            movingToPlayer = false;
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
