using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiType
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}