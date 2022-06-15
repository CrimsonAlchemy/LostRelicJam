using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace DhruvS28.LightSystem
{
    public class LightFlicker : MonoBehaviour
    {

        Transform mainLight;
        Transform flickerLight;
        Light2D mainLightComponent;
        Light2D flickerLightComponent;


        // Start is called before the first frame update
        void Start()
        {
            mainLight = this.transform;
            flickerLight = this.transform.GetChild(0);
            mainLightComponent = mainLight.GetComponent<Light2D>();
            flickerLightComponent = flickerLight.GetComponent<Light2D>();

            StartCoroutine(Flicker());
        }

        IEnumerator Flicker()
        {
            float flikcerTime = Random.Range(10f, 20f);

            for (int i = 0; i < flikcerTime; i++) //this is while(true)
            {
                float randomIntensity = Random.Range(0.5f, 1f);
                flickerLightComponent.intensity = randomIntensity;

                float randomTime = Random.Range(0.05f, 0.15f);
                yield return new WaitForSeconds(randomTime);
            }
            flickerLightComponent.intensity = 0.5f;
            yield return StartCoroutine(FlickerDelay());
        }

        IEnumerator FlickerDelay()
        {
            float randomTime = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(randomTime);
            yield return StartCoroutine(Flicker());
        }
    }
}