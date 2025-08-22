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
using WindowsFormsApp1.employee;

namespace WindowsFormsApp1
{
    public partial class EmployeeList : Form
    {
        public int empId; // 사원ID 전역변수로 선언

        public EmployeeList()
        {
            InitializeComponent();

            empIdBox.Visible = false;//employeeID
       
            empListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            deptListBtn.Click += Department_Button; //부서 리스트 버튼
            empListBtn.Click += Search_Button; //조회 버튼
            empAddBtn.Click += Add_Button; //사원 추가 버튼
            empUpdateBtn.Click += Update_Button;//사원 정보 수정 버튼
            empDelBtn.Click += Delete_Button;//사원 삭제 버튼
            closeBtn.Click += Close_Btn;//닫기 버튼
            empListView.CellClick += Cell_Click;//셀 선택(employeeId 가져오기위해)
            loginInfoBtn.Click += UpdateLoginInfo_Page;//id.passwd 변경 페이지이동
        }

        private void Search_Button(object sender, EventArgs e) //조회 버튼 클릭
        {
            empListView.Rows.Clear(); //기존 데이터 삭제
            //조회 페이지
            string sql = "SELECT b.departmentCode, b.departmentName, a.employeeCode, a.employeeName, a.loginId, a.passwd, a.employeeRank," +
                "a.employeeType, a.phone, a.email, a.messId, a.memo, a.employeeId FROM employee a JOIN department b on a.departmentId = b.departmentId " +
                "Order by employeeId";
            
            using (SqlConnection conn = new SqlConnection(Server.connStr))// SQL Server에 연결
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);// 쿼리를 실행할 준비

                SqlDataReader reader = cmd.ExecuteReader();//SqlDataReader를 사용하여 데이터를 읽음
                while (reader.Read())
                {
                    int rowIndex = empListView.Rows.Add();//새로운 행 추가
                    DataGridViewRow newRow = empListView.Rows[rowIndex];//새로운 행을 가져옴

                    string pass = (string)reader["passwd"];
                    int passLength = pass.Length;
                    string passW = "";

                    for (int i = 0; i < passLength; i++) passW += "*";

                    newRow.Cells["departmentCode"].Value = reader["departmentCode"];
                    newRow.Cells["departmentName"].Value = reader["departmentName"];
                    newRow.Cells["employeeCode"].Value = reader["employeeCode"];
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
            InsertEmployee form2 = new InsertEmployee();
            form2.ShowDialog();
        }
        private void Update_Button(object sender, EventArgs e) //수정 버튼 클릭
        {
            if (empId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(empId);
                updateEmployee.ShowDialog();
            }
        }

        private void Cell_Click(object sender, DataGridViewCellEventArgs e)//셀 클릭(사원코드 보내려고)
        {
            int num = e.RowIndex; // 클릭한 행의 인덱스
            string emplCode = empListView.Rows[num].Cells["employeeCode"].Value.ToString(); // 사원코드 가져오기
            string sql = "SELECT employeeId FROM employee WHERE employeeCode='" + emplCode + "'";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    empIdBox.Text = reader["employeeId"].ToString();
                    empId = Convert.ToInt32(empIdBox.Text);
                }
            }
        }
        private void UpdateLoginInfo_Page(object sender, EventArgs e)
        {   
            if(empId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                UpdateLoginInfo updateLoginInfo = new UpdateLoginInfo(empId);
                updateLoginInfo.ShowDialog();
            }
        }

        private void Delete_Button(object sender, EventArgs e) //삭제 버튼 클릭
        {
            if (empId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                DelEmployee delEmployee = new DelEmployee(empId);
                delEmployee.ShowDialog();
            }
            
        }
        private void Department_Button(object sender, EventArgs e) //부서 버튼
        {
            DepartmentList departmentList = new DepartmentList();
            departmentList.ShowDialog();
            
        }
        private void Close_Btn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void empListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
