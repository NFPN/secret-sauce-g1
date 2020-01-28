using Sauce.Enums;
using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    public class Movement : IMove2D
    {
        #region Properties

        private IHandleInput Inputs { get; set; }

        public Direction4 LastDirection
        {
            get => GetLastPosition();
            private set => LastDirection = value;
        }

        #endregion Properties

        public Movement(IHandleInput input) => Inputs = input;

        public void Move(IHaveBody body) =>
            body.Body2D.MovePosition(body.Body2D.position + Inputs.Direction * body.Stats.moveSpeed * Time.fixedDeltaTime);

        private Direction4 GetLastPosition()
        {
            if (Inputs.Horizontal < 0)
                return Direction4.LEFT;
            if (Inputs.Horizontal > 0)
                return Direction4.RIGHT;

            return Direction4.NONE;
        }
    }
}