using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiEnemy
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("hp")] public double Hitpoints { get; set; }
        [JsonProperty("speed")] public double SpeedModifier { get; set; }
    }
}
