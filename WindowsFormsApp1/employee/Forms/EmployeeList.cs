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
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class EmployeeList : Form
    {
        public int empId; // 사원ID 전역변수로 선언
        EmployeeRepository empRepo = new EmployeeRepository();
        private string myLoginId;

        public EmployeeList()
        {
            InitializeComponent();

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

            var empInfo = empRepo.GetEmpList();
            empListView.AutoGenerateColumns = false;
            empListView.DataSource = empInfo;

            empListView.Columns["departmentCode"].DataPropertyName = "departmentCode";
            empListView.Columns["departmentName"].DataPropertyName = "departmentName";
            empListView.Columns["employeeCode"].DataPropertyName = "employeeCode";
            empListView.Columns["employeeName"].DataPropertyName = "employeeName";
            empListView.Columns["loginId"].DataPropertyName = "loginId";
            empListView.Columns["passwd"].DataPropertyName = "passwd";
            empListView.Columns["employeeRank"].DataPropertyName = "employeeRank";
            empListView.Columns["employeeType"].DataPropertyName = "employeeType";
            empListView.Columns["phone"].DataPropertyName = "phone";
            empListView.Columns["email"].DataPropertyName = "email";
            empListView.Columns["messId"].DataPropertyName = "messId";
            empListView.Columns["memo"].DataPropertyName = "memo";

        }
        private void Add_Button(object sender, EventArgs e) //추가 버튼 클릭
        {
            InsertEmployee insertEmployee = new InsertEmployee();
            if (insertEmployee.ShowDialog() == DialogResult.OK)
            {
                this.Search_Button(sender, e); // 사원 추가 후 목록 갱신
            }
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
                if (updateEmployee.ShowDialog() == DialogResult.OK)
                {
                    this.Search_Button(sender, e);
                }
            }
        }

        private void Cell_Click(object sender, DataGridViewCellEventArgs e)//셀 클릭(사원코드 보내려고)
        {
            int num = e.RowIndex; // 클릭한 행의 인덱스
            string emplCode = empListView.Rows[num].Cells["employeeCode"].Value.ToString(); // 사원코드 가져오기

            var getEmpId = empRepo.GetEmpCode(emplCode);

            //empIdBox.Text = getEmpId.employeeId.ToString();
            empId = Convert.ToInt32(getEmpId.employeeId.ToString());
            myLoginId = getEmpId.loginId;

        }
        private void UpdateLoginInfo_Page(object sender, EventArgs e)
        {
            if (empId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                UpdateLoginInfo updateLoginInfo = new UpdateLoginInfo(empId, myLoginId);
                if (updateLoginInfo.ShowDialog() == DialogResult.OK)
                {
                    this.Search_Button(sender, e);
                }
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
                if (delEmployee.ShowDialog() == DialogResult.OK)
                {
                    this.Search_Button(sender, e);
                }
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
    }
}
