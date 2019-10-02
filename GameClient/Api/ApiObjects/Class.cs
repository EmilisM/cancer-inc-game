using System.Runtime.Serialization;

namespace GameClient.Api.ApiObjects
{
    [DataContract]
    public class Class
    {
        [DataMember] public int id { get; set; }
        [DataMember] public string name { get; set; }
        [DataMember] private double damageModifier { get; set; }
        [DataMember] private double speedModifier { get; set; }
    }
}