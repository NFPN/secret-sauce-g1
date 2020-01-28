using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    public class PlayerInput : IHandleInput
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public float Vertical => Input.GetAxisRaw("Vertical");

        public Vector2 Direction => new Vector2(Horizontal, Vertical);
    }
}