using Newtonsoft.Json;

namespace Test.Api.Emp.Dtos
{
    public class TokenDto
    {
        [JsonProperty("Token")]
        public string CompanyToken { get; set; }

        [JsonProperty("Data")]
        public string EmpToken {  get; set; }
       
    }
}
