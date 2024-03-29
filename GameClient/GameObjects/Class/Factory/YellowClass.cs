﻿using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Class.Factory
{
    public class YellowClass : IClass
    {
        public ClassType Type { get; }

        public YellowClass()
        {
            Type = ClassType.Yellow;
        }

        public double DamageModifier { get; set; }
        public double SpeedModifier { get; set; }
    }
}