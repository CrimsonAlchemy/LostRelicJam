using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.PlayerSystems
{
    public enum PlayerType
    {
        Human,
        Shadow
    }

    public class Player : MonoBehaviour
    {
        [Header("Player Details")]
        [Tooltip("This is to choose whether the player is a human or a shadow character.")]
        public PlayerType playerType;

        Collider2D col;

        [Header("Collision Detection")]
        [Tooltip("This is the layermask that the player will eithe be damaged or safe from.")]
        public LayerMask insanityZone;

        private void Start()
        {
            if(col == null)
                col = GetComponent<Collider2D>();
        }

        private void Update()
        {
            InsanityZone_CollisionDetection();
        }

        void InsanityZone_CollisionDetection()
        {
            if (col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Shadow)
            {
                Debug.Log("Shadow landed, possibly add in a timer before the shadow is destroyed?");
            }
        }
    }
}
