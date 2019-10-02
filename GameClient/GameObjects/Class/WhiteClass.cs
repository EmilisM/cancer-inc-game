namespace GameClient.GameObjects.Class
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