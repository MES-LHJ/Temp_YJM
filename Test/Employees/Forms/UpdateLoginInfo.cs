using System;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Test.Employees.Models;
using Test.Utility;

namespace Test.Employees.Forms
{
    public partial class UpdateLoginInfo : Form
    {
        private readonly EmployeeDto updateEmpInfo;//업데이트할 사원 정보
        private readonly Pattern pattern = new Pattern();
        private HttpClient _httpClient;
    
        public UpdateLoginInfo(EmployeeDto empInfo)
        {
            InitializeComponent();
            updateEmpInfo = empInfo;
            Envet();
            Design();
            _httpClient = new HttpClient();
        }

        private void Envet()
        {
            updateBtn.Click += Update_LoginInfo;
            closeBtn.Click += CloseBtn_Click;
        }
        private void Design()
        {
            updateBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            closeBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
        }

        private void Update_LoginInfo(object sender, EventArgs e)
        {
            var loginIdCheck = EmployeeRepository.EmpRepo.GetLoginId(loginIdBox.Text,updateEmpInfo.LoginId);
            if(loginIdCheck ==1)
            {
                MessageBox.Show("중복된 로그인ID가 존재합니다.");
                return;
            }
            if(passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요");
                return;
            }
            if(Regex.IsMatch(passwdBox.Text, pattern.PatternCheck()["passwd"]))
            {
                MessageBox.Show("비밀번호에 특수문자가 포함되었습니다.");
                return;
            }
            var updateLoginInfo = EmployeeRepository.EmpRepo.UpdateLogin(updateEmpInfo.EmployeeId,loginIdBox.Text, passwdBox.Text);
            if (updateLoginInfo == 1)
            {
                MessageBox.Show("로그인정보 수정이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("로그인정보 수정에 실패하였습니다.");
                return;
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
