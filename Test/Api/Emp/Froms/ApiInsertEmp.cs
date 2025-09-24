using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Test.Api.Dept.Dtos;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Emp.Forms
{
    public partial class ApiInsertEmp : Form
    {
        public long empId;
        private List<DeptListDto> deptCodeList;//부서코드 리스트
        private DeptListDto SelectDeptCode => deptCodeCombo.SelectedItem as DeptListDto;//콤보박스에서 선택된 부서
        private readonly Pattern pattern = new Pattern();
        private readonly ColorInfo colorInfo = new ColorInfo();

        public ApiInsertEmp()
        {
            InitializeComponent();

            Event();
            Design();
        }

        private void Event()
        {
            this.Load += ApiInsertEmp_Load;
            insertBtn.Click += InsertBtn_Click2;//추가버튼 클릭
            deptCodeCombo.SelectedIndexChanged += Change_DeptCode;//부서코드 변경시 부서명 변경
            closeBtn.Click += CloseBtn_Click;//닫기버튼
        }

        private void Design()
        {
            colorInfo.ChangeSaveBtnColor(insertBtn);
            colorInfo.ChangeCancelBtnColor(closeBtn);

            var labelChange = new List<LayoutControlItem> { deptCodeLabel, empCodeLabel, empNameLabel, loginIdLabel, passwdLabel };//label색 변경
            colorInfo.ChangeValiLabel(labelChange);
        }

        private void Change_DeptCode(object sender, EventArgs e)
        {
            if (deptCodeCombo.EditValue != null)// 선택 항목 선택 확인.
            {
                deptNameBox.Text = SelectDeptCode.Name;
            }
        }

        private async void ApiInsertEmp_Load(object sender, EventArgs e)
        {
            deptCodeList = await DeptRepository.DepartmentRepo.GetDepartmentCode();// 부서코드 리스트
            deptCodeCombo.Properties.Items.AddRange(deptCodeList);
        }

        private async void InsertBtn_Click2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(deptCodeCombo.Text))
            {
                MessageBox.Show("부서코드를 선택하세요");
                return;
            }
            if (string.IsNullOrEmpty(empCodeBox.Text))
            {
                MessageBox.Show("사원코드를 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(empNameBox.Text))
            {
                MessageBox.Show("사원명을 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(loginIdBox.Text))
            {
                MessageBox.Show("로그인ID를 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(passwdBox.Text))
            {
                MessageBox.Show("비밀번호를 입력하세요");
                return;
            }
            if (passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호는 8자 이상이어야 합니다.");
                return;
            }
            if (Regex.IsMatch(passwdBox.Text, pattern.PatternCheck()["passwd"]))
            {
                MessageBox.Show("비밀번호에 특수문자가 포함되어 있습니다.");
                return;
            }
            if (!string.IsNullOrEmpty(emailBox.Text) && !Regex.IsMatch(emailBox.Text, pattern.PatternCheck()["email"]))
            {
                MessageBox.Show("이메일 형식이 올바르지 않습니다.");
                return;
            }

            var empCodeCheck = await EmpRepository.EmpRepo.CheckInsertEmpCode(empCodeBox.Text); // 사원코드 중복 체크
            if (empCodeCheck == true)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                return;
            }
            var loginIdCheck = await EmpRepository.EmpRepo.CheckLoginId(loginIdBox.Text);//loginId 중복체크
            if (loginIdCheck == true)
            {
                MessageBox.Show("중복하는 로그인ID가 존재합니다.");
                return;
            }

            using (var client = new HttpClient())
            {
                var req = new EmpListDto //추가할 사원 정보
                {
                    DepartmentId = SelectDeptCode.Id,
                    Code = empCodeBox.Text,
                    Name = empNameBox.Text,
                    LoginId = loginIdBox.Text,
                    LoginPassword = passwdBox.Text,
                    Position = empRankBox.Text,
                    ContractType = empTypeBox.Text,
                    PhoneNumber = phoneBox.Text,
                    Email = emailBox.Text,
                    MessengerId = messIdBox.Text,
                    Memo = memoBox.Text,
                };

                var insertResult = await EmpRepository.EmpRepo.InsertEmpApi(req);//사원 추가
                if (insertResult != 0)
                {
                    MessageBox.Show("사원 추가에 성공하였습니다");
                    empId = insertResult;
                   
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("사원 추가에 실패하였습니다.");
                    this.Close();
                }
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
