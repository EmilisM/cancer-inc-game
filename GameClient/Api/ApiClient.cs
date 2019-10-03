using System;
using System.Collections.Generic;
using System.Net.Http;
using GameClient.Api.ApiObjects;
using GameClient.GameObjects.Tower;
using GameClient.Helpers;

namespace GameClient.Api
{
    public static class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://cancerincgameserver.azurewebsites.net/api/")
        };

        public static IEnumerable<Class> GetClasses(string className = "")
        {
            var classes = Client.GetStringAsync($"class?name={className}");

            return JsonHelper.Deserialize<List<Class>>(classes.Result);
        }

        public static IEnumerable<Tower> GetTowers(string towerName = "")
        {
            var towers = Client.GetStringAsync($"tower?name={towerName}");

            return JsonHelper.Deserialize<List<Tower>>(towers.Result);
        }
    }
}