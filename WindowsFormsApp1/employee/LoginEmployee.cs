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

namespace WindowsFormsApp1
{
    public partial class LoginEmployee : Form
    {
        public LoginEmployee()
        {
            InitializeComponent();
            loginBtn.Click += Login_Button;
            closeBtn.Click += Close_Btn;
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

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                string sql = "SELECT employeeId, employeeName FROM employee WHERE loginId = @loginId AND passwd= @passwd ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@loginId", loginId);
                    cmd.Parameters.AddWithValue("@passwd", passwd);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("로그인에 성공하였습니다.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("일치하는 회원 정보가 없습니다.");
                        return;
                    }
                    EmployeeList employList = new EmployeeList();
                    
                }
            }
        }

        private void Close_Btn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginEmployee_Load(object sender, EventArgs e)
        {

        }

    }
}
