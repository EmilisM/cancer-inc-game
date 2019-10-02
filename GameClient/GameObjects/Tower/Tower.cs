using GameClient.GameObjects.Class;

namespace GameClient.GameObjects.Tower
{
    public class Tower
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public double? Damage { get; set; }
        public double? Speed { get; set; }
        public int Size { get; set; }
        public int Range { get; set; }

        public ClassType ClassType { get; set; }
    }
}