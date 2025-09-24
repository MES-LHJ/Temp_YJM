using System;
using System.Windows.Forms;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Emp.Forms
{
    public partial class LoginEmpToken : Form
    {
        private readonly ColorInfo btnColor = new ColorInfo();
        public LoginEmpToken()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            empLoginBtn.Click += EmpLoginBtn_Click;//사원 로그인
            closeBtn.Click += CloseBtn_Click;//닫기버튼
        }


        private void Design()
        {
            btnColor.ChangeSaveBtnColor(empLoginBtn);//저장버튼 색상 변경
            btnColor.ChangeCloseBtnColor(closeBtn);
        }

        private async void EmpLoginBtn_Click(object sender, EventArgs e)
        {

            var req = new LoginEmpDto//로그인 할 사원 정보
            {
                EmpIdApi = empLoginidBox.Text,
                EmpPassApi = empPasswdBox.Text,
                // FactoryId = factoryId
            };

            var empLoginCheck = await EmpRepository.EmpRepo.GetEmpToken(req);//사원토큰 저장

            if (empLoginCheck == true)
            {
                MessageBox.Show("사원 로그인에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사원 로그인에 실패하였습니다.");
                return;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
