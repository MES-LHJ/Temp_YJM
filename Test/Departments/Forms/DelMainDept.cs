using System;
using System.Drawing;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class DelMainDept : Form
    {
        private readonly DepartmentDto DeldeptInfo = new DepartmentDto(); // 삭제할 부서 정보
        public DelMainDept(DepartmentDto deptDto)
        {
            InitializeComponent();
            DeldeptInfo = deptDto;
            Event();
            Design();

        }

        public void Event()
        {
            this.Load += DelMainDept_Load;
            mainDeptDelBtn.Click += MainDeptDelBtn_Click;//삭제 버튼
            closeBtn.Click += CloseBtn_Click;
        }

        private void Design()
        {
            mainDeptDelBtn.Appearance.BackColor = ColorTranslator.FromHtml("#F4503B");
            closeBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
        }

        private void DelMainDept_Load(object sender, EventArgs e) //삭제 할 부서 정보 출력
        {
            delMainDeptLabel.Text = "부서 코드 : " + DeldeptInfo.DepartmentCode + "\n" +
                                    "부서명 : " + DeldeptInfo.DepartmentName + "\n\n" +
                                    "삭제하시겠습니까?";
        }

        private void MainDeptDelBtn_Click(object sender, EventArgs e)
        {
            var empCheck = DepartmentRepository.DeptRepo.CheckEmployee(DeldeptInfo.DepartmentId);
            if (empCheck == 1)
            {
                MessageBox.Show("부서에 소속된 사원이 존재합니다.");
                return;
            }
            var lowDeptCheck = DepartmentRepository.DeptRepo.LowDeptInfo(DeldeptInfo.DepartmentId);
            if (lowDeptCheck == 1)
            {
                MessageBox.Show("부서에 소속된 하위 부서가 존재합니다");
                return;
            }

            var delMainDept = DepartmentRepository.DeptRepo.DelMainDeptLinq(DeldeptInfo.DepartmentId);
            if (delMainDept == 1)
            {
                MessageBox.Show("부서 삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("부서 삭제에 실패하였습니다.");
                return;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
