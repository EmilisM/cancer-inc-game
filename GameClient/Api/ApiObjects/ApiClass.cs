using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiClass
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("damageModifier")] public double DamageModifier { get; set; }
        [JsonProperty("speedModifier")] public double SpeedModifier { get; set; }
    }
}