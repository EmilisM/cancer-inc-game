namespace GameClient.GameObjects.Tower
{
    public interface ITowerBuilder
    {
        string Name { get; set; }
        int Cost { get; set; }
        string Type { get; set; }
        int Damage { get; set; }
        double Speed { get; set; }
        int Size { get; set; }
        string ClassType { get; set; }

        Tower GetTower();

    }
}
