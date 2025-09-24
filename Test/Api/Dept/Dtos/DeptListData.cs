using System.Collections.Generic;
using Newtonsoft.Json;

namespace Test.Api.Dept.Dtos
{
    public class DeptListData
    {
        [JsonProperty("Data")]
        public List<DeptListDto> DeptList { get; set; }
    }
}
