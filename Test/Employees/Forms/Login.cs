using System;
using System.Drawing;
using System.Windows.Forms;
using Test.Employees.Models;

namespace Test.Employees.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Event();
            Design();
        }

        private void Event()
        {
            loginBtn.Click += Login_Click;
        }
        private void Design()
        {
            loginBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            closeBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
        }
        private void Login_Click(object sender, EventArgs e)
        {
            var loginCheck = EmployeeRepository.EmpRepo.CheckLogin(loginIdBox.Text , passwdBox.Text);
            if(loginCheck == 1)
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
    }
}
