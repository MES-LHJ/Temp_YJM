using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;

namespace WindowsFormsApp1
{
    public partial class InsertDepartment : Form
    {
        public InsertDepartment()
        {
            InitializeComponent();
            Click_Event();
        }

        private void Click_Event()
        {
            insertBtn.Click += Insert_Button;//부서 추가 버튼
            cancelBtn.Click += Cancel_Button;//닫기 버튼
        }

        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            string deptCode = deptCodeBox.Text;
            var checkDeptCode = DepartmentRepository.deptRepo.InsertDeptCodeCheck(deptCode);

            if (string.IsNullOrWhiteSpace(deptCodeBox.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(deptNameBox.Text))
            {
                MessageBox.Show("부서명을 입력해주세요.");
                return;
            }

            if (checkDeptCode == 1)
            {
                MessageBox.Show("중복되는 부서코드가 존재합니다.");
                return;
            }

            DepartmentDto deptDto = new DepartmentDto
            {
                departmentCode = deptCodeBox.Text,
                departmentName = deptNameBox.Text,
                memo = memoBox.Text
            };
            DepartmentRepository.deptRepo.InsertDepartment(deptDto);
            MessageBox.Show("부서 등록이 완료되었습니다.");
            this.DialogResult = DialogResult.OK;


        }
        private void Cancel_Button(object sender, EventArgs e) //취소 버튼
        {
            this.Close(); // 폼 닫기
        }
    }
}
