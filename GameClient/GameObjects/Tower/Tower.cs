using System;
using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Tower
{
    public class Tower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public double? Damage { get; set; }
        public double? Speed { get; set; }
        public int Size { get; set; }
        public int? Range { get; set; }
        public string Effect { get; set; }
        public bool Poison { get; set; }

        public ClassType ClassType { get; set; }
        public IEnumerable<AttackType> AttackTypes { get; set; }

        public void FromApiTowers(ApiTower tower, IEnumerable<ApiAttackType> towerAttackTypes)
        {
            Id = tower.Id;
            Name = tower.Name;
            Cost = tower.Cost;
            Damage = tower.Damage;
            Effect = tower.Effect;
            Poison = tower.Poison;
            Range = tower.Range;
            Size = tower.Size;
            Speed = tower.Speed;

            ClassType = tower.Class == null
                ? ClassType.All
                : Enum.Parse<ClassType>(tower.Class.Name);

            AttackTypes = towerAttackTypes?.Select(towerAttackType => Enum.Parse<AttackType>(towerAttackType.AttackType.Name));
        }
    }
}