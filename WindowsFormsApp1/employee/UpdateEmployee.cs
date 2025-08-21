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
    public partial class UpdateEmployee : Form
    {
        private string employeeId; // 수정할 사원 ID를 저장할 변수
        private int gender;
        public UpdateEmployee(string empId)
        {
            
            InitializeComponent();
            
            employeeId = empId;
            empCodeBox.Text = employeeId; // 생성자에서 사원 ID를 받아와서 텍스트 박스에 설정
            empCodeBox.EnabledChanged += TextBox2_EnabledChanged;
        }


        private void TextBox2_EnabledChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            deptNameBox.ReadOnly = true;
            
            string sql = "SELECT a.departmentId, b.departmentName, a.employeeName, a.employeeId, a.loginId, a.passwd, a.employeeRank," +
                "a.employeeType, a.phone, a.email, a.messId, a.memo, a.gender FROM employee a JOIN department b on a.departmentId = b.departmentId " +
                "WHERE employeeId='"+ employeeId+"'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {   
                    deptCodeComboBox.Text = reader["departmentId"].ToString();
                    deptNameBox.Text = reader["departmentName"].ToString();
                    empNameBox.Text = reader["employeeName"].ToString();
                    empRankBox.Text = reader["employeeRank"].ToString();
                    empTypeBox.Text = reader["employeeType"].ToString();
                    phoneBox.Text = reader["phone"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    messageBox.Text = reader["messId"].ToString();
                    memoBox.Text = reader["memo"].ToString();
                    
                    gender = Convert.ToInt32(reader["gender"]);//string int로
                    Console.WriteLine(gender);

                    if (gender == 1)
                    {
                        checkBox2.Checked = true;
                    }
                    else if (gender == 2)
                    {
                        checkBox3.Checked = true;
                    }

                }
            };
           
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화
            string sql = "SELECT departmentId from department ORDER BY departmentNo";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {   
                    string departmentId = reader["departmentId"].ToString();
                    deptCodeComboBox.Items.Add(departmentId);
                }
            }
        }
        private void DepName_Change(object sender, EventArgs e)
        {

            string sql = "SELECT departmentName FROM department WHERE departmentId=@departmentId ";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptCodeComboBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptNameBox.Text = reader["departmentName"].ToString();
                }
            }
        }
        private void Complete_Button(object sender, EventArgs e) //수정 완료 버튼
        {
            string sql = "Update employee SET departmentId = @departmentId, employeeId=@employeeId, employeeName = @employeeName, " +
                         "employeeRank = @employeeRank, employeeType = @employeeType, " +
                         "phone = @phone, email = @email, messId = @messId, memo = @memo,gender='"+gender+"'WHERE employeeId ='"+ employeeId+"'";
            
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptCodeComboBox.Text);
                cmd.Parameters.AddWithValue("@employeeId", empCodeBox.Text);
                cmd.Parameters.AddWithValue("@employeeName", empNameBox.Text);
                cmd.Parameters.AddWithValue("@employeeRank", empRankBox.Text);
                cmd.Parameters.AddWithValue("@employeeType", empTypeBox.Text);
                cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                cmd.Parameters.AddWithValue("@email", emailBox.Text);
                cmd.Parameters.AddWithValue("@messId", messageBox.Text);
                cmd.Parameters.AddWithValue("@memo", memoBox.Text);
                string email = emailBox.Text;
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Console.WriteLine(deptCodeComboBox.Text);
                try
                {
                    if (string.IsNullOrEmpty(deptCodeComboBox.Text))
                    {
                        MessageBox.Show("부서코드를 선택해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(empCodeBox.Text))
                    {
                        MessageBox.Show("사원코드를 입력해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(empNameBox.Text))
                    {
                        MessageBox.Show("사원명을 입력해주세요.");
                        return;
                    }
                    else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, pattern))
                    {
                        MessageBox.Show("이메일 형식이 틀립니다.");
                        return;
                    }
                        
                        cmd.ExecuteNonQuery();
                 
                        MessageBox.Show("수정 완료.");
                        this.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message);
                }

            }
        }
        private void Check_Box(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Enabled = false;
                gender = 2;
            }
            if (checkBox2.Checked)
            {
                checkBox3.Enabled = false;
                gender = 1;
            }
            if (!checkBox2.Checked)
            {
                checkBox3.Enabled = true;
            }
            if (!checkBox3.Checked)
            {
                checkBox2.Enabled = true;
            }
        }
        private void Close_Button(object sender, EventArgs e)// 닫기 버튼
        {
            this.Close();
        }
    }
}
