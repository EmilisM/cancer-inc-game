namespace GameServer.Entities
{
    public class EnemyType
    {
        public int EnemyId { get; set; }
        public int TypeId { get; set; }

        public virtual Enemy Enemy { get; set; }
        public virtual Type Type { get; set; }
    }
}
