using System;
using System.Collections.Generic;
using System.Linq;
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

            var towers = JsonHelper.Deserialize<List<ApiTower>>(towerContent.Result);

            var attackTypes = GetAttackTypes().ToList();

            foreach (var tower in towers)
            {
                var types = attackTypes.Where(attackType => attackType.TowerId == tower.Id).Select(attackType =>
                    new ApiType { Id = attackType.AttackType.Id, Name = attackType.AttackType.Name }).ToList();

                tower.AttackType = types.Count == 0 ? null : types;
            }

            return towers;
        }

        private static IEnumerable<ApiAttackType> GetAttackTypes()
        {
            var towers = Client.GetStringAsync("attacktype");

            return JsonHelper.Deserialize<List<ApiAttackType>>(towers.Result);
        }
    }
}