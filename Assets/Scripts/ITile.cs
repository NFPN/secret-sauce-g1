using Sauce.Enums;
using UnityEngine;

namespace Sauce.Interfaces
{
    public interface ITile
    {
        TileType Type { get; set; }
        SpriteRenderer Render { get; set; }
        Vector2 Position { get; }

        GameObject GetGO();
    }
}

