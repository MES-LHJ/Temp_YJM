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
        private int departmentId; // 부서 ID를 저장할 변수
        public UpdateDepartment(int departId)
        {
            
            InitializeComponent();
            departmentId = departId; // 생성자에서 부서 ID를 받아와서 저장
            Console.WriteLine("수정페이지 deptId: " + departmentId);


            updateBtn.Click += Update_Button;//저장 버튼
            closeBtn.Click += Close_Button;// 닫기 버튼
        }


        private void UpdateDepartment_Load(object sender, EventArgs e)
        {
            string sql = "SELECT departmentCode, departmentName, memo FROM department WHERE departmentId = '" + departmentId + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptCodeBox.Text = reader["departmentCode"].ToString();
                    deptNameBtn.Text = reader["departmentName"].ToString();
                    memoBtn.Text = reader["memo"].ToString();
                }
            }
        }

        private void Update_Button(object sender, EventArgs e)
        {
            Boolean check = true;

            string empCodeCheckSql = "SELECT departmentCode FROM department WHERE departmentCode = @departmentCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))//부서코드 중복 체크
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(empCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", deptCodeBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("중복하는 부서코드가 존재합니다.");
                    check = false;
                    return;
                }
            }
            if (check)
            {
                string sql = "UPDATE department SET departmentCode = @departmentCode, departmentName = @departmentName, memo = @memo " +
                    "WHERE departmentId = '" + departmentId + "'";
                using (SqlConnection conn = new SqlConnection(Server.connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@departmentCode", deptCodeBox.Text);
                    cmd.Parameters.AddWithValue("@departmentName", deptNameBtn.Text);
                    cmd.Parameters.AddWithValue("@memo", memoBtn.Text);

                    try
                    {
                        if (string.IsNullOrWhiteSpace(deptCodeBox.Text))
                        {
                            MessageBox.Show("부서코드 입력하세요");
                            return;
                        }
                        else if (string.IsNullOrWhiteSpace(deptNameBtn.Text))
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
        }
        private void Close_Button(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
