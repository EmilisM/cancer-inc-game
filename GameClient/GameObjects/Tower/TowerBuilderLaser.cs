﻿using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderLaser : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderLaser()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiAttackType> attackTypes, IEnumerable<ApiTower> towers)
        {
            var tower = towers.FirstOrDefault(t => t.Name.Contains(TowerName.Laser.ToString()));

            if (tower == null)
            {
                return;
            }

            var filteredTypes = attackTypes.Where(attackType => attackType.TowerId == tower.Id).ToList();

            if (filteredTypes.Any())
            {
                filteredTypes = null;
            }

            _tower.FromApiTowers(tower, filteredTypes);
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}