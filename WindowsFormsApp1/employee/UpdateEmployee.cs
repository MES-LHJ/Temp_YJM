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
        private int employeeId; // 수정할 사원 ID를 저장할 변수
        private int gender;
        public UpdateEmployee(int empId)
        {
            
            InitializeComponent();
           
            deptIdBox.Visible = false;
            employeeId = empId;
         
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;
            updateBtn.Click += Complete_Button; // 수정 완료 버튼 클릭 이벤트 핸들러 등록
            closeBtn.Click += Close_Button; // 닫기 버튼 클릭 이벤트 핸들러 등록
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            deptNameBox.ReadOnly = true;
           // Console.WriteLine(employeeId);
            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화

            string sql = "SELECT b.departmentCode, b.departmentName, a.employeeName, a.employeeCode, a.loginId, a.passwd, a.employeeRank," +
                "a.employeeType, a.phone, a.email, a.messId, a.memo, a.gender, a.departmentId FROM employee a JOIN department b on a.departmentId = b.departmentId " +
                "WHERE employeeId='" + employeeId + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    deptCodeComboBox.Text = reader["departmentCode"].ToString();
                    deptNameBox.Text = reader["departmentName"].ToString();
                    empCodeBox.Text = reader["employeeCode"].ToString();
                    empNameBox.Text = reader["employeeName"].ToString();
                    empRankBox.Text = reader["employeeRank"].ToString();
                    empTypeBox.Text = reader["employeeType"].ToString();
                    phoneBox.Text = reader["phone"].ToString();
                    emailBox.Text = reader["email"].ToString();
                    messageBox.Text = reader["messId"].ToString();
                    memoBox.Text = reader["memo"].ToString();
                    deptIdBox.Text = reader["departmentId"].ToString();

                    gender = Convert.ToInt32(reader["gender"]);//string을 int로
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
            }
            ;
            string conboBoxSql = "SELECT departmentCode from department ORDER BY departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(conboBoxSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string departmentCode = reader["departmentCode"].ToString();
                    deptCodeComboBox.Items.Add(departmentCode);


                }
            }

        }
        private void DepName_Change(object sender, EventArgs e)
        {
           
            string sql = "SELECT departmentName,departmentId FROM department WHERE departmentCode=@departmentCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", deptCodeComboBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptNameBox.Text = reader["departmentName"].ToString();
                    deptIdBox.Text = reader["departmentId"].ToString();
                }
            }
        }
        private void Complete_Button(object sender, EventArgs e) //수정 완료 버튼
        {
            Boolean check = true;

            string empCodeCheckSql = "SELECT employeeCode FROM employee WHERE employeeCode = @empCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))//사원코드 중복체크
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(empCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@empCode", empCodeBox.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("중복하는 사원코드가 존재합니다.");
                    check = false;
                    return;
                }
            }

            if (check)
            {
                string sql = "UPDATE employee SET departmentId = @departmentId, employeeCode=@employeeCode, employeeName = @employeeName, " +
                             "employeeRank = @employeeRank, employeeType = @employeeType, " +
                             "phone = @phone, email = @email, messId = @messId, memo = @memo,gender='" + gender + "'WHERE employeeId ='" + employeeId + "'";

                using (SqlConnection conn = new SqlConnection(Server.connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@departmentId", deptIdBox.Text);
                    cmd.Parameters.AddWithValue("@employeeCode", empCodeBox.Text);
                    cmd.Parameters.AddWithValue("@employeeName", empNameBox.Text);
                    cmd.Parameters.AddWithValue("@employeeRank", empRankBox.Text);
                    cmd.Parameters.AddWithValue("@employeeType", empTypeBox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@messId", messageBox.Text);
                    cmd.Parameters.AddWithValue("@memo", memoBox.Text);

                    string email = emailBox.Text;
                    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//이메일 패턴 검사

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

                        MessageBox.Show("수정이 완료되었습니다.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("수정에 실패하였습니다. " + ex.Message);
                    }

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
