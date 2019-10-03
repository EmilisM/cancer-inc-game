using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Class
{
    public class RedClass : IClass
    {
        public ClassType Type { get; }

        public RedClass()
        {
            Type = ClassType.Red;
        }

        public double DamageModifier { get; set; }
        public double SpeedModifier { get; set; }
    }
}