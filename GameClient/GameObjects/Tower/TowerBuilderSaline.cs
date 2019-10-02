namespace GameClient.GameObjects.Tower
{
    public class SalineTowerBuilder : ITowerBuilder
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public double Damage { get; set; }
        public double Speed { get; set; }
        public int Size { get; set; }
        public string ClassType { get; set; }

        public Tower GetTower()
        {
            return new Tower(
                "Saline",
                200,
                "none",
                0,
                0.1,
                3,
                0,
                "Red");
        }
    }
}
