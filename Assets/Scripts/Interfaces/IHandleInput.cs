using UnityEngine;

namespace Sauce.Interfaces
{
    public interface IHandleInput
    {
        float Horizontal { get; }
        float Vertical { get; }

        Vector2 Direction { get; }
    }
}