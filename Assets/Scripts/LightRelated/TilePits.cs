using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DhruvS28.TileSystem
{

    public class TilePits : TileFinder
    {

        [HideInInspector]
        public List<Vector3> tilePositions;

        public GameObject lightSorting;
        public GameObject lightPrefab;

        // Start is called before the first frame update
        void Start()
        {
            tilePositions = GetTiles();

            foreach (var tileP in tilePositions)
            {
                GameObject light = Instantiate(lightPrefab, tileP + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);

                light.transform.SetParent(lightSorting.transform);
                //light.gameObject.AddComponent<Light2D>();
            }
        }

    }
}