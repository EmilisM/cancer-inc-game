using System.Collections.Generic;

namespace GameServer.Entities
{
    public class Type
    {
        public Type()
        {
            EnemyType = new HashSet<EnemyType>();
            TowerAttackType = new HashSet<TowerAttackType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EnemyType> EnemyType { get; set; }
        public ICollection<TowerAttackType> TowerAttackType { get; set; }
    }
}