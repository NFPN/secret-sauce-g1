using Sauce.Character;
using UnityEngine;

namespace Sauce.Interfaces
{
    public interface IHaveBody
    {
        Rigidbody2D Body2D { get; }
        BaseStats Stats { get; }
    }
}