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
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class DelEmployee : Form
    {
        private int employId;
        EmployeeRepository empRepo = new EmployeeRepository();
        
        public DelEmployee(int empId)
        {
            InitializeComponent();
            employId = empId;

            this.Load += DelEmployee_Load_1;
            delBtn.Click += Del_Button;//삭제 버튼
            cancelBtn.Click += Cancel_Button;//취소 버튼
        }

        private void DelEmployee_Load_1(object sender, EventArgs e)
        {
           
            var delInfo = empRepo.empDelInfo(employId);
            if (delInfo != null)
            {
                
                empCodeLabel.Text = "사원코드 : " + delInfo.employeeCode;
                empNameLabel.Text = "사원명 : " + delInfo.employeeName;
            }
            else
            {
                MessageBox.Show("사원 정보를 찾을 수 없습니다.");
                this.Close();
            }
        }

        private void Del_Button(object sender, EventArgs e)
        {
            var delResult = empRepo.DelEmp(employId);
            if(delResult == 1)
            {
                MessageBox.Show("삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }
        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 취소 버튼 클릭 시 폼 닫기

        }

        
    }
}
