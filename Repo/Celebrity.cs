using Newtonsoft.Json;

namespace CelebritiesDAL
{
    public class Celebrity
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
