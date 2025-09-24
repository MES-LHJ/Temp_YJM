using System;
using System.Windows.Forms;
using Test.Api.Dept.Dtos;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Dept.Forms
{
    public partial class ApiDelDept : Form
    {
        public DeptListDto deptListDto;//삭제할 부서 정보
        private readonly ColorInfo colorInfo = new ColorInfo();

        public ApiDelDept(DeptListDto departmentDto)
        {
            InitializeComponent();

            deptListDto = departmentDto;

            Event();
            Design();
        }
        private void Event()
        {
            this.Load += ApiDelDept_Load;
            delDeptBtn.Click += DelDeptBtn_Click;//삭제버튼 클릭
            closeBtn.Click += CloseBtn_Click;//닫기버튼 클릭
        }

        private void Design()
        {
            colorInfo.ChangeCancelBtnColor(delDeptBtn);//삭제버튼 색 변경
            colorInfo.ChangeCloseBtnColor(closeBtn);//닫기버튼 색 변경
        }

        private void ApiDelDept_Load(object sender, EventArgs e)
        {
            delDeptLabel.Text = "부서 코드 : " + deptListDto.Code + "\n" +
                                "부서명 : " + deptListDto.Name + "\n\n" +
                                "삭제하시겠습니까?";
        }

        private async void DelDeptBtn_Click(object sender, EventArgs e)
        {
            var empInDeptCheck = await EmpRepository.EmpRepo.CheckDeptIdDelDept(deptListDto.Id);
            if (empInDeptCheck == true)
            {
                MessageBox.Show("부서에 소속된 사원이 존재합니다.");
                this.Close();
                return;
            }

            var delDept = await DeptRepository.DepartmentRepo.DelDeptCheck(deptListDto.Id);
            if (delDept == true)
            {
                MessageBox.Show("부서 삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("부서 삭제에 실패하였습니다.");
                this.Close();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
