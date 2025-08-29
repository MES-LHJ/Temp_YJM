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
using WindowsFormsApp1.department.Model;
using WindowsFormsApp1.employee;
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class EmployeeList : Form
    {
        private int empId;
        private string myLoginId;
        private int idx;
       

        public EmployeeList()
        {
            InitializeComponent();
            Click_Event();
            Design();
        }

        private void Click_Event()//버튼 클릭 이벤트
        {
            deptListBtn.Click += Department_Button; //부서 리스트 버튼
            empListBtn.Click += Search_Button; //조회 버튼
            empAddBtn.Click += Add_Button; //사원 추가 버튼
            empUpdateBtn.Click += Update_Button;//사원 정보 수정 버튼
            empDelBtn.Click += Delete_Button;//사원 삭제 버튼
            closeBtn.Click += Close_Btn;//닫기 버튼
            loginInfoBtn.Click += UpdateLoginInfo_Page;//id.passwd 변경 페이지이동
        }

        private void Design()
        {
            empListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            empListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            empListView.ReadOnly = true;

            deptListBtn.Alignment = ToolStripItemAlignment.Right;
            empListBtn.Alignment = ToolStripItemAlignment.Right;
            empAddBtn.Alignment = ToolStripItemAlignment.Right;
            empUpdateBtn.Alignment = ToolStripItemAlignment.Right;
            loginInfoBtn.Alignment = ToolStripItemAlignment.Right;
            empDelBtn.Alignment = ToolStripItemAlignment.Right;
            excelBtn.Alignment = ToolStripItemAlignment.Right;
            closeBtn.Alignment = ToolStripItemAlignment.Right;

            empListToolStrip.Items.Insert(1, closeBtn);
            empListToolStrip.Items.Insert(2, excelBtn);
            empListToolStrip.Items.Insert(3, empDelBtn);
            empListToolStrip.Items.Insert(4, loginInfoBtn);
            empListToolStrip.Items.Insert(5, empUpdateBtn);
            empListToolStrip.Items.Insert(6, empAddBtn);
            empListToolStrip.Items.Insert(7, empListBtn);
            empListToolStrip.Items.Insert(8, deptListBtn);

        }

        private void EmpListRefresh()//사원 리스트 새로고침
        {
            var empInfo = EmployeeRepository.empRepo.GetEmpList();
            empListView.AutoGenerateColumns = false;
            empListView.DataSource = empInfo;
            empListView.Columns["passwd"].DataPropertyName = "passwdMask";
        }

        private void Cell_Select()//셀 선택
        {
            var emp = empListView.SelectedRows[0].DataBoundItem as EmployeeDto;
            if(emp != null)
            {
                empId = emp.employeeId;
                myLoginId = emp.loginId;
                idx = empListView.CurrentRow.Index;
                
            }
           
        }
        private void Search_Button(object sender, EventArgs e) //조회 버튼 클릭
        {
            
            EmpListRefresh();
        }
        private void Add_Button(object sender, EventArgs e) //추가 버튼 클릭
        {
            InsertEmployee insertEmployee = new InsertEmployee();
            if (insertEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
                empListView.CurrentCell = empListView.Rows[empListView.RowCount - 1].Cells[0];
            }
        }

        private void Update_Button(object sender, EventArgs e) //수정 버튼 클릭
        {
            Cell_Select();
            if (empId == 0)
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }
            UpdateEmployee updateEmployee = new UpdateEmployee(empId);
            if (updateEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
                empListView.CurrentCell= empListView.Rows[idx].Cells[0];
            }
        }

        private void UpdateLoginInfo_Page(object sender, EventArgs e)//id.passwd 변경 버튼 클릭
        {
            Cell_Select();
            if(empId == 0)
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }
            UpdateLoginInfo updateLoginInfo = new UpdateLoginInfo(empId, myLoginId);
            if (updateLoginInfo.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
            }
        }

        private void Delete_Button(object sender, EventArgs e) //삭제 버튼 클릭
        {
            Cell_Select();
            if (empId == 0)
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }
           
            DelEmployee delEmployee = new DelEmployee(empId);
            if (delEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
            }

        }
        private void Department_Button(object sender, EventArgs e) //부서 버튼
        {
            DepartmentList departmentList = new DepartmentList();
            if(departmentList.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
            }
        }
        private void Close_Btn(object sender, EventArgs e)//닫기 버튼 클릭
        {
            this.Close();
        }
    }
}
