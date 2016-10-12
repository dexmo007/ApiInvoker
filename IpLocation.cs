using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ApiInvoker
{
    public class IpLocation
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        [JsonProperty("isp")]
        public string IspName { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("org")]
        public string Organization { get; set; }
        public string Query { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string Timezone { get; set; }
        [JsonProperty("zip")]
        public string ZipCode { get; set; }

        private static readonly RestClient Client = new RestClient("http://ip-api.com");

        public static async Task<IpLocation> Get()
        {
            var request = new RestRequest
            {
                Resource = "json"
            };
            var response = await Client.ExecuteGetTaskAsync(request);
            var res = JsonConvert.DeserializeObject<IpLocation>(response.Content, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            return res;
        }
    }
}