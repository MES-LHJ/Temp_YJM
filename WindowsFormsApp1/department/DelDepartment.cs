using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DelDepartment : Form
    {
        private int departId;
        public DelDepartment(int deptId)
        {
            InitializeComponent();

           
            departId = deptId;
            delBtn.Click += Del_Btn;//삭제 버튼
            cancelBtn.Click += Cancel_Btn;//취소 버튼
        }
       
        private void Del_Btn(object sender, EventArgs e)//부서 삭제 버튼
        {
            string sql = "DELETE FROM department WHERE departmentId = '" + departId + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)
                {
                    MessageBox.Show("부서 삭제가 완료 되었습니다.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("부서 삭제에 실패 하였습니다.");
                }
            }
        }
        private void Cancel_Btn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelDepartment_Load(object sender, EventArgs e)
        {
            string sql = "SELECT departmentCode, departmentName FROM department WHERE departmentId='" + departId + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    deptCodeLabel.Text = "부서코드 : " + reader["departmentCode"].ToString();
                    deptNameLabel.Text = "부서명 : " + reader["departmentName"].ToString();
                }
                else
                {
                    MessageBox.Show("부서 정보가 없습니다");
                    this.Close();
                }
            }
        }
    }
}
