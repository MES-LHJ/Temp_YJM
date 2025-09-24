using System;
using System.Windows.Forms;
using Test.Api.Emp.Dtos;
using Test.Utility;

namespace Test.Api.Emp.Froms
{
    public partial class ApiDelEmp : Form
    {
        private readonly ColorInfo colorInfo = new ColorInfo();
        public EmpListDto empDto;//삭제할 사원 정보
        public ApiDelEmp(EmpListDto employeeDto)
        {
            InitializeComponent();
            empDto = employeeDto;
            Event();
            Design();
        }

        private void Event()
        {
            this.Load += ApiDelEmp_Load;
            delEmpBtn.Click += DelEmpBtn_Click;//삭제버튼 클릭
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
        }

        private void Design()
        {
            colorInfo.ChangeCancelBtnColor(delEmpBtn);
            colorInfo.ChangeCloseBtnColor(closeBtn);
        }

        private void ApiDelEmp_Load(object sender, EventArgs e)
        {
            if (empDto != null)
            {
                delEmpLabel.Text = "삭제할 사원코드 : " + empDto.Code + "\n" +
                                    "삭제할 사원명 : " + empDto.Name + "\n\n" +
                                    "삭제하시겠습니까?";
            }
        }

        private async void DelEmpBtn_Click(object sender, EventArgs e)
        {
            var delEmp = await EmpRepository.EmpRepo.DelEmpApi(empDto.Id);

            if (delEmp == true)
            {
                MessageBox.Show("사원 삭제가 완료되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사원삭제에 실패하였습니다.");
                this.Close();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
