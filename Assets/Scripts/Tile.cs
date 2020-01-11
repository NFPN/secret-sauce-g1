using Sauce.Enums;
using Sauce.Interfaces;
using UnityEngine;

namespace Sauce
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour, ITile
    {
        [SerializeField]
        private TileType VisualType;

        public TileType Type { get => VisualType; set => VisualType = value; }
        public SpriteRenderer Render { get => Render != null ? Render : gameObject.GetComponent<SpriteRenderer>(); set => Render = value; }
        public Vector2 Position { get => transform.position; }

        public GameObject GetGO()
        {
            return gameObject;
        }
    }
}