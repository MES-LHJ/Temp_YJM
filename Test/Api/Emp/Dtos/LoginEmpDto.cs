using Newtonsoft.Json;

namespace Test.Api.Emp.Dtos
{
    public class LoginEmpDto
    {
        [JsonProperty("loginId")]
        public string EmpIdApi { get; set; }
        [JsonProperty("password")]
        public string EmpPassApi { get; set; }
    }
}
