using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiEnemyType
    {
        [JsonProperty("enemyId")] public int EnemyId { get; set; }
        [JsonProperty("typeId")] public string TypeId { get; set; }
        [JsonProperty("enemy")] public ApiEnemy Enemy { get; set; }
        [JsonProperty("type")] public ApiType Type { get; set; }
    }
}
