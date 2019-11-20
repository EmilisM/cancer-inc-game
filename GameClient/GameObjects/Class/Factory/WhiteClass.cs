using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Class.Factory
{
    public class WhiteClass : IClass
    {
        public ClassType Type { get; }

        public WhiteClass()
        {
            Type = ClassType.White;
        }

        public double DamageModifier { get; set; }
        public double SpeedModifier { get; set; }
    }
}