using System;
using System.Windows.Forms;
using Test.Api.Emp.Forms;


namespace Test
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new test());

            //Login login= new Login();
            //if (login.ShowDialog() == DialogResult.OK)
            //{

            //Application.Run(new EmployeeList());
            // }


            CompanyLogin companyLogin = new CompanyLogin();
            if (companyLogin.ShowDialog() == DialogResult.OK)
            {
                LoginEmpToken loginEmpToken = new LoginEmpToken();
                if(loginEmpToken.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new ApiEmpList());

                }
            }
        }
    }
}
