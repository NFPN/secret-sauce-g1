using Sauce.Extensions;
using Sauce.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Sauce
{
    public class Room : MonoBehaviour, IRoom
    {
        #region Serialized Private Attributes

        [SerializeField]
        private int size;

        //[SerializeField]
        //private Directions[] sides;

        [SerializeField]
        private GameObject tile;

        [SerializeField]
        private List<GameObject> tiles;

        #endregion Serialized Private Attributes

        #region Properties

        public int Size { get => size; set => size = value; }

        //public Directions[] Sides { get => sides; set => sides = value; }
        public GameObject Tile { get => tile; set => tile = value; }

        public List<GameObject> Tiles { get => tiles; set => tiles = value; }
        public List<ITile> WallTiles { get; set; }
        public Vector2 Position { get => transform.position; }

        #endregion Properties

        async Task IRoom.StartRoomAsync()
        {
            WallTiles = new List<ITile>();
            gameObject.GetComponentsInChildren<ITile>().ToList().ForEach(t => WallTiles.Add(t));

            var pos = transform.position;
            var matrix = new Vector2(Size, Size);

            Tiles = await GenerateRoomGround(pos, matrix);
        }

        private async Task<List<GameObject>> GenerateRoomGround(Vector3 pos, Vector2 matrix)
        {
            var list = new List<GameObject>();
            for (int i = 0; i < matrix.x; i++)
            {
                await Task.Delay(1);
                for (int j = 0; j < matrix.y; j++)
                {
                    var position = new Vector2(pos.x + i + .5f, pos.y + j + .5f);

                    bool hasTile = WallTiles.Any(t => t.Position == position);

                    if (hasTile)
                        continue;

                    var tile = Instantiate(Tile, position, Quaternion.identity, transform);
                    tile.ToTileInterface().Render.sortingOrder = -1;
                    list.Add(tile);
                }
            }
            return list;
        }
    }
}