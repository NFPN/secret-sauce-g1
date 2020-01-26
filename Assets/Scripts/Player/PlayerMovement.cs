using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    public class PlayerMovement : IMove2D
    {
        private Vector2 movement = new Vector2();

        public void Move(Rigidbody2D rb2D)
        {
            //TODO: Improve this code
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            rb2D.MovePosition(rb2D.position + movement * 3 * Time.fixedDeltaTime);
        }
    }
}