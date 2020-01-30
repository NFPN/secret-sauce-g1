using Sauce.Interfaces;
using UnityEngine;

namespace Sauce.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IHaveBody, IHaveSprite
    {
        [SerializeField]
        private PlayerStats playerStats;

        private IMove2D Movement { get; set; }

        public BaseStats Stats => playerStats;
        public Rigidbody2D Body2D { get; private set; }
        public SpriteRenderer Sprite { get; private set; }

        private void Start()
        {
            Body2D = GetComponent<Rigidbody2D>();
            Sprite = GetComponentInChildren<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            Movement?.Move(this);
        }

        public void SetPlayerMovement(IMove2D movement)
        {
            Movement = movement;
        }
    }
}