namespace GameServer.Entities
{
    public class TowerAttackType
    {
        public int TowerId { get; set; }
        public int AttackTypeId { get; set; }

        public virtual Type AttackType { get; set; }
        public virtual Tower Tower { get; set; }
    }
}
