using System.Collections.Generic;

namespace GameServer.Entities
{
    public class Class
    {
        private Class()
        {
            Tower = new HashSet<Tower>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? DamageModifier { get; set; }
        public double? SpeedModifier { get; set; }

        public ICollection<Tower> Tower { get; set; }
    }
}