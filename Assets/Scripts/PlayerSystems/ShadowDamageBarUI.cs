using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RyanBeattie.PlayerSystems
{
    public class ShadowDamageBarUI : MonoBehaviour
    {
        public static Action A_UpdateShadowDamageBar;

        [Header("Bar Elements")]
        [Tooltip("This is the image gameobject that will be changing dynamically.")]
        [SerializeField] Image fill;

        private void OnEnable()
        {
            A_UpdateShadowDamageBar += UpdateShadowDamageBar;
        }
        private void OnDisable()
        {
            A_UpdateShadowDamageBar -= UpdateShadowDamageBar;
        }

        public void UpdateShadowDamageBar()
        {
            //fill.fillAmount = ShadowDamage.instance.CurrentDamage / ShadowDamage.instance.MaxDamage;
            fill.fillAmount = ShadowDamageManager.instance.CurrentShadowDamage / ShadowDamageManager.instance.MaxShadowDamage;
            //Debug.Log($"{InsanitySystem.instance.CurrentInsanity} Current Insanity!");
        }
    }

}
