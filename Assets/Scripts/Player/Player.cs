using Sauce.Enums;
using Sauce.Interfaces;
using Sauce.Manager;
using System.Linq;
using UnityEngine;

namespace Sauce.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IHavePlayerBody, IHaveSprite
    {
        [SerializeField]
        private PlayerStats _stats;

        [SerializeField]
        private Currency _currency;

        private IMove2D Movement { get; set; }

        //public IHavePlayerStats Stats => _stats;

        public Rigidbody2D Body2D { get; private set; }
        public SpriteRenderer Sprite { get; private set; }

        public IHavePlayerStats Stats => _stats;

        public Currency Currency => _currency;

        private void Start()
        {
            Body2D = GetComponent<Rigidbody2D>();
            Sprite = GetComponentInChildren<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            Movement?.Move(this);
        }

        public void SetData(Currency currency, IHavePlayerStats stats, IHaveSprite sprite = null)
        {
            _currency = currency;
            _stats = (PlayerStats)stats;
        }

        public void SetPlayerMovement(IMove2D movement)
        {
            Movement = movement;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == TAG.LevelExit.ToString())
            {
                //TODO
                var mm = FindObjectOfType<MasterManager>();
                mm.IncreaseCurrentLevel();
                var pmanager = mm.managers.FirstOrDefault(m => m.GetType() == typeof(PlayerManager));
                (pmanager as PlayerManager).SetPlayerPostion();
            }
        }
    }
}