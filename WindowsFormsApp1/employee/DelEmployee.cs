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
    public partial class DelEmployee : Form
    {
        private int employId;
        public DelEmployee(int empId)
        {
            InitializeComponent();
            employId = empId;

            
            delBtn.Click += Del_Button;//삭제 버튼
            cancelBtn.Click += Cancel_Button;//취소 버튼
        }

        private void Del_Button(object sender, EventArgs e)
        {
            Console.WriteLine(employId);
            string sql = "DELETE FROM employee WHERE employeeId = '" + employId + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)// 1개이상 영향을 받았을 때
                {
                    MessageBox.Show("사원 정보가 삭제되었습니다.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("사원 정보 삭제에 실패했습니다.");
                }

            }
        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 취소 버튼 클릭 시 폼 닫기

        }

        private void DelEmployee_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                string sql = "SELECT employeeCode , employeeName FROM employee WHERE employeeId = '" + employId + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    empIdLabel.Text = "사원코드 : " + reader["employeeCode"].ToString();
                    empNameLabel.Text = "사원명 : " + reader["employeeName"].ToString();
                }
                else
                {
                    MessageBox.Show("사원 정보를 찾을 수 없습니다.");
                    this.Close();
                }
            }
        }
    }
}
