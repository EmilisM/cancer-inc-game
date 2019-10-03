using System.Collections.Generic;
using GameClient.Api;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerDirector
    {
        private readonly IEnumerable<ApiAttackType> _attackType;
        private readonly IEnumerable<ApiTower> _towers;

        public TowerDirector()
        {
            _towers = ApiClient.GetTowers();
            _attackType = ApiClient.GetTowerAttackTypes();
        }

        public Tower Construct(ITowerBuilder builder)
        {
            builder.BuildTower(_attackType, _towers);

            return builder.GetTower();
        }
    }
}