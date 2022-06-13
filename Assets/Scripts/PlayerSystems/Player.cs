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

    [RequireComponent(typeof(ShadowDamage))]
    public class Player : MonoBehaviour
    {
        [Header("Player Details")]
        [Tooltip("This is to choose whether the player is a human or a shadow character.")]
        public PlayerType playerType;

        Collider2D col;

        [Header("Collision Detection")]
        [Tooltip("This is the layermask that the player will eithe be damaged or safe from.")]
        public LayerMask insanityZone;

        public bool canDamage = false;

        private void Start()
        {
            if(col == null)
                col = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if(canDamage)
                InsanityZone_CollisionDetection();
        }

        void InsanityZone_CollisionDetection()
        {
            if (col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Shadow)
            {
                GetComponent<ShadowDamage>().Counting = true;
            }
            else
            {
                GetComponent<ShadowDamage>().Counting = false;
                GetComponent<ShadowDamage>().ResetCurrentDamage();
            }
        }
    }
}
