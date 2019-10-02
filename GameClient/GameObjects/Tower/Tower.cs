namespace GameClient.GameObjects.Tower
{
    public class Tower
    {
        string Name { get; set; }
        int Cost { get; set; }
        string Type { get; set; }
        double Damage { get; set; }
        double Speed { get; set; }
        int Size { get; set; }
        int Range { get; set; }
        string ClassType { get; set; }

        public Tower(string name, int cost, string type, double damage, double speed, int size, int range, string classType)
        {
            Name = name;
            Cost = cost;
            Type = type;
            Damage = damage;
            Speed = speed;
            Size = size;
            Range = range;
            ClassType = classType;
        }
    }
}
