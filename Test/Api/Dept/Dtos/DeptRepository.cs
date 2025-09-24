using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Utility;

namespace Test.Api.Dept.Dtos
{
    public class DeptRepository
    {
        private static readonly DeptRepository instance = new DeptRepository();
        private DeptRepository() { }
        public static DeptRepository DepartmentRepo => instance;

        private string EmpToken => TokenManager.TokenInfo.EmployeeToken;

        public async Task<List<DeptListDto>> GetDepartmentCode()
        {
            using (var client = new HttpClient())
            {
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Department?FactoryId=1");

                var result = await res.Content.ReadAsStringAsync();
                var deptData = JsonConvert.DeserializeObject<DeptListData>(result);

                List<DeptListDto> deptInfo = deptData.DeptList;
                return deptInfo;
            }
        }

        public async Task<long> InsertDeptCheck(DeptDto deptDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                    var json = JsonConvert.SerializeObject(deptDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var res = await client.PostAsync("http://test.smartqapis.com:5000/api/Department", content);

                    if (res.IsSuccessStatusCode)
                    {
                        var result = await res.Content.ReadAsStringAsync();
                        dynamic dataInfo = JsonConvert.DeserializeObject(result);
                        var deptId = dataInfo.Data;

                        return deptId;
                    }
                    else
                    {
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }

        }
        public async Task<bool> UpdateDeptCheck(long deptId, DeptDto deptDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                    var json = JsonConvert.SerializeObject(deptDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var res = await client.PutAsync($"http://test.smartqapis.com:5000/api/Department/{deptId}", content);

                    //if (!res.IsSuccessStatusCode)
                    //{
                    //    var result = await res.Content.ReadAsStringAsync();
                    //    Console.WriteLine("실패하면 : " + result);
                    //}
                    //else
                    //{
                    //    var successResult = await res.Content.ReadAsStringAsync();
                    //    Console.WriteLine("성공하면 : " + successResult);
                    //}

                    return res.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
        public async Task<bool> DelDeptCheck(long deptId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                    var res = await client.DeleteAsync($"http://test.smartqapis.com:5000/api/Department/{deptId}");
                    //if (!res.IsSuccessStatusCode)
                    //{
                    //    var result = await res.Content.ReadAsStringAsync();
                    //    Console.WriteLine("실패하면 : " + result);
                    //}
                    //else
                    //{
                    //    var successResult = await res.Content.ReadAsStringAsync();
                    //    Console.WriteLine("성공하면 : " + successResult);
                    //}

                    return res.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public async Task<bool> CheckInsertDeptCode(string deptCode)
        {
            using (var client = new HttpClient())
            {
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Department?FactoryId=1");

                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadAsStringAsync();
                    var deptData = JsonConvert.DeserializeObject<DeptListData>(result);
                    var deptList = deptData.DeptList;

                    return deptList.Any(d => d.Code == deptCode);
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> CheckUpdateDeptCode(string deptCode, string myDeptCode)
        {
            using (var client = new HttpClient())
            {
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Department?FactoryId=1");

                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadAsStringAsync();
                    var deptData = JsonConvert.DeserializeObject<DeptListData>(result);
                    var deptList = deptData.DeptList;

                    return deptList.Any(d => d.Code == deptCode && d.Code != myDeptCode);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
