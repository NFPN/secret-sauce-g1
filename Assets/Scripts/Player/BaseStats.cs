using System;

namespace Sauce.Character
{
    [Serializable]
    public class BaseStats
    {
        public short health;
        public float moveSpeed;
    }

    [Serializable]
    public class PlayerStats : BaseStats
    {
        public short stamina;
        public short mana;
    }
}