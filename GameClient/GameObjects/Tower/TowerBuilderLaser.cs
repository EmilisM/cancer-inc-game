using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderLaser : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderLaser()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiTower> towers)
        {
            var tower = towers.FirstOrDefault(t => t.Name.Contains("Laser"));

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