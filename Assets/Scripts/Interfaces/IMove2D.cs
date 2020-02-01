namespace Sauce.Interfaces
{
    public interface IMove2D
    {
        /// <summary>
        /// Only shows LEFT, RIGHT or NONE directions
        /// </summary>
        bool FacingRight { get; }

        void Move(IHavePlayerBody rigidbody2D);
    }
}