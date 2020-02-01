using Sauce.Interfaces;
using System;
using UnityEngine;

namespace Sauce.Character
{
    //TODO: add base dmg, resistances list
    [Serializable]
    public class BaseStats : IHaveStats
    {
        [SerializeField]
        private short health;

        [SerializeField]
        private float moveSpeed;

        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public short Health { get => health; set => health = value; }
    }

    [Serializable]
    public class PlayerStats : BaseStats, IHavePlayerStats
    {
        [SerializeField]
        private short stamina;

        [SerializeField]
        private short mana;

        public short Stamina { get => stamina; set => stamina = value; }
        public short Mana { get => mana; set => mana = value; }
    }

    [Serializable]
    public class EnemyStats : BaseStats, IHaveEnemyStats
    {
        [SerializeField]
        private short level;

        public short Level { get => level; set => level = value; }
    }
}