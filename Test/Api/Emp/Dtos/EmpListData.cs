using System.Collections.Generic;
using Newtonsoft.Json;

namespace Test.Api.Emp.Dtos
{
    public class EmpListData
    {

        [JsonProperty("Data")]
        public List<EmpListDto> EmpInfo { get; set; }
    }
}
