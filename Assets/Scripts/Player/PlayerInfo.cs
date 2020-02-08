﻿using Sauce.Interfaces;
using System;

namespace Sauce.Manager
{
    [Serializable]
    public class PlayerInfo
    {
        public static PlayerInfo None => new PlayerInfo();

        public IHavePlayerStats Stats { get; set; }
        public Currency Currency { get; set; } //TODO: make interface
        public short LastLevel { get; set; }
    }
}