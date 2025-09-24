using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Utility;


namespace Test.Api.Emp.Dtos
{

    public class EmpRepository
    {
        private static readonly EmpRepository empRepository = new EmpRepository();
        private EmpRepository() { }
        public static EmpRepository EmpRepo => empRepository;

        private string ComToken => TokenManager.TokenInfo.CompanyToken; //업체 토큰
        private string EmpToken => TokenManager.TokenInfo.EmployeeToken; //사원토큰

        public async Task<bool> GetComToken(string brnStr)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new { brn = brnStr });

                var content = new StringContent(json, Encoding.UTF8, "application/json");//전송할 문자열 , ,json타입
                                                                                         //데이터 넘길 객체
                var response = await client.PostAsync("http://test.smartqapis.com:5001/api/customers/Authenticate", content);
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var loginResult = JsonConvert.DeserializeObject<TokenData>(result);
                        // 토큰만 사용
                        TokenManager.TokenInfo.SetCompanyToken(loginResult.TokenInfo.CompanyToken);//업체 토큰 저장
                    }
                    else
                    {
                        var failResult = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(failResult);
                    }

                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> GetEmpToken(LoginEmpDto loginEmpDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //http 헤더에 (autorization) 토큰을 권한 헤더에 설정
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, ComToken);

                    var json = JsonConvert.SerializeObject(loginEmpDto); //json 파싱
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://test.smartqapis.com:5000/api/login/", content);//비동기 메서드

                    var result = await response.Content.ReadAsStringAsync();
                    var empLogin = JsonConvert.DeserializeObject<TokenDto>(result);

                    TokenManager.TokenInfo.SetEmployeeToken(empLogin.EmpToken); // 사원 토큰 저장

                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<List<EmpListDto>> GetEmpList()
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", EmpToken);
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Employee?FactoryId=1");

                var result = await res.Content.ReadAsStringAsync();
                var empData = JsonConvert.DeserializeObject<EmpListData>(result);
                List<EmpListDto> empInfo = empData.EmpInfo;

                return empInfo;
            }
        }

        public async Task<bool> CheckDeptIdDelDept(long deptId)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", EmpToken);
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Employee?FactoryId=1");

                var result = await res.Content.ReadAsStringAsync();
                var empData = JsonConvert.DeserializeObject<EmpListData>(result);
                List<EmpListDto> empInfo = empData.EmpInfo;

                return empInfo.Any(x => x.DepartmentId == deptId);
            }
        }

        //public async Task<long> InsertEmpApi(EmpDto empDto)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            // 헤더 설정
        //            TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

        //            // JSON
        //            var json = JsonConvert.SerializeObject(empDto);
        //            var content = new StringContent(json, Encoding.UTF8, "application/json");

        //            // API 호출
        //            var res = await client.PostAsync("http://test.smartqapis.com:5000/api/Employee?FactoryId=1", content);
        //            if (!res.IsSuccessStatusCode)
        //            {
        //                var result = await res.Content.ReadAsStringAsync();
        //                Console.WriteLine("왜틀리지 :   " + result);
        //                return 0;
        //            }
        //            else
        //            {
        //                var result = await res.Content.ReadAsStringAsync();
        //                dynamic resultData = JsonConvert.DeserializeObject(result);
        //                long empId = resultData.Data;
        //                // 성공 여부
        //                return empId;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            return 0;
        //        }
        //    }
        //}
        public async Task<long> InsertEmpApi(EmpListDto empDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // 헤더 설정
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                    // JSON
                    var json = JsonConvert.SerializeObject(empDto, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore, // null인 속성 제외
                        DefaultValueHandling = DefaultValueHandling.Ignore // 기본값(0, false)인 속성 제외
                    });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // API 호출
                    var res = await client.PostAsync("http://test.smartqapis.com:5000/api/Employee?FactoryId=1", content);

                    if (!res.IsSuccessStatusCode)
                    {
                        var result = await res.Content.ReadAsStringAsync();
                        Console.WriteLine("왜틀리지 :   " + result);
                        return 0;
                    }
                    else
                    {
                        var result = await res.Content.ReadAsStringAsync();
                        dynamic resultData = JsonConvert.DeserializeObject(result);
                        long empId = resultData.Data;
                        // 성공 여부
                        return empId;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return 0;
                }
            }
        }
        public async Task<bool> CheckInsertEmpCode(string empCode)
        {
            using (var client = new HttpClient())
            {   //Authorization : 권한 부여
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);
                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Employee?Factory=1");

                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadAsStringAsync();
                    var empData = JsonConvert.DeserializeObject<EmpListData>(result);
                    List<EmpListDto> empInfo = empData.EmpInfo;

                    return empInfo.Any(e => e.Code == empCode);
                }
                return false;
            }
        }

        public async Task<bool> CheckUpdateEmpCode(string empCode, string myEmpCode)
        {
            using (var client = new HttpClient())
            {   //Authorization : 권한 부여
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);
                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Employee?Factory=1");

                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadAsStringAsync();
                    var empData = JsonConvert.DeserializeObject<EmpListData>(result);
                    List<EmpListDto> empInfo = empData.EmpInfo;

                    return empInfo.Any(e => e.Code == empCode && e.Code != myEmpCode);
                }
                return false;
            }
        }

        public async Task<bool> CheckLoginId(string loginId)
        {
            using (var client = new HttpClient())
            {   //Authorization : 권한 부여
                TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);
                var res = await client.GetAsync("http://test.smartqapis.com:5000/api/Employee?Factory=1");

                if (res.IsSuccessStatusCode)
                {
                    var result = await res.Content.ReadAsStringAsync();
                    var empData = JsonConvert.DeserializeObject<EmpListData>(result);
                    List<EmpListDto> empInfo = empData.EmpInfo;

                    return empInfo.Any(e => e.LoginId == loginId);
                }
                return false;
            }
        }

        public async Task<bool> UpdateEmpApi(long empId, EmpListDto empDto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);

                    var json = JsonConvert.SerializeObject(empDto, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore, // null인 속성 제외
                        DefaultValueHandling = DefaultValueHandling.Ignore // 기본값(0, false)인 속성 제외
                    });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var res = await client.PutAsync($"http://test.smartqapis.com:5000/api/Employee/{empId}", content);

                    return res.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public async Task<bool> DelEmpApi(long empId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    TokenManager.TokenInfo.UseHeaderBearerToken(client, EmpToken);
                    var res = await client.DeleteAsync($"http://test.smartqapis.com:5000/api/Employee/{empId}");

                    return res.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
