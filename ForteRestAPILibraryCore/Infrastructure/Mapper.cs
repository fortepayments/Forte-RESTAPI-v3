using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Forte
{
    public static class Mapper<T>
    {
        public static T MapFromJson(string json, string parentToken = null)
        {
            var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

            return JsonConvert.DeserializeObject<T>(jsonToParse);
        }
    }
}
