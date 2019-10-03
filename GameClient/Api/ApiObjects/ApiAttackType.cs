using Newtonsoft.Json;

namespace GameClient.Api.ApiObjects
{
    public class ApiAttackType
    {
        [JsonProperty("towerId")] public int TowerId { get; set; }

        [JsonProperty("attackTypeId")] public int AttackTypeId { get; set; }

        [JsonProperty("attackType")] public ApiType AttackType { get; set; }

        [JsonProperty("tower")] public ApiTower Tower { get; set; }
    }
}