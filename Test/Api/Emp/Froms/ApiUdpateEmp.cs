using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Test.Api.Dept.Dtos;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Emp.Froms
{
    public partial class ApiUdpateEmp : Form
    {
        public List<DeptListDto> deptList;//부서 리스트
        public EmpListDto empDto;//수정할 사원 정보
        
        private readonly ColorInfo colorInfo = new ColorInfo();
        public DeptListDto SelectDeptCode => deptCodeCombo.SelectedItem as DeptListDto;//콤보박스에서 선택된 부서
        public ApiUdpateEmp(EmpListDto employeeDto)
        {
            InitializeComponent();
            empDto = employeeDto;
            Event();
            Design();
        }

        private void Event()
        {
            this.Load += ApiUdpateEmp_Load;
            deptCodeCombo.SelectedIndexChanged += Change_DeptCode;//부서코드 변경시 부서명 변경
            updateBtn.Click += UpdateBtn_Click;//수정버튼 클릭
            closeBtn.Click += CloseBtn_Click;
        }

        private void Design()
        {
            var labelChange = new List<LayoutControlItem> { deptCodeLabel, empCodeLabel, empNameLabel };
            colorInfo.ChangeValiLabel(labelChange);

            colorInfo.ChangeSaveBtnColor(updateBtn);
            colorInfo.ChangeCloseBtnColor(closeBtn);
        }

        private void Change_DeptCode(object sender, EventArgs e)
        {
            if (deptCodeCombo.EditValue != null)
            {
                deptNameBox.Text = SelectDeptCode.Name;//부서명 변경
            }
        }

        private async void ApiUdpateEmp_Load(object sender, EventArgs e)
        {
            deptCodeCombo.Text = empDto.DepartmentCode;
            deptNameBox.Text = empDto.DepartmentName;
            empCodeBox.Text = empDto.Code;
            empNameBox.Text = empDto.Name;
            empRankBox.Text = empDto.Position;
            empTypeBox.Text = empDto.ContractType;
            phoneBox.Text = empDto.PhoneNumber;
            emailBox.Text = empDto.Email;
            memoBox.Text = empDto.Memo;
            messIdBox.Text = empDto.MessengerId;

            deptList = await DeptRepository.DepartmentRepo.GetDepartmentCode();//부서 리스트 불러오기
            deptCodeCombo.Properties.Items.AddRange(deptList);
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            var updateEmpCodeCheck = await EmpRepository.EmpRepo.CheckUpdateEmpCode(empCodeBox.Text, empDto.Code);//(수정한 코드,수정할 코드)
            if(updateEmpCodeCheck == true)
            {
                MessageBox.Show("중복되는 사원코드가 존재합니다.");
                return;
            }

            var req = new EmpListDto//수정할 사원 정보
            {
                Code = empCodeBox.Text,
                Name = empNameBox.Text,
                Position = empRankBox.Text,
                ContractType = empTypeBox.Text,
                PhoneNumber = phoneBox.Text,
                Email = emailBox.Text,
                MessengerId = messIdBox.Text,
                Memo = memoBox.Text,
                DepartmentId = SelectDeptCode == null ? empDto.DepartmentId : SelectDeptCode.Id,
            };

            var updateResult = await EmpRepository.EmpRepo.UpdateEmpApi(empDto.Id, req);//사원 정보 수정
            if (updateResult == true)
            {
                MessageBox.Show("수정 완료.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("수정 실패");
                this.Close();
            }

        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
