using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.PlayerSystems
{
    public class ShadowDamage : MonoBehaviour
    {
        public static ShadowDamage instance;

        [SerializeField] float maxDamage = 1.5f;
        float currentDamage = 0f;
        bool counting = false;

        private void Awake()
        {
            instance = this;
        }
        private void Update()
        {
            if (Counting)
            {
                StartDamageTimer();
            }
        }

        public bool Counting
        {
            get { return counting; }
            set
            {
                counting = value;
            }
        }

        public float CurrentDamage
        {
            get { return currentDamage; }
            set
            {
                if (value < MaxDamage)
                {
                    currentDamage = value;
                }
                else
                {
                    currentDamage = MaxDamage;
                }
            }
        }

        public float MaxDamage
        {
            get { return maxDamage; }
        }

        public void ResetCurrentDamage()
        {
            CurrentDamage = 0f;
            ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
        }

        public void StartDamageTimer()
        {
            if(CurrentDamage >= MaxDamage)
            {
                CurrentDamage = MaxDamage;
                counting = false;
            }
            else
            {
                CurrentDamage += Time.deltaTime;
            }

            ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
            //Debug.Log($"Current Time: {currentDamage}");
        }
    }
}

