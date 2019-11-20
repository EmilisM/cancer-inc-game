using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Class.Factory
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