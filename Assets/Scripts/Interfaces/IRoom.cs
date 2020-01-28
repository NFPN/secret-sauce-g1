using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Sauce.Interfaces
{
    public interface IRoom
    {
        int Size { get; set; }

        //Directions[] Sides { get; set; }
        Vector2 Position { get; }

        GameObject Tile { get; set; }
        List<GameObject> Tiles { get; set; }
        List<ITile> WallTiles { get; set; }

        Task StartRoomAsync();
    }
}