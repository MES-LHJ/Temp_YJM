using System;
using System.Drawing;
using System.Windows.Forms;
using Test.Employees.Models;
using Test.Utility;
using Test.Utility.Forms;

namespace Test.Employees.Forms
{
    public partial class DelEmployee : Form
    {
        public ImageClass imageClass = new ImageClass();
        public EmployeeDto delEmpInfo;//삭제할 사원 정보
        public ColorInfo btnColor = new ColorInfo();

        public DelEmployee(EmployeeDto empDto)
        {
            InitializeComponent();
            Event();
            Design();

            delEmpInfo = empDto;
            this.Load += DelEmployee_Load;
        }

        private void Event()
        {
            empDelBtn.Click += Del_Employee;//사원 삭제 버튼
            closeBtn.Click += CloseBtn_Click; //닫기 버튼
        }

        private void Design()
        {
            btnColor.ChangeCancelBtnColor(empDelBtn);
            btnColor.ChangeCloseBtnColor(closeBtn);
        }
        private void DelEmployee_Load(object sender, EventArgs e)
        {
            if (delEmpInfo != null)
            {
                delInfoLabel.Text = "삭제할 사원코드 : " + delEmpInfo.DepartmentCode + "\n" +
                                    "삭제할 사원명 : " + delEmpInfo.DepartmentName + "\n\n" +
                                    "삭제하시겠습니까?";
            }
        }

        private void Del_Employee(object sender, EventArgs e)//사원 삭제
        {
            var delImgCheck = EmployeeRepository.EmpRepo.ImgInfoLinq(delEmpInfo.EmployeeId);
            if (delImgCheck != null)
            {
                imageClass.DelImg(delImgCheck.ImgId, delEmpInfo.EmployeeId);
                //EmployeeRepository.EmpRepo.DelImgLinq(delImgCheck.ImgId);

                //string folderPath = @"C:\NAS\" + delEmpInfo.EmployeeId;

                //if (Directory.Exists(folderPath))
                //{
                //    Directory.Delete(@"C:\NAS\" + delEmpInfo.EmployeeId, true);
                //}
            }

            var delResult = EmployeeRepository.EmpRepo.DeleteEmployeeLinq(delEmpInfo.EmployeeId); // 사원 삭제 Linq
            if (delResult == 1)
            {
                MessageBox.Show("사원 삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사원 삭제에 실패하였습니다.");
                return;
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
