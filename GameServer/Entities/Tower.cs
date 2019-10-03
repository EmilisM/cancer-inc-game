using System.Collections.Generic;

namespace GameServer.Entities
{
    public class Tower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int? Damage { get; set; }
        public double? SpeedPerSecond { get; set; }
        public int Size { get; set; }
        public int? Range { get; set; }
        public string Effect { get; set; }
        public int? ClassId { get; set; }
        public bool Poison { get; set; }

        public virtual Class Class { get; set; }
    }
}