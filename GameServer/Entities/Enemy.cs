using System.Collections.Generic;

namespace GameServer.Entities
{
    public class Enemy
    {
        public Enemy()
        {
            EnemyType = new HashSet<EnemyType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Hp { get; set; }
        public int? Speed { get; set; }

        public ICollection<EnemyType> EnemyType { get; set; }
    }
}