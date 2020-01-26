using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerStats playerStats;

        [SerializeField]
        private Rigidbody2D myRigidbody;

        private IMove2D movement;

        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            movement?.Move(myRigidbody);//should pass this as ICanMove interface
        }

        public void SetPlayer(IMove2D movement)
        {
            this.movement = movement;
        }
    }
}