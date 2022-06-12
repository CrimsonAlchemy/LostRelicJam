using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RyanBeattie.InsanitySystem
{
    public class InsanitySystem : MonoBehaviour
    {
        public static InsanitySystem instance;

        [Header("Insanity Details")]
        [SerializeField] [Range(1, 20)]float maxInsanity = 10f;
        float currentInsanity = 0f;
        bool counting = false;


        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (counting) { InsanityIncreaseTimer(); }
        }
        public bool Counting
        {
            get { return counting; }
            set
            {
                counting = value;
            }
        }
        public float CurrentInsanity
        {
            get{ return currentInsanity; }
            set
            {
                if (value < MaxInsanity)
                    currentInsanity = value;
                else
                    currentInsanity = MaxInsanity;
            }
        }
        public float MaxInsanity
        {
            get { return maxInsanity; }
        }
        void InsanityIncreaseTimer()
        {
            if(CurrentInsanity >= MaxInsanity)
            {
                CurrentInsanity = MaxInsanity;
                counting = false;
                //TODO The player death goes here
            }
            else { CurrentInsanity += Time.deltaTime; }

            InsanityBarUI.A_UpdateInsanityBar?.Invoke();
        }
    }

}
