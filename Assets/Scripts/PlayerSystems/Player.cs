using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        public static Action A_PlayerDeath;

        [Header("Player Details")]
        [Tooltip("This is to choose whether the player is a human or a shadow character.")]
        public PlayerType playerType;

        Collider2D col;

        [Header("Collision Detection")]
        [Tooltip("This is the layermask that the player will eithe be damaged or safe from.")]
        public LayerMask insanityZone;
        public LayerMask hazardZone;

        public bool canDamage = false;

        [Header("Animation Details")]
        public Animator anim;
        public RuntimeAnimatorController humanAnimController;
        public RuntimeAnimatorController shadowAnimController;
        public GameObject shadowDeathEffect;

        private void OnEnable()
        {
            A_PlayerDeath += Die;
        }

        private void OnDisable()
        {
            A_PlayerDeath -= Die;
            
        }
        private void Start()
        {
            if(col == null)
                col = GetComponent<Collider2D>();

            if(playerType == PlayerType.Human)
            {
                anim.runtimeAnimatorController = humanAnimController;
            }
            if(playerType == PlayerType.Shadow)
            {
                anim.runtimeAnimatorController = shadowAnimController;
            }
        }

        private void Update()
        {
            InsanityZone_CollisionDetection();
            //HazardZone_CollisionDetection();
        }

        void InsanityZone_CollisionDetection()
        {
            if (col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Shadow)
            {
                ShadowDamageManager.instance.Counting = true;
            }
            else
            {
                ShadowDamageManager.instance.Counting = false;
                ShadowDamageManager.instance.ResetCurrentDamage();
            }
        }

        public void Die()
        {
            //TODO Player Death here
            if(playerType == PlayerType.Shadow)
            {
                Instantiate(shadowDeathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (playerType == PlayerType.Human)
            {

            }
        }

        //void HazardZone_CollisionDetection()
        //{
        //    if (col.IsTouchingLayers(hazardZone) && playerType == PlayerType.Human)
        //    {
        //        //Play falling animation.
        //        Debug.Log("Play Falling Animation here");
        //    }
        //}
    }
}
