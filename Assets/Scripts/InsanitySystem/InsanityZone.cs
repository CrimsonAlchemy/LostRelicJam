using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RyanBeattie.InsanitySystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InsanityZone : MonoBehaviour
    {
        Light2D theLight;
        CircleCollider2D theCollider;

        private void Start()
        {
            if(theLight == null)
                theLight = GetComponent<Light2D>();

            if(theCollider == null)
            {
                theCollider = GetComponent<CircleCollider2D>();

                theCollider.radius = theLight.pointLightOuterRadius;
            }

        }
        #region Old Code
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    PlayerSystems.Player player = collision.GetComponent<PlayerSystems.Player>();

        //    if(player != null)
        //    {
        //        if (player.playerType == PlayerSystems.PlayerType.Human)
        //        {
        //            //Debug.Log($"I'm a Human! I am safe in the light!");
        //            InsanitySystem.instance.Counting = false;
        //        }
        //        if (player.playerType == PlayerSystems.PlayerType.Shadow)
        //        {
        //            Debug.Log($"Shadow has touched some light! You Are Dead!");
        //            //TODO Kill the shadow functionality here
        //        }
        //    }


        //}

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    PlayerSystems.Player player = collision.GetComponent<PlayerSystems.Player>();

        //    if (player != null)
        //    {
        //        if (player.playerType == PlayerSystems.PlayerType.Human)
        //        {
        //            //Debug.Log($"I'm a Human! Oh No! Shadow monsters are after me, better get to the light!");
        //            InsanitySystem.instance.Counting = true;
        //        }
        //        if (player.playerType == PlayerSystems.PlayerType.Shadow)
        //        {
        //            Debug.Log($"I'm a Shadow! I need to stay in the darkness!");
        //        }
        //    }

        //}
        #endregion
    }

}
