using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class UpdateSubDept : Form
    {
        private List<DepartmentDto> MainDeptInfo => DepartmentRepository.DeptRepo.GetLinqDeptListInfo();//상위 부서 리스트
        private DepartmentDto SelectMainDeptCode => deptCodeComboBox.SelectedItem as DepartmentDto;//콤보박스에서 선택된 상위 부서
        private readonly DepartmentDto updateDeptDto;//수정할 하위 부서 정보
        public UpdateSubDept(DepartmentDto deptDto)
        {
            InitializeComponent();
            Event();
            Design();

            updateDeptDto = deptDto;
            
        }
        private void Event()
        {
            this.Load += UpdateSubDept_Load;
            updateBtn.Click += Update_SubEmp;//수정 버튼
            deptCodeComboBox.SelectedIndexChanged += Change_MainDeptCode;//상위 부서 코드 변경시
            cancelBtn.Click += CancelBtn_Click;//닫기 버튼
        }
        private void Design()
        {
            updateBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            cancelBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
            new[] { mainDeptCodeLabel, mainDeptNameLabel, subDeptCodeLabel, subDeptNameLablel }
                    .ToList().ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));
        }

        private void Change_MainDeptCode(object sender, EventArgs e)
        {
            deptNameBox.Text = SelectMainDeptCode.DepartmentName;
        }

        private void UpdateSubDept_Load(object sender, EventArgs e)
        {
            deptCodeComboBox.Text = updateDeptDto.DepartmentCode;
            deptNameBox.Text = updateDeptDto.DepartmentName;
            subDeptCodeBox.Text = updateDeptDto.SubDeptCode;
            subDeptNameBox.Text = updateDeptDto.SubDeptName;
            subMemoBox.Text = updateDeptDto?.Memo;
            deptNameBox.Text = updateDeptDto.DepartmentName;

            deptCodeComboBox.Properties.Items.Clear();
            deptCodeComboBox.Properties.Items.AddRange(MainDeptInfo);
        }

        private void Update_SubEmp(object sender, EventArgs e)
        {   
            
            if (string.IsNullOrEmpty(subDeptCodeBox.Text))
            {
                MessageBox.Show("하위부서 코드를 선택해주세요.");
                return;
            }else if(string.IsNullOrEmpty(subDeptNameBox.Text))
            {
                MessageBox.Show("하위부서명을 입력해주세요.");
                return;
            }
            //System.Diagnostics.Debug.WriteLine($"상위 부서 아이디 : {SelectMainDeptCode.DepartmentId}, 하위 부서 아이디 : {updateDeptDto.SubDeptId}, 하위 부서 코드 : {subDeptCodeBox.Text}, 하위 부서명 : {subDeptNameBox.Text}, 메모 : {subMemoBox.Text}");
            //return;
            int deptId;
            if (SelectMainDeptCode != null) deptId = SelectMainDeptCode.DepartmentId;
            else deptId = updateDeptDto.DepartmentId;
            var updateSubDeptInfo = new SubDepartment
            {
                departmentId = deptId,
                subDeptId = updateDeptDto.SubDeptId,
                subDeptCode = subDeptCodeBox.Text,
                subDeptName = subDeptNameBox.Text,
                memo = subMemoBox.Text,
            };

            var updateSubDept = DepartmentRepository.DeptRepo.UpdateSubDeptLinq(updateSubDeptInfo);
            var updateDeptIdEmp = DepartmentRepository.DeptRepo.UpdateDeptIdEmployee(updateDeptDto.DepartmentId,updateDeptDto.SubDeptId,deptId);
            if(updateSubDept == 1 && updateDeptIdEmp == 1)
            {
                MessageBox.Show("하위 부서 수정이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("하위 부서 수정에 실패하였습니다.");
                return;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
