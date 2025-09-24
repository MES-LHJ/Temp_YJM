using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Test.Api.Dept.Dtos;
using Test.Utility;

namespace Test.Api.Dept.Forms
{
    public partial class ApiInsertDept : Form
    {
        private readonly ColorInfo colorInfo = new ColorInfo();
        public long deptId;
        public ApiInsertDept()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            insertBtn.Click += InsertBtn_Click;//추가버튼 클릭
            cancelBtn.Click += CancelBtn_Click;//취소버튼 클릭
        }


        private void Design()
        {
            colorInfo.ChangeSaveBtnColor(insertBtn);
            colorInfo.ChangeCancelBtnColor(cancelBtn);

            var labelChange = new List<LayoutControlItem> { deptCodeLabel, deptNameLabel };
            colorInfo.ChangeValiLabel(labelChange);
        }

        private async void InsertBtn_Click(object sender, EventArgs e)
        {

            var deptCodeCheck = await DeptRepository.DepartmentRepo.CheckInsertDeptCode(deptCodeBox.Text);//부서코드 중복체크
            if (deptCodeCheck == true)
            {
                MessageBox.Show("중복되는 부서코드가 존재합니다.");
                return;
            }

            var req = new DeptDto//추가할 부서 정보
            {
                FactoryId = 1,
                Code = deptCodeBox.Text,
                Name = deptNameBox.Text,
            };

            var deptInsert = await DeptRepository.DepartmentRepo.InsertDeptCheck(req);//부서 추가
            if (deptInsert != 0)
            {
                MessageBox.Show("부서 추가에 성공하였습니다.");
                deptId = deptInsert;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("부서 추가에 실패하였습니다.");
                this.Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
