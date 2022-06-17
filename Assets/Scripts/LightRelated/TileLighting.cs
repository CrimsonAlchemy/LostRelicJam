using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;


namespace DhruvS28.TileSystem
{

    public enum effectSide
    {
        Front,
        Right,
        Back,
        Left
    };

    public enum Type
    {
        Torch,
        Mushroom,
    };

    public class TileLighting : TileFinder
    {
        [HideInInspector]
        public List<Vector3> tilePositions;

        public GameObject lightSorting;
        public GameObject lightPrefab;

        public bool fireEffects;
        public effectSide direction = effectSide.Front;
        public Type type = Type.Torch;

        private GameObject light;

        // Start is called before the first frame update
        void Start()
        {
            tilePositions = GetTiles();

            foreach (var tileP in tilePositions)
            {
                if ((type).ToString() == "Torch")
                    light = Instantiate(lightPrefab, tileP + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
                else if ((type).ToString() == "Mushroom")
                {
                    light = Instantiate(lightPrefab, tileP + new Vector3(1f, 1f, 0f), Quaternion.identity);

                }


                light.transform.SetParent(lightSorting.transform);
                //light.gameObject.AddComponent<Light2D>();
                if (fireEffects)
                {
                    ParticleChanger();
                }
            }



        }

        void ParticleChanger()
        {
            //this.transform.GetChild(1).transform.position = new Vector3(0f, 0f, 0f);
            Debug.Log(light.transform.GetChild(1));

            switch ((direction).ToString())
            {
                case "Front":
                    light.transform.GetChild(1).transform.position = light.transform.GetChild(1).transform.position + new Vector3(0f, 0f, 0f);
                    break;
                case "Right":
                    light.transform.GetChild(1).transform.position = light.transform.GetChild(1).transform.position +  new Vector3(0.25f, 0f, 0f);
                    break;
                case "Back":
                    light.transform.GetChild(1).gameObject.SetActive(false);
                    break;
                case "Left":
                    light.transform.GetChild(1).transform.position = light.transform.GetChild(1).transform.position + new Vector3(-0.25f, 0f, 0f);
                    break;
                default:
                    break;
            }
        }

    }
}
