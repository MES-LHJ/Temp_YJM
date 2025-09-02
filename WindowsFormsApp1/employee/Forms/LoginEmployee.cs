using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.employee.Models;

namespace WindowsFormsApp1
{
    public partial class LoginEmployee : Form

    {
        public LoginEmployee()
        {
            InitializeComponent();
            Click_Event();
        }

        private void Click_Event()
        {
            loginBtn.Click += Login_Button;//로그인 버튼
            closeBtn.Click += Close_Btn;//닫기 버튼
        }
        private void Login_Button(object sender, EventArgs e)
        {
            string loginId = loginIdBox.Text;
            string passwd = passwdBox.Text;

            if (Regex.IsMatch(passwd, "[^a-zA-Z0-9]"))
            {
                MessageBox.Show("비밀번호에 특수문자가 포함되어 있습니다.");
                return;
            }
            else if (passwd.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                return;
            }

            var checkLogin = EmployeeRepository.EmpRepo.CheckLogin(loginId, passwd);
           
            if (checkLogin == 1)
            {
                MessageBox.Show("로그인에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("로그인에 실패하였습니다.");
                return;
            }
        }

        private void Close_Btn(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
