using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class InsertEmployee : Form
    {
        private int gender = 0;
        private string deptId;
        private string deptCode;
        EmployeeRepository empRepo = new EmployeeRepository();
        public InsertEmployee()
        {
            InitializeComponent();

            deptCodeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;
            addBtn.Click += Insert_Button;//추가버튼
            cancleBtn.Click += Cancel_Button;//닫기 버튼
            menCheckBox.CheckedChanged += MenCheck_Box;
            womenCheckBox.CheckedChanged += WomenCheck_Box;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            deptNameBox.ReadOnly = true;
            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화

            var deptList = empRepo.GetDeptCode();
            foreach (var dept in deptList)
            {
                deptCodeComboBox.Items.Add(dept.departmentCode);
            }
        }

        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {
            deptCode = deptCodeComboBox.Text;
            var deptInfo = empRepo.GetDeptName(deptCode);

            deptNameBox.Text = deptInfo.departmentName;
            deptId = deptInfo.departmentId.ToString();
        }

        private void Insert_Button(object sender, EventArgs e)
        {
            bool check = true;
            
            deptCode = deptCodeComboBox.Text;


            string email = emailBox.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//이메일 형식(@와 공백 제외 + @ + . +도메인)
            if (deptCodeComboBox.Text.Equals(""))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(empCodeBox.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(empNameBox.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(loginIdBox.Text))
            {
                MessageBox.Show("로그인 아이디를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(passwdBox.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            else if (Regex.IsMatch(passwdBox.Text, "[^a-zA-Z0-9]"))//영문자나 숫자가 아닌
            {
                MessageBox.Show("비밀번호에 특수문자가 포함 되어있습니다.");
                return;
            }
            else if (passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("이메일 형식이 틀립니다.");
                return;
            }

            var getEmpCode = empRepo.GetEmpCode(empCodeBox.Text);
            if (getEmpCode != null && getEmpCode.cnt > 0)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                check = false;
                return;
            }

            var getLoginCode = empRepo.GetInsertLoginId(loginIdBox.Text);
            if (getLoginCode == 1)
            {
                MessageBox.Show("중복하는 로그인ID가 존재합니다.");
                check = false;
                return;
            }
            if (check)
            {
                
                var empDto = new EmployeeDto
                {
                    departmentId = Convert.ToInt32(deptId),
                    employeeCode = empCodeBox.Text,
                    employeeName = empNameBox.Text,
                    loginId = loginIdBox.Text,
                    passwd = passwdBox.Text,
                    employeeRank = empRankBox.Text,
                    employeeType = empTypeBox.Text,
                    phone = phoneBox.Text,
                    email = emailBox.Text,
                    messId = messageIdBox.Text,
                    memo = memoBox.Text,
                    gender = gender
                };
               
                empRepo.InsertEmpInfo(empDto);
                MessageBox.Show("사원 정보가 성공적으로 추가되었습니다.");
                this.DialogResult = DialogResult.OK;

            }


        }
        private void WomenCheck_Box(object sender, EventArgs e)
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;
                gender = 2;
            }
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
                gender = 1;
            }
            
        }
        private void MenCheck_Box(object sender, EventArgs e)
        {
            
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
                gender = 1;
            }

        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }

       
    }
}
