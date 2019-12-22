using Sauce.Extensions;
using Sauce.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sauce
{
    public class Room : MonoBehaviour
    {
        public int Size;
        public GameObject Tile;
        public List<GameObject> Tiles;

        private List<ITile> WallTiles;

        private void Start()
        {
            WallTiles = new List<ITile>();
            gameObject.GetComponentsInChildren<ITile>().ToList().ForEach(t => WallTiles.Add(t));

            var pos = transform.position;
            var matrix = new Vector2(Size, Size);

            for (int i = 0; i < matrix.x; i++)
            {
                for (int j = 0; j < matrix.y; j++)
                {
                    var position = new Vector2(pos.x + i + .5f, pos.y + j + .5f);

                    bool hasTile = WallTiles.Any(t => t.Position == position);

                    if (hasTile)
                        continue;

                    var tile = Instantiate(Tile, position, Quaternion.identity, transform);
                    tile.ToTileInterface().Render.sortingOrder = -1;
                    Tiles.Add(tile);
                }
            }
        }
    }
}