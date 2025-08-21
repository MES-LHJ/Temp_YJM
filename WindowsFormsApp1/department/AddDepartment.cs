using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddDepartment : Form
    {

        public AddDepartment()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            string sql = "INSERT INTO department (departmentId, departmentName, memo) " +
                          "VALUES (@departmentId, @departmentName, @memo)";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptCodeBox.Text);
                cmd.Parameters.AddWithValue("@departmentName", deptNameBox.Text);
                cmd.Parameters.AddWithValue("@memo", memoBox.Text);
                try
                {
                    if (string.IsNullOrWhiteSpace(deptCodeBox.Text))
                    {
                        MessageBox.Show("부서코드를 입력해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(deptNameBox.Text))
                    {
                        MessageBox.Show("부서명을 입력해주세요.");
                        return;
                    }
                    else
                    {
                        cmd.ExecuteNonQuery(); // 쿼리 실행
                        MessageBox.Show("부서가 성공적으로 추가되었습니다.");
                        this.Close();   
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message);
                }
              
            }
        }
        private void Cancel_Button(object sender, EventArgs e) //취소 버튼
        {
            this.Close(); // 폼 닫기
        }
    }
}
