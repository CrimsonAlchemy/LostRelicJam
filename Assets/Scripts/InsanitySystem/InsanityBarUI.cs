using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace RyanBeattie.InsanitySystem
{
    public class InsanityBarUI : MonoBehaviour
    {
        public static Action A_UpdateInsanityBar;

        [Header("Bar Elements")]
        [Tooltip("This is the image gameobject that will be changing dynamically.")]
        //[SerializeField] Image fill;
        [SerializeField] Slider slider;

        private void OnEnable()
        {
            A_UpdateInsanityBar += UpdateInsanityBar;
        }
        private void OnDisable()
        {
            A_UpdateInsanityBar -= UpdateInsanityBar;
        }

        public void UpdateInsanityBar(/*float currentSanity, float maxSanity*/)
        {
            //fill.fillAmount = InsanitySystem.instance.CurrentInsanity / InsanitySystem.instance.MaxInsanity;
            slider.value = InsanitySystem.instance.CurrentInsanity / InsanitySystem.instance.MaxInsanity;
        }

    }

}
