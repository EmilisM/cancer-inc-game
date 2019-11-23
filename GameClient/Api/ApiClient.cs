using System;
using System.Collections.Generic;
using System.Net.Http;
using GameClient.Api.ApiObjects;
using GameClient.Helpers;

namespace GameClient.Api
{
    public class ApiClient : IApiClient
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://cancerincserver.azurewebsites.net/api/")
        };

        public IEnumerable<ApiAttackType> GetAttackTypes()
        {
            var attackTypes = Client.GetStringAsync("attacktypes");

            return JsonHelper.Deserialize<List<ApiAttackType>>(attackTypes.Result);
        }

        public IEnumerable<ApiClass> GetClasses(string className = "")
        {
            var classes = Client.GetStringAsync($"class?name={className}");

            return JsonHelper.Deserialize<List<ApiClass>>(classes.Result);
        }

        public ApiClass GetClass(int id)
        {
            var apiClass = Client.GetStringAsync($"class/{id}");

            return JsonHelper.Deserialize<ApiClass>(apiClass.Result);
        }

        public IEnumerable<ApiEnemy> GetEnemies()
        {
            var enemies = Client.GetStringAsync("enemy");

            return JsonHelper.Deserialize<List<ApiEnemy>>(enemies.Result);
        }

        public ApiEnemy GetEnemy(int id)
        {
            var enemy = Client.GetStringAsync($"enemy/{id}");

            return JsonHelper.Deserialize<ApiEnemy>(enemy.Result);
        }

        public IEnumerable<ApiType> GetEnemyTypes(int id)
        {
            var types = Client.GetStringAsync($"enemy/{id}/type");

            return JsonHelper.Deserialize<List<ApiType>>(types.Result);
        }
        public IEnumerable<ApiType> GetAllEnemyTypes()
        {
            var types = Client.GetStringAsync("enemytype");

            return JsonHelper.Deserialize<List<ApiType>>(types.Result);
        }

        public IEnumerable<ApiTower> GetTowers(string towerName = "")
        {
            var towerContent = Client.GetStringAsync($"tower?name={towerName}");

            return JsonHelper.Deserialize<List<ApiTower>>(towerContent.Result);
        }

        public ApiTower GetTower(int id)
        {
            var tower = Client.GetStringAsync($"tower/{id}");

            return JsonHelper.Deserialize<ApiTower>(tower.Result);
        }

        public IEnumerable<ApiAttackType> GetTowerAttackTypes(int id)
        {
            var towers = Client.GetStringAsync($"tower/{id}/type");

            return JsonHelper.Deserialize<List<ApiAttackType>>(towers.Result);
        }

        public IEnumerable<ApiType> GetTypes()
        {
            var types = Client.GetStringAsync("type");

            return JsonHelper.Deserialize<List<ApiType>>(types.Result);
        }

        public ApiType GetType(int id)
        {
            var type = Client.GetStringAsync($"type/{id}");

            return JsonHelper.Deserialize<ApiType>(type.Result);
        }
    }
}