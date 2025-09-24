using Newtonsoft.Json;

namespace Test.Api.Emp.Dtos
{
    public class TokenData
    {
        [JsonProperty("Data")]
        public TokenDto TokenInfo {  get; set; }

    }
}
