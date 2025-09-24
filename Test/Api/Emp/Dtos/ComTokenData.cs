using Newtonsoft.Json;

namespace Test.Api.Emp.Dtos
{
    public class ComTokenData
    {
        [JsonProperty("Data")]
        public TokenDto TokenInfo {  get; set; }

    }
}
