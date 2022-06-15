using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float speed;

    // public Vector3 offset;

    void Start()
    {
        speed = 0.125f;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(player != null)
            transform.position = new Vector3(player.position.x, player.position.y, -1f); 
    }
}

