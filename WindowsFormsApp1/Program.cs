using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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

            LoginEmployee login = new LoginEmployee();
            if (login.ShowDialog() == DialogResult.OK)// 로그인 폼을 모달로 띄우고 결과를 받음
            {
                Application.Run(new EmployeeList());
            }
            //plication.Run(new EmployeeList());
        }
    }
}
