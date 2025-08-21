using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UpdateDepartment : Form
    {
        private string departmentId; // 부서 ID를 저장할 변수
        public UpdateDepartment(string departId)
        {
            InitializeComponent();
            departmentId = departId; // 생성자에서 부서 ID를 받아와서 저장
            Console.WriteLine(departmentId); // 디버깅용 출력
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string sql = "SELECT departmentId, departmentName, memo FROM department WHERE departmentId = '"+departmentId+"'";
            using(SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptCodeBox.Text = reader["departmentId"].ToString();
                    deptNameBtn.Text = reader["departmentName"].ToString();
                    memoBtn.Text = reader["memo"].ToString();
                }
            }
        }
        private void Update_Button(object sender, EventArgs e)
        {
            string sql = "UPDATE department SET departmentId = @departmentId, departmentName = @departmentName, memo = @memo " +
                "WHERE departmentId = '"+departmentId+"'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptCodeBox.Text);
                cmd.Parameters.AddWithValue("@departmentName", deptNameBtn.Text);
                cmd.Parameters.AddWithValue("@memo", memoBtn.Text);

                try
                {
                    if (string.IsNullOrWhiteSpace(deptCodeBox.Text))
                    {
                        MessageBox.Show("부서코드 입력하세요");
                        return;
                    }else if (string.IsNullOrWhiteSpace(deptNameBtn.Text))
                    {
                        MessageBox.Show("부서명을 입력하세요");
                        return;
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("수정완료");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("수정 실패: " + ex.Message);
                    return;
                }
            }

        }
        private void Close_Button(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
