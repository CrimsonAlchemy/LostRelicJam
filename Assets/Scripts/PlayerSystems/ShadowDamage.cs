using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System;

namespace RyanBeattie.PlayerSystems
{
    public class ShadowDamage : MonoBehaviour
    {
        [SerializeField] SpriteRenderer sRenderer = new SpriteRenderer();

        float targetEffect = 0f;
        float currentEffect = 1.1f;
        public float effectSpeed = 0.5f;

        public bool inLight = false;
        private void Start()
        {
            currentEffect = ShadowDamageManager.instance.CurrentShadowDamage;
            //targetEffect = ShadowDamageManager.instance.MaxShadowDamage;
        }
        private void Update()
        {
            //currentEffect = Mathf.Lerp(currentEffect, targetEffect, 2f * Time.deltaTime);

            //TODO for testing only REMOVE before build
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    inLight = !inLight;
            //}

            if (ShadowDamageManager.instance.Counting)
            {
                inLight = true;
            }
            else
            {
                inLight = false;
            }

            if (inLight)
            {
                StartDissolving();
            }
            if(!inLight)
            {
                if (ShadowDamageManager.instance.CurrentShadowDamage >= ShadowDamageManager.instance.MaxShadowDamage)
                {
                    StartDissolving();
                    currentEffect = 0;
                }
                else
                {
                    ResetDissolve();
                }
            }
        }
        public void StartDissolving()
        {
            currentEffect = Mathf.MoveTowards(currentEffect, targetEffect, effectSpeed * Time.deltaTime);
            sRenderer.material.SetFloat("_BurnAmount", currentEffect);
        }
        public void ResetDissolve()
        {
            currentEffect = 1.2f;
            sRenderer.material.SetFloat("_BurnAmount", currentEffect);
        }


        #region Old Script Code
        //This code was moved into shadow damage manager

        //public static ShadowDamage instance;

        //[SerializeField] float maxDamage = 1.5f;
        //float currentDamage = 0f;
        //bool counting = false;

        //private void Awake()
        //{
        //    instance = this;
        //}
        //private void Update()
        //{
        //    if (Counting)
        //    {
        //        StartDamageTimer();
        //    }
        //}

        //public bool Counting
        //{
        //    get { return counting; }
        //    set
        //    {
        //        counting = value;
        //    }
        //}

        //public float CurrentDamage
        //{
        //    get { return currentDamage; }
        //    set
        //    {
        //        if (value < MaxDamage)
        //        {
        //            currentDamage = value;
        //        }
        //        else
        //        {
        //            currentDamage = MaxDamage;
        //        }
        //    }
        //}

        //public float MaxDamage
        //{
        //    get { return maxDamage; }
        //}

        //public void ResetCurrentDamage()
        //{
        //    CurrentDamage = 0f;
        //    ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
        //}

        //public void StartDamageTimer()
        //{
        //    if(CurrentDamage >= MaxDamage)
        //    {
        //        CurrentDamage = MaxDamage;
        //        counting = false;
        //    }
        //    else
        //    {
        //        CurrentDamage += Time.deltaTime;
        //    }

        //    ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
        //    //Debug.Log($"Current Time: {currentDamage}");
        //}
        #endregion
    }
}

