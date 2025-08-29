using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class DelEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();

        public DelEmployee(int empId)
        {
            employee.employeeId = empId;

            InitializeComponent();
            Click_Event();

            this.Load += DelEmployee_Load_1;
        }
        private void Click_Event()
        {
            delBtn.Click += Del_Button;//삭제 버튼
            cancelBtn.Click += Cancel_Button;//취소 버튼
        }

        private void DelEmployee_Load_1(object sender, EventArgs e)
        {
            var delInfo = EmployeeRepository.empRepo.empDelInfo(employee.employeeId);
            if (delInfo != null)
            {

                empCodeLabel.Text = "사원코드 : " + delInfo.employeeCode;
                empNameLabel.Text = "사원명 : " + delInfo.employeeName;
                employee.imgId = delInfo.imgId;
                employee.imgName = delInfo.imgName;

            }
            else
            {
                MessageBox.Show("사원 정보를 찾을 수 없습니다.");
                this.Close();
            }
        }

        private void Del_Button(object sender, EventArgs e)
        {
            var delResult = EmployeeRepository.empRepo.DelEmp(employee.employeeId, employee.imgId);
            if (delResult == 1)
            {
                if (!string.IsNullOrEmpty(employee.imgId.ToString()))
                {
                    Directory.Delete(@"C:\NAS\" + employee.imgId, true);

                    //File.Delete(@"C:\NAS\" + employee.employeeId + @"\" + employee.imgName);
                }
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
