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

    //[RequireComponent(typeof(ShadowDamage))]
    public class Player : MonoBehaviour
    {
        [Header("Player Details")]
        [Tooltip("This is to choose whether the player is a human or a shadow character.")]
        public PlayerType playerType;

        Collider2D col;

        [Header("Collision Detection")]
        [Tooltip("This is the layermask that the player will eithe be damaged or safe from.")]
        public LayerMask insanityZone;
        public LayerMask hazardZone;

        public bool canDamage = false;

        public Animator anim;

        private void Start()
        {
            if(col == null)
                col = GetComponent<Collider2D>();
        }

        private void Update()
        {
            InsanityZone_CollisionDetection();
            HazardZone_CollisionDetection();
        }

        void InsanityZone_CollisionDetection()
        {
            if (col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Shadow)
            {
                //GetComponent<ShadowDamage>().Counting = true;
                ShadowDamageManager.instance.Counting = true;
            }
            else
            {
                //GetComponent<ShadowDamage>().Counting = false;
                //GetComponent<ShadowDamage>().ResetCurrentDamage();

                ShadowDamageManager.instance.Counting = true;
                ShadowDamageManager.instance.ResetCurrentDamage();
            }
        }

        void HazardZone_CollisionDetection()
        {
            if (col.IsTouchingLayers(hazardZone) && playerType == PlayerType.Human)
            {
                //Play falling animation.
                Debug.Log("Play Falling Animation here");
            }
        }
    }
}
