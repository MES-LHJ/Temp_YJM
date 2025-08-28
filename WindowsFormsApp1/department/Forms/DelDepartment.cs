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
            var deptInfo = DepartmentRepository.deptRepo.DepartmentInfo(departId);
            if (deptInfo != null)
            {
                string deptCode = deptInfo.departmentCode;
                deptCodeLabel.Text = "부서코드 : " + deptCode;
                deptNameLabel.Text = "부서명 : " + deptInfo.departmentName;
            }
        }

        private void Del_Btn(object sender, EventArgs e)//부서 삭제 버튼
        { 
            var checkEmp = DepartmentRepository.deptRepo.CheckEmployee(departId);
            

            if(checkEmp ==1)
            {
                MessageBox.Show("부서에 소속된 사원이 존재합니다.");
                this.DialogResult = DialogResult.OK;
                return;
            }
            var delDept = DepartmentRepository.deptRepo.DelDepartment(departId);
            if (delDept == 1)
            {
                MessageBox.Show("삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("삭제에 실패하였습니다.");
            }

        }
        private void Cancel_Btn(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
