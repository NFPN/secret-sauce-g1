using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    public class Movement : IMove2D
    {
        #region Properties

        private IHandleInput Inputs { get; set; }

        public bool FacingRight
        {
            get => Inputs != null ? Inputs.Horizontal > 0 : true;
            private set => FacingRight = value;
        }

        #endregion Properties

        public Movement(IHandleInput input) => Inputs = input;

        public void Move(IHaveBody body)
        {
            body.Body2D.MovePosition(body.Body2D.position + Inputs.Direction * body.Stats.moveSpeed * Time.fixedDeltaTime);

            if (Inputs.Horizontal != 0)
                body.Sprite.flipX = !FacingRight;
        }
    }
}