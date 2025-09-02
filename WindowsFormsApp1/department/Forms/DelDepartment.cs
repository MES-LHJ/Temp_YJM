using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using WindowsFormsApp1.department.Models;

namespace WindowsFormsApp1
{
    public partial class DelDepartment : Form
    {
        private readonly int departId;
        public DelDepartment(int deptId)
        {
            departId = deptId;

            InitializeComponent();
            Click_Event();
        }
        private void Click_Event()
        {
            delBtn.Click += Del_Btn;//삭제 버튼
            cancelBtn.Click += Cancel_Btn;//취소 버튼
        }

        private void DelDepartment_Load(object sender, EventArgs e)
        {
            //var deptInfo = DepartmentRepository.DeptRepo.DepartmentInfo(departId);
         

            using (var context = new LinqContext())
            {
                var deptInfo = context.Department
                                        .FirstOrDefault(d => d.departmentId == departId);

                if (deptInfo != null)
                {
                    deptCodeLabel.Text = "부서코드 : " + deptInfo.departmentCode;
                    deptNameLabel.Text = "부서명 : " + deptInfo.departmentName;
                }

            }

        }

        private void Del_Btn(object sender, EventArgs e)//부서 삭제 버튼
        {
           // var checkEmp = DepartmentRepository.DeptRepo.CheckEmployee(departId);
     
            using (var context = new LinqContext())
            {
                var checkEmpId = context.Employee
                                            .Any(a => a.departmentId == departId);
                if (checkEmpId == true)
                {
                    MessageBox.Show("부서에 소속된 사원이 존재합니다.");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                //var delDept = DepartmentRepository.DeptRepo.DelDepartment(departId);
                
                var delDept = context.Department
                                        .FirstOrDefault(d => d.departmentId == departId);
                if (delDept != null)
                {
                    context.Department.Remove(delDept);
                    context.SaveChanges();
                    MessageBox.Show("삭제에 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("삭제에 실패하였습니다");
                    return;
                }

            }
        }
        private void Cancel_Btn(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
