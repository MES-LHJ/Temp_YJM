using System.Net.Http;
using System.Net.Http.Headers;

namespace Test.Utility
{
    public class TokenManager
    {
        private static readonly TokenManager instance = new TokenManager();
        private TokenManager() { }
        public static TokenManager TokenInfo => instance;

        public string EmployeeToken { get; private set; }
        public string CompanyToken { get; private set; }


        public void UseHeaderBearerToken(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void SetEmployeeToken(string employeeToken)
        {
            EmployeeToken = employeeToken;
        }
        public void SetCompanyToken(string companyToken)
        {
            CompanyToken = companyToken;
        }
    }
}
