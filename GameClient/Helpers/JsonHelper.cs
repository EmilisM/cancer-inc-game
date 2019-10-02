using System.IO;
using Newtonsoft.Json;

namespace GameClient.Helpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializer Serializer = JsonSerializer.Create();

        public static T Deserialize<T>(string content)
        {
            var jsonWriter = new JsonTextReader(new StringReader(content));

            return Serializer.Deserialize<T>(jsonWriter);
        }
    }
}