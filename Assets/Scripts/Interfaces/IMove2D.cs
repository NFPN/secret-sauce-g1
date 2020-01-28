using Sauce.Enums;

namespace Sauce.Interfaces
{
    public interface IMove2D
    {
        /// <summary>
        /// Only shows LEFT, RIGHT or NONE directions
        /// </summary>
        Direction4 LastDirection { get; }

        void Move(IHaveBody rigidbody2D);
    }
}