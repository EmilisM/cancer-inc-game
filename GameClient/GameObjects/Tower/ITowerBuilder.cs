using System.Collections.Generic;
using GameClient.Api.ApiObjects;

namespace GameClient.GameObjects.Tower
{
    public interface ITowerBuilder
    {
        void BuildTower(IEnumerable<ApiTower> towers);

        Tower GetTower();
    }
}