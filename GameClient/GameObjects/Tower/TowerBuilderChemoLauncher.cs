using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderChemoLauncher : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderChemoLauncher()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiAttackType> attackTypes, IEnumerable<ApiTower> towers)
        {
            var tower = towers.FirstOrDefault(t => (int)TowerName.ChemoLauncher == t.Id);

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