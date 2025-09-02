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
using WindowsFormsApp1.employee.Models;
using WindowsFormsApp1.Utiliity;

namespace WindowsFormsApp1.employee
{
    public partial class UpdateLoginInfo : Form
    {
        private readonly int employeeId;
        private readonly string myLoginId;//수정할 로그인 아이디 저장
        private readonly Util util = new Util();//공통 코드
        public UpdateLoginInfo(int empId, string myLoginId)
        {
            employeeId = empId;
            this.myLoginId = myLoginId;

            InitializeComponent();
            Click_Event();//버튼 클릭 이벤트
        }

        private void Click_Event()
        {
            updateBtn.Click += UpdateBtn_Click;//수정 버튼
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
        }
        private int Check_Id(string loginId, string myLoginId)//아이디 중복체크
        {
            using (var context = new LinqContext())
            {
                //중복되는 아이디가 있는지 확인
                var loginCheck = context.Employee
                                            .Where(a => a.loginId == loginId && a.loginId != myLoginId)
                                            .Any();

                return loginCheck ? 1 : 0;

            }
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string loginId = loginIdBox.Text;
            string passwd = passwdBox.Text;
            //var loginIdCheck = EmployeeRepository.empRepo.GetLoginId(loginId, myLoginId);
            int check = Check_Id(loginId, myLoginId);


            if (check == 1)
            {
                MessageBox.Show("중복되는 로그인 아이디가 존재합니다.");
                return;
            }
            try
            {
                if (Regex.IsMatch(passwdBox.Text, util.Pattern()["passwd"]))
                {
                    MessageBox.Show("비밀번호에 특수문자가 포함되어있습니다.");
                    return;
                }
                else if (passwdBox.Text.Length < 8)
                {
                    MessageBox.Show("비밀번호를 8자리이상 입력해주세요.");
                    return;
                }
                //return;
                EmployeeRepository.EmpRepo.UpdateLogin(employeeId, loginId, passwd);
                MessageBox.Show("수정이 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("수정 실패 : " + ex.Message);
                return;

            }

        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
