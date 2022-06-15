using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;


namespace DhruvS28.TileSystem
{
    public class TileLighting : MonoBehaviour
    {
        [HideInInspector]
        public List<Vector3> tilePositions;

        public GameObject torches;
        public GameObject lightPrefab;

        // Start is called before the first frame update
        void Start()
        {
            Tilemap tilemap = GetComponent<Tilemap>();

            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                if (!tilemap.HasTile(position))
                {
                    continue;
                }

                // Tile is not empty; do stuff.
                tilePositions.Add(position);
            }


            foreach (var tileP in tilePositions)
            {
                GameObject light = Instantiate(lightPrefab, tileP + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);

                light.transform.SetParent(torches.transform);
                //light.gameObject.AddComponent<Light2D>();
            }
        }
    }
}
