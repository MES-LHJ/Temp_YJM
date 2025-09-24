using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class AddMainDept : Form
    {
        public int newMainDeptId;
        public AddMainDept()
        {
            InitializeComponent();
            Event();
            Design();
        }

        public void Event()
        {
            insertBtn.Click += InsertBtn_Click;
            cancelBtn.Click += CancelBtn_Click;
        }
        private void Design()
        {
            insertBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            cancelBtn.Appearance.BackColor = ColorTranslator.FromHtml("#F4503B ");
            new[] { mainDeptCodeLabel, mainDeptNameLabel }.ToList()
                    .ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            var insertMainDept = new Department
            {
                departmentCode = mainDeptCodeLabel.Text,
                departmentName = mainDeptNameBox.Text,
                memo = mainMemoBox.Text,
            };
            var mainDeptCodeCheck = DepartmentRepository.DeptRepo.InsertDeptCodeCheck(mainDeptCodeLabel.Text);
            if (mainDeptCodeCheck == 1)
            {
                MessageBox.Show("상위 부서 코드가 중복입니다.");
                return;
            }

            newMainDeptId = DepartmentRepository.DeptRepo.InsertMainDept(insertMainDept);

            if (newMainDeptId != 0)
            {
                MessageBox.Show("상위 부서 추가에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("상위 부서 추가에 실패하였습니다.");
                return;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
