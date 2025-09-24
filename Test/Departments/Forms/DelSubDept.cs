using System;
using System.Drawing;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class DelSubDept : Form
    {
        private readonly DepartmentDto delSubDeptInfo;
        public DelSubDept(DepartmentDto delInfo, string mainDeptCode)
        {
            InitializeComponent();
            Event();
            Design();

            delSubDeptInfo = delInfo;
            delSubDeptInfo.DepartmentCode = mainDeptCode;//상위 부서코드

            this.Load += DelSubDept_Load;
        }

        private void Event()
        {
            subDeptDelBtn.Click += Del_SubDept;//하위부서 삭제 버튼
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
        }

        private void Design()
        {
            subDeptDelBtn.Appearance.BackColor = ColorTranslator.FromHtml("#F4503B");
            closeBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");

        }
        private void DelSubDept_Load(object sender, EventArgs e)
        {
            delSubDeptLabel.Text = "소속된 상위 부서 코드 : " + delSubDeptInfo.DepartmentCode + "\n" +
                                   "삭제할 하위 부서 코드 : " + delSubDeptInfo.SubDeptCode + "\n\n" +
                                   "삭제할 하위 부서명 : " + delSubDeptInfo.SubDeptName;
        }
        private void Del_SubDept(object sender, EventArgs e)
        {
            var checkEmp = DepartmentRepository.DeptRepo.CheckSubDeptEmp(delSubDeptInfo.SubDeptId);
            if (checkEmp == 1)
            {
                MessageBox.Show("하위 부서에 소속된 사원이 존재합니다.");
                return;
            }
            //System.Diagnostics.Debug.WriteLine($"삭제할 하위 부서 코드 : {delSubDeptInfo.SubDeptCode}, 삭제할 하위 부서명 : {delSubDeptInfo.SubDeptName}, 상위 부서 아이디 : {delSubDeptInfo.ParentId}, 하위 부서 아이디 : {delSubDeptInfo.SubDeptId}");
            //return;
            var delSubDept = DepartmentRepository.DeptRepo.DeleteSubDeptLinq(delSubDeptInfo.DepartmentId, delSubDeptInfo.SubDeptId);
            if (delSubDept == 1)

            {
                MessageBox.Show("하위 부서가 삭제되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("하위 부서 삭제에 실패하였습니다.");
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
