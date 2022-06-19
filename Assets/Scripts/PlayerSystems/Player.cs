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
        public bool isDead = false;
        public bool hasShadowOnHuman = true;
        public GameObject shadowTrailEffect;

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
        public Transform[] shadowAbsorbPoints;

        private void OnEnable()
        {
            A_PlayerDeath += Die;
            
            Camera.main.GetComponent<CameraFollow>().player = this.transform;

            if (playerType == PlayerType.Human)
            {
                anim.runtimeAnimatorController = humanAnimController;
                shadowTrailEffect.SetActive(false);

                if (hasShadowOnHuman)
                {
                    anim.SetBool("humanHasShadow", true);
                }
                else
                {
                    anim.SetBool("humanHasShadow", false);
                }
            }
            if (playerType == PlayerType.Shadow)
            {
                anim.runtimeAnimatorController = shadowAnimController;
                shadowTrailEffect.SetActive(true);
            }
        }

        private void OnDisable()
        {
            A_PlayerDeath -= Die;
            
        }
        private void Start()
        {
            if(col == null)
                col = GetComponent<Collider2D>();

            #region Old Testing Code
            //if(playerType == PlayerType.Human)
            //{
            //    anim.runtimeAnimatorController = humanAnimController;
            //    shadowTrailEffect.SetActive(false);

            //    //if (hasShadowOnHuman)
            //    //{
            //    //    anim.SetBool("humanHasShadow", true);
            //    //}
            //    //else
            //    //{
            //    //    anim.SetBool("humanHasShadow", false);
            //    //}
            //}
            //if(playerType == PlayerType.Shadow)
            //{
            //    anim.runtimeAnimatorController = shadowAnimController;
            //    shadowTrailEffect.SetActive(true);
            //}
            #endregion
        }

        private void FixedUpdate()
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
            if(!col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Shadow)
            {
                ShadowDamageManager.instance.Counting = false;
                ShadowDamageManager.instance.ResetCurrentDamage();
            }

            if(col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Human)
            {
                InsanitySystem.InsanitySystem.instance.Counting = false;
            }
            if (!col.IsTouchingLayers(insanityZone) && playerType == PlayerType.Human)
            {

                InsanitySystem.InsanitySystem.instance.Counting = true;
            }
        }

        bool hasSpawnedShadowHealthEffect = false;
        public void Die()
        {
            //TODO Player Death here
            //isDead = true;
            if(playerType == PlayerType.Shadow && !isDead)
            {
                ShadowDamageManager.instance.isDead = true;
                if (!hasSpawnedShadowHealthEffect)
                {
                    SpawnDeathParticles();
                    AudioManager.instance.PlayShadowDeath();
                    GetComponent<PlayerMovement>().canMove = false;
                    anim.SetBool("moving", false);
                    //isDead = true;
                    Destroy(gameObject);
                    hasSpawnedShadowHealthEffect = true;
                }
                isDead = true;
                Destroy(gameObject);
                Debug.Log("Is dead");
            }
            if (playerType == PlayerType.Human)
            {
                GetComponent<PlayerMovement>().canMove = false;
                anim.SetBool("dead", true);
                AudioManager.instance.isWalking = false;
                AudioManager.instance.StopFeetsteps();
                AudioManager.instance.PlayShadowAttack();
                anim.SetBool("moving", false);
                isDead = true;

                //TODO Testing Death


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

        bool hasSpawnedP = false;
        void SpawnDeathParticles()
        {
            if (!hasSpawnedP)
            {
                Instantiate(shadowDeathEffect, transform.position, Quaternion.identity);
                hasSpawnedP = true;
            }
        }
    }
}
