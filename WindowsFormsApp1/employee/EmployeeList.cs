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
    public partial class EmployeeList : Form
    {
        public string emplId; // 사원코드 전역변수로 선언

        public EmployeeList()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Search_Button(object sender, EventArgs e) //조회 버튼 클릭
        {
            dataGridView1.Rows.Clear(); //기존 데이터 삭제
            //조회 페이지
            string sql = "SELECT a.departmentId, b.departmentName, a.employeeName, a.employeeId, a.loginId, a.passwd, a.employeeRank," +
                "a.employeeType, a.phone, a.email, a.messId, a.memo FROM employee a JOIN department b on a.departmentId = b.departmentId " +
                "Order by employeeNo";
            
            using (SqlConnection conn = new SqlConnection(Server.connStr))// SQL Server에 연결
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);// 쿼리를 실행할 준비

                SqlDataReader reader = cmd.ExecuteReader();//SqlDataReader를 사용하여 데이터를 읽음
                while (reader.Read())
                {
                    int rowIndex = dataGridView1.Rows.Add();//새로운 행 추가
                    DataGridViewRow newRow = dataGridView1.Rows[rowIndex];//새로운 행을 가져옴

                    string pass = (string)reader["passwd"];
                    int passLength = pass.Length;
                    string passW = "";

                    for (int i = 0; i < passLength; i++) passW += "*";

                    newRow.Cells["departmentId"].Value = reader["departmentId"];
                    newRow.Cells["departmentName"].Value = reader["departmentName"];
                    newRow.Cells["employeeId"].Value = reader["employeeId"];
                    newRow.Cells["employeeName"].Value = reader["employeeName"];
                    newRow.Cells["loginId"].Value = reader["loginId"];
                    newRow.Cells["passwd"].Value = passW;//reader["passwd"];
                    newRow.Cells["employeeRank"].Value = reader["employeeRank"];
                    newRow.Cells["employeeType"].Value = reader["employeeType"];
                    newRow.Cells["phone"].Value = reader["phone"];
                    newRow.Cells["email"].Value = reader["email"];
                    newRow.Cells["messId"].Value = reader["messId"];
                    newRow.Cells["memo"].Value = reader["memo"];

                }
            };
        }

        private void Add_Button(object sender, EventArgs e) //추가 버튼 클릭
        {
            AddEmployee form2 = new AddEmployee();
            form2.ShowDialog();
        }
        private void Alter_Button(object sender, EventArgs e) //수정 버튼 클릭
        {
            UpdateEmployee form3 = new UpdateEmployee(emplId);
            form3.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//셀 클릭(사원코드 보내려고)
        {
            int num = e.RowIndex; // 클릭한 행의 인덱스
            emplId = dataGridView1.Rows[num].Cells["employeeId"].Value.ToString(); // 사원코드 가져오기

        }
        private void Login_Page(object sender, EventArgs e)
        {
            LoginEmployee form4=new LoginEmployee();
            form4.ShowDialog();
        }

        private void Delete_Button(object sender, EventArgs e) //삭제 버튼 클릭
        {
            DelEmployee form5 = new DelEmployee(emplId);
            form5.ShowDialog();
        }
        private void Department_Button(object sender, EventArgs e) //부서 버튼
        {
            DepartmentList form6 = new DepartmentList();
            form6.ShowDialog();
            
        }
        private void Close_Btn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
