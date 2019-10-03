using System;
using System.Collections.Generic;
using System.Net.Http;
using GameClient.Api.ApiObjects;
using GameClient.Helpers;

namespace GameClient.Api
{
    public static class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://cancerincgameserver.azurewebsites.net/api/")
        };

        public static IEnumerable<ApiClass> GetClasses(string className = "")
        {
            var classes = Client.GetStringAsync($"class?name={className}");

            return JsonHelper.Deserialize<List<ApiClass>>(classes.Result);
        }

        public static IEnumerable<ApiTower> GetTowers(string towerName = "")
        {
            var towerContent = Client.GetStringAsync($"tower?name={towerName}");

            return JsonHelper.Deserialize<List<ApiTower>>(towerContent.Result);
        }

        public static IEnumerable<ApiAttackType> GetTowerAttackTypes()
        {
            var towers = Client.GetStringAsync("attacktype");

            return JsonHelper.Deserialize<List<ApiAttackType>>(towers.Result);
        }
    }
}