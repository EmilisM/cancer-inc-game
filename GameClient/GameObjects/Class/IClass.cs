namespace GameClient.GameObjects.Class
{
    public interface IClass
    {
        ClassType Type { get; }

        double DamageModifier { get; set; }
        double SpeedModifier { get; set; }
    }
}