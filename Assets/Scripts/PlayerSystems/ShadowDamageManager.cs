using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.PlayerSystems
{
    public class ShadowDamageManager : MonoBehaviour
    {
        public static ShadowDamageManager instance;
        [SerializeField] float maxShadowDamage = 1.5f;
        float currentShadowDamage = 0f;
        bool counting = false;
        public bool isDead = false;
        //GameObject player;


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //if(player == null)
            //    player = FindObjectOfType<Player>().gameObject;
        }

        private void Update()
        {
            if (counting)
            {
                StartDamageTimer();
                AudioManager.instance.PlaySizzle();
            }
            if(!counting)
            {
                AudioManager.instance.StopSizzle();
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

        public float CurrentShadowDamage
        {
            get { return currentShadowDamage; }
            set
            {
                if (value < MaxShadowDamage)
                {
                    currentShadowDamage = value;
                }
                else
                {
                    currentShadowDamage = MaxShadowDamage;
                }
            }
        }

        public float MaxShadowDamage
        {
            get { return maxShadowDamage; }
        }

        public void ResetCurrentDamage()
        {
            CurrentShadowDamage = 0f;
            ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
        }

        
        public void StartDamageTimer()
        {
            if (CurrentShadowDamage >= MaxShadowDamage)
            {
                CurrentShadowDamage = MaxShadowDamage;
                counting = false;
                if (!isDead)
                {
                    Player.A_PlayerDeath?.Invoke();
                }
                isDead = true;
            }
            else
            {
                CurrentShadowDamage += Time.deltaTime;
            }

            ShadowDamageBarUI.A_UpdateShadowDamageBar?.Invoke();
        }
    }
}
