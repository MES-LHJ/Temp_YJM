using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class UpdateMainDept : Form
    {
        public DepartmentDto Department;
        public UpdateMainDept(DepartmentDto deptDto)
        {
            InitializeComponent();
            Department = deptDto;
            Event();
            Design();

            this.Load += MainDept_Load;
        }
        public void Event()
        {
            mainUpdateBtn.Click += MainDept_Update;
            closeBtn.Click += CloseBtn_Click;
        }

        private void Design()
        {
            mainUpdateBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            closeBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
            new[] { mainDeptCodeLabel, mainDeptNameLabel }.ToList().ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));
        }
        public void MainDept_Load(object sender, EventArgs e)
        {
            mainDeptCodeBox.Text = Department.DepartmentCode;
            mainNameBox.Text = Department.DepartmentName;
            mainMemoBox.Text = Department.Memo;
        }
        public void MainDept_Update(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(mainDeptCodeLabel.Text))
            {
                MessageBox.Show("부서코드 선택해주세요");
                return;
            }
            else if (string.IsNullOrEmpty(mainNameBox.Text))
            {
                MessageBox.Show("부서명을 입력해주세요.");
                return;
            }

            try
            {
                var updateDeptInfo = new DepartmentDto
                {
                    DepartmentId = Department.DepartmentId,
                    DepartmentCode = mainDeptCodeLabel.Text,
                    DepartmentName = mainNameBox.Text,
                    Memo = mainMemoBox.Text
                };
                var deptCodeCheck = DepartmentRepository.DeptRepo.UpdateDeptCodeCheck(updateDeptInfo.DepartmentCode, Department.DepartmentCode);
                if (deptCodeCheck == 1)
                {
                    MessageBox.Show("부서코드 중복입니다.");
                    return;
                }
                //Console.WriteLine(updateDeptInfo.DepartmentName);
                //return;
                var mainDeptUpdate = DepartmentRepository.DeptRepo.MainDeptUdpate(updateDeptInfo);

                if (mainDeptUpdate == 1)
                {
                    MessageBox.Show("수정 성공");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("수정 실패");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("수정이 실패하였습니다." + ex.Message);
            }

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
