using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Test.Api.Dept.Dtos;
using Test.Utility;

namespace Test.Api.Dept.Forms
{
    public partial class ApiUpdateDept : Form
    {
        private readonly ColorInfo colorInfo = new ColorInfo();
        private readonly DeptListDto deptListDto;//수정할 부서 정보

        public ApiUpdateDept(DeptListDto departmentListDto)
        {
            InitializeComponent();

            deptListDto = departmentListDto;

            Event();
            Design();
        }
        private void Event()
        {
            this.Load += ApiUpdateDept_Load;
            updateBtn.Click += InsertBtn_Click;//수정버튼 클릭
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
        }

        private void Design()
        {
            colorInfo.ChangeSaveBtnColor(updateBtn);
            colorInfo.ChangeCloseBtnColor(closeBtn);
            var labelChange = new List<LayoutControlItem> { deptCodeLabel, deptNameLabel };
            colorInfo.ChangeValiLabel(labelChange);
        }
        private void ApiUpdateDept_Load(object sender, EventArgs e)
        {
            deptCodeBox.Text = deptListDto.Code;
            deptNameBox.Text = deptListDto.Name;
        }

        private async void InsertBtn_Click(object sender, EventArgs e)
        {
            var updateDeptCodeCheck = await DeptRepository.DepartmentRepo.CheckUpdateDeptCode(deptCodeBox.Text, deptListDto.Code);//부서코드 중복체크
            if (updateDeptCodeCheck == true)
            {
                MessageBox.Show("중복되는 부서코드가 존재합니다.");
                return;
            }

            var req = new DeptDto//수정할 부서 정보
            {
                Code = deptCodeBox.Text,
                Name = deptNameBox.Text,
            };

            var updateDept = await DeptRepository.DepartmentRepo.UpdateDeptCheck(deptListDto.Id, req);//부서 수정
            if (updateDept == true)
            {
                MessageBox.Show("부서 수정에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("부서 수정에 실패하였습니다.");
                this.Close();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
