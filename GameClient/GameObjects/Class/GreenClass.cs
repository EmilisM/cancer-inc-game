﻿namespace GameClient.GameObjects.Class
{
    public class GreenClass : IClass
    {
        public ClassType Type { get; }

        public GreenClass()
        {
            Type = ClassType.Green;
        }

        public double DamageModifier { get; set; }
        public double SpeedModifier { get; set; }
    }
}