using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace DhruvS28.TileSystem
{
    public class TileFinder : MonoBehaviour
    {
        
        public List<Vector3> tileP;
 
        // Start is called before the first frame update
        public List<Vector3> GetTiles()
        {
            Tilemap tilemap = GetComponent<Tilemap>();

            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                if (!tilemap.HasTile(position))
                {
                    continue;
                }

                // Tile is not empty; do stuff.
                tileP.Add(position);
            }

            return tileP;
        }
    }
}
