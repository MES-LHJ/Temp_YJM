using System;
using System.Windows.Forms;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Emp.Forms
{
    public partial class CompanyLogin : Form
    {
        private readonly ColorInfo btnColor =new ColorInfo();
        public CompanyLogin()
        {
            InitializeComponent();
            Event();
            Design();
        }

        public void Event()
        {
            loginBtn.Click += LoginBtn_Click;//업체 로그인
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
        }

        private void Design()
        {
            btnColor.ChangeSaveBtnColor(loginBtn);
            btnColor.ChangeCloseBtnColor(closeBtn);
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            var req = new { brn = companyIdBox.Text };//업체 로그인 정보

            var comLoginCheck = await EmpRepository.EmpRepo.GetComToken(req.brn);//업체 토큰 저장  
            if(comLoginCheck == true)
            {
                MessageBox.Show("로그인 성공");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("로그인 실패");
                return;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
