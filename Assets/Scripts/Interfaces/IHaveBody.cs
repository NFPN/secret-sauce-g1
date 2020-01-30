using Sauce.Character;
using UnityEngine;

namespace Sauce.Interfaces
{
    public interface IHaveBody : IHaveSprite
    {
        Rigidbody2D Body2D { get; }
        BaseStats Stats { get; }
    }
}