using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;

namespace WindowsFormsApp1
{
    public partial class UpdateDepartment : Form
    {
        private int departmentId; // 부서 ID를 저장할 변수
        DepartmentRepository deptRepo = new DepartmentRepository();
        private string myDeptCode;
        public UpdateDepartment(int departId)
        {
            
            InitializeComponent();
            departmentId = departId; // 생성자에서 부서 ID를 받아와서 저장
            //Console.WriteLine("수정페이지 deptId: " + departmentId);

            this.Load += UpdateDepartment_Load;
            updateBtn.Click += Update_Button;//저장 버튼
            closeBtn.Click += Close_Button;// 닫기 버튼
        }


        private void UpdateDepartment_Load(object sender, EventArgs e)
        {
            var deptInfo = deptRepo.DepartmentInfo(departmentId);

            deptCodeBox.Text = deptInfo.departmentCode;
            deptNameBox.Text = deptInfo.departmentName;
            memoBtn.Text = deptInfo.memo;
            myDeptCode = deptInfo.departmentCode;
            
        }

        private void Update_Button(object sender, EventArgs e)
        {
            Boolean check = true;

            var checkDeptCode = deptRepo.UpdateDeptCodeCheck(deptCodeBox.Text,myDeptCode);
            if (checkDeptCode == 1)
            {
                MessageBox.Show("중복되는 부서코드가 존재합니다.");
                check = false;
                return;
            }

            if (check)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(deptCodeBox.Text))
                    {
                        MessageBox.Show("부서코드 입력하세요");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(deptNameBox.Text))
                    {
                        MessageBox.Show("부서명을 입력하세요");
                        return;
                    }
                    DepartmentDto deptDto = new DepartmentDto
                    {
                        departmentCode = deptCodeBox.Text,
                        departmentName = deptNameBox.Text,
                        memo = memoBtn.Text,
                        departmentId = departmentId
                    };
                    deptRepo.UpdateDept(deptDto);
                        MessageBox.Show("수정완료");
                        this.DialogResult = DialogResult.OK;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("수정 실패: " + ex.Message);
                    return;
                }


            }
        }
        private void Close_Button(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
