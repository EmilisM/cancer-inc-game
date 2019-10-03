using System.Collections.Generic;
using GameClient.Api;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public class TowerDirector
    {
        private readonly IEnumerable<ApiTower> _towers;

        public TowerDirector()
        {
            _towers = ApiClient.GetTowers();
        }

        public Tower Construct(ITowerBuilder builder)
        {
            builder.BuildTower(_towers);

            return builder.GetTower();
        }
    }
}