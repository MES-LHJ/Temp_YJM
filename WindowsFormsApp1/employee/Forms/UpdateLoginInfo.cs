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
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1.employee
{
    public partial class UpdateLoginInfo : Form
    {
        private int employeeId;
        private string myLoginId;
        public UpdateLoginInfo(int empId, string myLoginId)
        {
            employeeId = empId;
            this.myLoginId = myLoginId;

            InitializeComponent();
            Click_Event();

        }

        private void Click_Event()
        {
            updateBtn.Click += UpdateBtn_Click;
            closeBtn.Click += CloseBtn_Click;
        }


        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string loginId = loginIdBox.Text;
            string passwd = passwdBox.Text;
            var loginIdCheck = EmployeeRepository.empRepo.GetLoginId(loginId, myLoginId);

            if (loginIdCheck == 1)
            {
                MessageBox.Show("중복되는 로그인 아이디가 존재합니다.");

                return;
            }
            try
            {
                if (Regex.IsMatch(passwdBox.Text, "[^a-zA-Z0-9]"))
                {
                    MessageBox.Show("비밀번호에 특수문자가 포함되어있습니다.");
                    return;
                }
                else if (passwdBox.Text.Length < 8)
                {
                    MessageBox.Show("비밀번호를 8자리이상 입력해주세요.");
                    return;
                }
                EmployeeRepository.empRepo.UpdateLogin(employeeId, loginId, passwd);
                MessageBox.Show("수정이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("수정 실패 : " + ex.Message);
                return;
            }

        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
