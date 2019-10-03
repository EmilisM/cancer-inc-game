﻿using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderCrossbow : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderCrossbow()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiTower> towers)
        {
            var tower = towers.FirstOrDefault(t => t.Name.Contains("Crossbow"));

            if (tower == null)
            {
                return;
            }

            _tower.FromApiTower(tower);
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}