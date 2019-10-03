using System.Collections.Generic;
using System.Linq;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderCoinMiner : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderCoinMiner()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiTower> towers)
        {
            var tower = towers.FirstOrDefault(t => t.Name.Contains("Coin miner"));

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