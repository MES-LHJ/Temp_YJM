using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class UpdateEmployee : Form
    {
        private int employeeId; // 수정할 사원 ID를 저장할 변수
        private int gender;
        private string myEmpCode;
        private string departmentId;
        EmployeeRepository empRepo = new EmployeeRepository();

        public UpdateEmployee(int empId)
        {
            
            InitializeComponent();
            
            employeeId = empId;
         
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;
            updateBtn.Click += Complete_Button; // 수정 완료 버튼 클릭 이벤트 핸들러 등록
            closeBtn.Click += Close_Button; // 닫기 버튼 클릭 이벤트 핸들러 등록
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            deptNameBox.ReadOnly = true;
            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화

            var empInfo = empRepo.UpdateEmpInfo(employeeId);// 수정할 사원 정보 가져오기

            deptCodeComboBox.Text = empInfo.departmentCode;
            deptNameBox.Text = empInfo.departmentName;
            empCodeBox.Text = empInfo.employeeCode;
            empNameBox.Text = empInfo.employeeName;
            empRankBox.Text = empInfo.employeeRank;
            empTypeBox.Text = empInfo.employeeType;
            phoneBox.Text = empInfo.phone;
            emailBox.Text = empInfo.email;
            messageBox.Text = empInfo.messId;
            memoBox.Text = empInfo.memo;
            departmentId = empInfo.departmentId.ToString();
            gender = empInfo.gender;
            myEmpCode = empInfo.employeeCode;

            if (gender == 1)
            {
                checkBox2.Checked = true;
            }
            else if (gender == 2)
            {
                checkBox3.Checked = true;
            }

            var deptList = empRepo.GetDeptCode();// 부서 코드 리스트 가져오기
            foreach (var dept in deptList)
            {
                deptCodeComboBox.Items.Add(dept.departmentCode);
            }

        }

        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {

            string deptCode = deptCodeComboBox.Text;
            var deptInfo = empRepo.GetDeptName(deptCode);

            deptNameBox.Text = deptInfo.departmentName;
            departmentId = deptInfo.departmentId.ToString();
        }

        private void Complete_Button(object sender, EventArgs e) //수정 완료 버튼
        {
            Boolean check = true;

            string employeeCode = empCodeBox.Text;
            var checkEmpCode = empRepo.UpdateCheckEmpCode(employeeCode, myEmpCode);

            if(checkEmpCode ==1)
            {
                check = false;
                MessageBox.Show("중복된 사원코드가 존재합니다.");
                return;
            }

            if (check)
            {
                try
                {
                    string email = emailBox.Text;
                    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//이메일 패턴 검사

                    if (string.IsNullOrEmpty(deptCodeComboBox.Text))
                    {
                        MessageBox.Show("부서코드를 선택해주세요.");
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
                    else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, pattern))
                    {
                        MessageBox.Show("이메일 형식이 틀립니다.");
                        return;
                    }
                    EmployeeDto empDto = new EmployeeDto
                    {
                        departmentId = int.Parse(departmentId),
                        employeeCode = empCodeBox.Text,
                        employeeName = empNameBox.Text,
                        employeeRank = empRankBox.Text,
                        employeeType = empTypeBox.Text,
                        phone = phoneBox.Text,
                        email = emailBox.Text,
                        messId = messageBox.Text,
                        memo = memoBox.Text,
                        gender = gender,
                    };
                    empRepo.UpdateEmp(empDto, employeeId);
                    MessageBox.Show("수정이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("수정 중 오류가 발생했습니다: " + ex.Message);
                }

                }
        
        
        }
        private void Check_Box(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Enabled = false;
                gender = 2;
            }
            if (checkBox2.Checked)
            {
                checkBox3.Enabled = false;
                gender = 1;
            }
            if (!checkBox2.Checked)
            {
                checkBox3.Enabled = true;
            }
            if (!checkBox3.Checked)
            {
                checkBox2.Enabled = true;
            }
        }
        private void Close_Button(object sender, EventArgs e)// 닫기 버튼
        {
            this.Close();
        }

       
    }
}
