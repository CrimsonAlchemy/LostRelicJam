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
        float currentEffect = 1f;

        public bool inLight = false;
        private void Start()
        {
            //currentEffect = ShadowDamageManager.instance.CurrentShadowDamage;
            //targetEffect = ShadowDamageManager.instance.MaxShadowDamage;
        }
        private void Update()
        {
            //currentEffect = Mathf.Lerp(currentEffect, targetEffect, 2f * Time.deltaTime);

            //TODO for testing only REMOVE before build
            if (Input.GetKeyDown(KeyCode.Q))
            {
                inLight = !inLight;
            }
            if(currentEffect > 0)
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
                ResetDissolve();
            }
        }
        public void StartDissolving()
        {
            currentEffect = Mathf.MoveTowards(currentEffect, targetEffect, 0.3f * Time.deltaTime);
            sRenderer.material.SetFloat("_BurnAmount", currentEffect);

            

        }
        public void ResetDissolve()
        {
            currentEffect = 1f;
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

