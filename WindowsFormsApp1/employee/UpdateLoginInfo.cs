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

namespace WindowsFormsApp1.employee
{
    public partial class UpdateLoginInfo : Form
    {
        private int employeeId;
        public UpdateLoginInfo(int empId)
        {
            InitializeComponent();
            employeeId = empId;
            updateBtn.Click += UpdateBtn_Click;
            closeBtn.Click += CloseBtn_Click;

        }

        private void UpdateLoginInfo_Load(object sender, EventArgs e)
        {

        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Boolean check = true;

            string loginIdChecksql = "SELECT loginId FROM employee WHERE loginId= @loginId";
            using(SqlConnection conn= new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(loginIdChecksql, conn);
                cmd.Parameters.AddWithValue("@loginId", loginIdBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("로그인Id가 중복입니다.");
                    check = false;
                    return;
                }
            }

            if (check) {
                string sql = "UPDATE employee SET loginId = @loginId, passwd = @passwd WHERE employeeId = '" + employeeId + "'";
                using (SqlConnection conn = new SqlConnection(Server.connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@loginId", loginIdBox.Text);
                    cmd.Parameters.AddWithValue("@passwd", passwdBox.Text);

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

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("수정이 완료되었습니다.");
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("수정 실패 : " + ex.Message);
                        return;
                    }
                }
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
