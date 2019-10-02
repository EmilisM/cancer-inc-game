using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using GameClient.Api.ApiObjects;

namespace GameClient.Api
{
    public static class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://cancerincgameserver.azurewebsites.net/api/")
        };

        public static IEnumerable<Class> GetClass(string className = "")
        {
            var classes = Client.GetStringAsync($"class?name={className}");

            return JsonSerializer.Deserialize<IEnumerable<Class>>(classes.Result);
        }
    }
}