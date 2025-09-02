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
using WindowsFormsApp1.department.Models;

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
            //var checkDeptCode = DepartmentRepository.DeptRepo.InsertDeptCodeCheck(deptCode);
            using (var context = new LinqContext())
            {
                var checkDeptCode = context.Department
                                            .Where(d => d.departmentCode == deptCode)
                                            .FirstOrDefault();

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

                if (checkDeptCode != null)
                {
                    MessageBox.Show("중복되는 부서코드가 존재합니다.");
                    return;
                }

                //DepartmentDto deptDto = new DepartmentDto
                //{
                //    DepartmentCode = deptCodeBox.Text,
                //    DepartmentName = deptNameBox.Text,
                //    Memo = memoBox.Text
                //};
                //DepartmentRepository.DeptRepo.InsertDepartment(deptDto);

                var deptInsertInfo = new Department
                {
                    departmentName = deptNameBox.Text,
                    departmentCode = deptCodeBox.Text,
                    memo = memoBox.Text
                };
                context.Department.Add(deptInsertInfo);
                context.SaveChanges();

                MessageBox.Show("부서 등록이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;

            }

        }
        private void Cancel_Button(object sender, EventArgs e) //취소 버튼
        {
            this.Close(); // 폼 닫기
        }
    }
}
