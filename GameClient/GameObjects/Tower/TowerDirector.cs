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
            IApiClient client = new ApiClientProxy();

            _towers = client.GetTowers();
            _attackType = client.GetAttackTypes();
        }

        public Tower Construct(ITowerBuilder builder)
        {
            builder.BuildTower(_attackType, _towers);

            return builder.GetTower();
        }
    }
}