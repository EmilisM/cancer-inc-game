using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiTower
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("cost")] public int Cost { get; set; }
        [JsonProperty("damage")] public int? Damage { get; set; }
        [JsonProperty("speedPerSecond")] public double? Speed { get; set; }
        [JsonProperty("size")] public int Size { get; set; }
        [JsonProperty("range")] public int? Range { get; set; }
        [JsonProperty("effect")] public string Effect { get; set; }
        [JsonProperty("poison")] public bool Poison { get; set; }

        [JsonProperty("class")] public ApiClass Class { get; set; }

        public IEnumerable<ApiType> AttackType { get; set; }
    }
}