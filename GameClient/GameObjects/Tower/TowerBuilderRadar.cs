using System.Collections.Generic;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerBuilderRadar : ITowerBuilder
    {
        private readonly Tower _tower;

        public TowerBuilderRadar()
        {
            _tower = new Tower();
        }

        public void BuildTower(IEnumerable<ApiTower> towers)
        {
            throw new System.NotImplementedException();
        }

        public Tower GetTower()
        {
            return _tower;
        }
    }
}