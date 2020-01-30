using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Extensions
{
    public static class Extensions
    {
        public static ITile ToTileInterface(this GameObject go) => go.GetComponent<Tile>();
    }
}