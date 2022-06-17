using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace DhruvS28.LightSystem
{
    public class LightBlinker : MonoBehaviour
    {

        Transform blinkerLight;
        Light2D blinkerLightComponent;


        // Start is called before the first frame update
        void Start()
        {
            blinkerLight = this.transform;
            blinkerLightComponent = blinkerLight.GetComponent<Light2D>();

            StartCoroutine(Blinker());
        }

        IEnumerator Blinker()
        {
            float blinkerTime = 15f;
            float change = -0.1f;

            //for (float i = 0; i < blinkerTime; i++) //this is while(true)
            for( ; ; )
            {
                if (blinkerLightComponent.intensity <= 0)
                    change = 0.1f;
                else if (blinkerLightComponent.intensity >= 1.5)
                {
                    yield return new WaitForSeconds(1f);
                    change = -0.1f;
                }
                blinkerLightComponent.intensity += change;

                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}