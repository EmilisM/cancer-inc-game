namespace GameClient.GameObjects.Class
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