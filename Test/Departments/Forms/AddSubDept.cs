using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class AddSubDept : Form
    {

        private List<DepartmentDto> deptInfo => DepartmentRepository.DeptRepo.GetLinqDeptListInfo();
        private DepartmentDto SelDeptCode => deptCodeComboBox.SelectedItem as DepartmentDto;
        public AddSubDept()
        {
            InitializeComponent();
            Design();
            Event();

            this.Load += SubDeptInsert_Load;
        }

        private void Event()
        {
            deptCodeComboBox.SelectedIndexChanged += DeptNameBox_Chage;
            insertBtn.Click += SubDept_Insert;
            cancelBtn.Click += CancelBtn_Click;
        }


        private void Design()
        {
            insertBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            cancelBtn.Appearance.BackColor = ColorTranslator.FromHtml("#ABABAB");
            new[] { mainDeptCodeLabel, mainDeptNameLabel, subDeptCodeLabel, subDeptNameLabel }
                    .ToList().ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));
        }
        private void SubDeptInsert_Load(object sender, EventArgs e)
        {

            deptCodeComboBox.Properties.Items.Clear();
            deptCodeComboBox.Properties.Items.AddRange(deptInfo.ToArray());
        }
        private void DeptNameBox_Chage(object sender, EventArgs e)
        {
            if (deptInfo != null) deptNameBox.Text = SelDeptCode.DepartmentName;
        }
        private void SubDept_Insert(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(deptCodeComboBox.Text))
            {
                MessageBox.Show("상위 부서코드 선택해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(subDeptCodeBox.Text))
            {
                MessageBox.Show("하위 부서코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(subDeptNameBox.Text))
            {
                MessageBox.Show("하위 부서명을 입력해주세요.");
                return;
            }
            using (var context = new Linq2Context())
            {
                try
                {
                    var subDeptCodeCheck = context.SubDepartment
                                                    .Any(s => s.subDeptCode == subDeptCodeBox.Text); //&& s.departmentId == SelDeptCode.DepartmentId);
                    if (subDeptCodeCheck == true)
                    {
                        MessageBox.Show("하위 부서코드가 중복입니다.");
                        return;
                    }

                    var subInsert = new SubDepartment
                    {
                        departmentId = SelDeptCode.DepartmentId,
                        subDeptCode = subDeptCodeBox.Text,
                        subDeptName = subDeptNameBox.Text,
                        memo = subMemoBox.Text
                    };
                    context.SubDepartment.Add(subInsert);
                    context.SaveChanges();

                    MessageBox.Show("부서 추가가 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("부서 추가에 실패하였습니다. " + ex.Message);
                }

            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
