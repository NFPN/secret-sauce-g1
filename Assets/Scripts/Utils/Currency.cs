using System;
using UnityEngine;

namespace Sauce
{
    [Serializable]
    public class Currency
    {
        [SerializeField]
        private long magicEssences;

        [SerializeField]
        private int magicCrystals;

        public long MagicEssences { get => magicEssences; set => magicEssences = value; }
        public int MagicCrystals { get => magicCrystals; set => magicCrystals = value; }
    }
}