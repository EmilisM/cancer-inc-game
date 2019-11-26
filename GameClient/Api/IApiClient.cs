using System.Collections.Generic;
using GameClient.Api.ApiObjects;

namespace GameClient.Api
{
    public interface IApiClient
    {
        IEnumerable<ApiAttackType> GetAttackTypes();
        IEnumerable<ApiClass> GetClasses();
        ApiClass GetClass(int id);
        IEnumerable<ApiEnemy> GetEnemies();
        ApiEnemy GetEnemy(int id);
        IEnumerable<ApiType> GetEnemyTypes(int id);
        IEnumerable<ApiType> GetAllEnemyTypes();
        IEnumerable<ApiTower> GetTowers();
        ApiTower GetTower(int id);
        IEnumerable<ApiAttackType> GetTowerAttackTypes(int id);
        IEnumerable<ApiType> GetTypes();
        ApiType GetType(int id);
    }
}