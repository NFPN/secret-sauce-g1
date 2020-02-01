using UnityEngine;

namespace Sauce.Interfaces
{
    public interface IHaveBody : IHaveSprite
    {
        Rigidbody2D Body2D { get; }
    }

    public interface IHavePlayerBody : IHaveBody
    {
        IHavePlayerStats Stats { get; }
    }

    public interface IHaveEnemyBody : IHaveBody
    {
        IHaveEnemyStats Stats { get; }
    }
}