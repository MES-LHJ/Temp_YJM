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
    public partial class AddEmployee : Form
    {
        private int gender = 0;
        private string deptId;
        public AddEmployee()
        {
            InitializeComponent();
            deptIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            deptNameBox.ReadOnly = true;
            deptIdComboBox.Items.Clear(); // 콤보박스 초기화
           
            string sql = "SELECT departmentId from department ORDER BY departmentNo";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    deptNameBox.Clear();
                    deptId = reader["departmentId"].ToString();// departmentId 컬럼의 값을 가져옴
                    deptIdComboBox.Items.Add(deptId);
                    //textBox1.Text = reader["departmentName"].ToString();
                }
            }
            
        }
        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {
            
            string sql = "SELECT departmentName FROM department WHERE departmentId=@departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptIdComboBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptNameBox.Text = reader["departmentName"].ToString();
                }
            }
        }
        private void Insert_Button(object sender, EventArgs e)
        {
            //string input = textBox1.Text;
            //Console.WriteLine(inputText);
            //string num = (string)comboBox1.SelectedItem;//부서코드 콤보박스
                                                        //string departmentId = Convert.ToInt32(num); // 선택된 부서코드를 정수로 변환
                                                        //Console.WriteLine(deepartmentId);

            deptId = deptIdComboBox.Text;

            string sql = "INSERT INTO employee (departmentId, employeeId, employeeName, loginId, passwd, employeeRank, employeeType, phone, email, messId, memo, gender) " +
                         "VALUES (@departmentId, @employeeId, @employeeName, @loginId, @passwd, @employeeRank, @employeeType, @phone, @email, @messId, @memo,'"+gender+"')";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptId);
                cmd.Parameters.AddWithValue("@employeeId", empNameBox.Text);
                cmd.Parameters.AddWithValue("@employeeName", textBox3.Text);
                cmd.Parameters.AddWithValue("@loginId", loginIdBox.Text);
                cmd.Parameters.AddWithValue("@passwd", passwdBox.Text);
                cmd.Parameters.AddWithValue("@employeeRank", empRankBox.Text);
                cmd.Parameters.AddWithValue("@employeeType", empTypeBox.Text);
                cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                cmd.Parameters.AddWithValue("@email", emailBox.Text);
                cmd.Parameters.AddWithValue("@messId", messageIdBox.Text);
                cmd.Parameters.AddWithValue("@memo", memoBox.Text);
                string email = emailBox.Text;
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//이메일 형식(@와 공백 제외 + @ + . +도메인)

                try
                    {
                       
                    if (deptIdComboBox.Text.Equals(""))
                    {
                        MessageBox.Show("부서코드를 입력해주세요.");
                        return;
                    }else if (string.IsNullOrWhiteSpace(empNameBox.Text))
                    {
                        MessageBox.Show("사원코드를 입력해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        MessageBox.Show("사원명을 입력해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(loginIdBox.Text))
                    {
                        MessageBox.Show("로그인 아이디를 입력해주세요.");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(passwdBox.Text))
                    {
                        MessageBox.Show("비밀번호를 입력해주세요.");
                        return;
                    }else if(Regex.IsMatch(passwdBox.Text, "[^a-zA-Z0-9]"))//영문자나 숫자가 아닌
                    {
                        MessageBox.Show("비밀번호에 특수문자가 포함 되어있습니다.");
                        return;
                    }
                    else if (passwdBox.Text.Length < 8)
                    {
                        MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                        return;
                    }
                    else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, pattern))
                    {
                        MessageBox.Show("이메일 형식이 틀립니다.");
                        return;
                    }

                    cmd.ExecuteNonQuery(); // 쿼리 실행
                    MessageBox.Show("사원 정보가 성공적으로 추가되었습니다.");
                    this.Close();
                        
                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("오류 발생: " + ex.Message);
                }
                
            }
        }
        private void Check_Box(object sender, EventArgs e)
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Enabled = false;
                gender = 2;
            }
            if (menCheckBox.Checked)
            {
                womenCheckBox.Enabled = false;
                gender = 1;
            }
            if (!menCheckBox.Checked)
            {
                womenCheckBox.Enabled = true;
            }
            if (!womenCheckBox.Checked)
            {
                menCheckBox.Enabled = true;
            }
        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
