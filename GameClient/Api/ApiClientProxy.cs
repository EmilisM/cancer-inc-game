using System.Collections.Generic;
using GameClient.Api.ApiObjects;

namespace GameClient.Api
{
    public class ApiClientProxy : IApiClient
    {
        private readonly IApiClient _client;

        public ApiClientProxy()
        {
            _client = new ApiClient();
        }

        public IEnumerable<ApiAttackType> GetAttackTypes()
        {
            return _client.GetAttackTypes();
        }

        public IEnumerable<ApiClass> GetClasses(string className = "")
        {
            return _client.GetClasses(className);
        }

        public ApiClass GetClass(int id)
        {
            return id < 0 ? null : _client.GetClass(id);
        }

        public IEnumerable<ApiEnemy> GetEnemies()
        {
            return _client.GetEnemies();
        }

        public ApiEnemy GetEnemy(int id)
        {
            return id < 0 ? null : _client.GetEnemy(id);
        }

        public IEnumerable<ApiType> GetEnemyTypes(int id)
        {
            return id < 0 ? null : _client.GetEnemyTypes(id);
        }

        public IEnumerable<ApiType> GetAllEnemyTypes()
        {
            return _client.GetAllEnemyTypes();
        }

        public IEnumerable<ApiTower> GetTowers(string towerName = "")
        {
            return _client.GetTowers(towerName);
        }

        public ApiTower GetTower(int id)
        {
            return id < 0 ? null : _client.GetTower(id);
        }

        public IEnumerable<ApiAttackType> GetTowerAttackTypes(int id)
        {
            return id < 0 ? null : _client.GetTowerAttackTypes(id);
        }

        public IEnumerable<ApiType> GetTypes()
        {
            return _client.GetTypes();
        }

        public ApiType GetType(int id)
        {
            return id < 0 ? null : _client.GetType(id);
        }
    }
}