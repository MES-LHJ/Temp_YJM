using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Test.Departments.Models;
using Test.Employees.Dtos;
using Test.Employees.Models;
using Test.Utility;
using System.Linq;
using Test.Utility.Forms;

namespace Test.Employees.Forms
{
    public partial class UpdateEmployee : Form
    {
        public EmployeeDto empInfo;//수정할 사원 정보
        public Pattern pattern = new Pattern();//정규식 패턴
        public FIleType fileType = new FIleType();
        public PathAddr path = new PathAddr();
        public ImageClass imgClass = new ImageClass();
        public ColorInfo btnColor = new ColorInfo();

        private bool imgChange = false; // 이미지 업데이트 확인
        private string imgFormat;//이미지 포멧
        private int cnt;//이미지 사진이 업데이트 됐는지 확인 위해서

        public List<DepartmentDto> MainDeptCodeInfo => DepartmentRepository.DeptRepo.GetMainDeptInfo(); // 상위부서 정보
        public DepartmentDto SelectMainDeptCode => mainDeptCodeCombo.SelectedItem as DepartmentDto; //콤보박스에서 선택된 상위 부서 정보

        public List<DepartmentDto> SubDeptCodeInfo
                    => SelectMainDeptCode == null ? DepartmentRepository.DeptRepo.GetSubDeptCode(empInfo.DepartmentId) : DepartmentRepository.DeptRepo.GetSubDeptCode(SelectMainDeptCode.DepartmentId); //선택된 하위 부서 정보
        public DepartmentDto SelectSubDeptCode => subDeptCodeCombo.SelectedItem as DepartmentDto; //하위부서 정보
        public ImgDto ImgInfo => EmployeeRepository.EmpRepo.ImgInfoLinq(empInfo.EmployeeId); //업데이트할 이미지 정보
        public EmployeeDto.GenderType Gender
        {
            get
            {
                EmployeeDto.GenderType gender;
                if (menCheckBox.Checked)
                {
                    gender = EmployeeDto.GenderType.Male;
                }
                else if (womenCheckBox.Checked)
                {
                    gender = EmployeeDto.GenderType.Female;
                }
                else
                {
                    gender = EmployeeDto.GenderType.noSelect;
                }
                return gender;
            }
        }

        public UpdateEmployee(EmployeeDto empDto)
        {
            InitializeComponent();
            empInfo = empDto;
            Event();
            Design();
        }
        private void Event()
        {
            this.Load += UpdateEmployee_Load;
            mainDeptCodeCombo.SelectedIndexChanged += MainDeptCode_Change; // 상위 부서코드 변경 시
            subDeptCodeCombo.SelectedIndexChanged += SubDeptCode_Changed; // 하위 부서코드 변경 시 
            updateBtn.Click += Update_Employee;//수정버튼
            menCheckBox.CheckedChanged += Men_CheckBox; //남성 체크박스 이벤트 
            womenCheckBox.CheckedChanged += Women_CheckBox; // 여성 체크박스 이벤트
            imgDelBtn.Click += DelImg; // 이미지  삭제 버튼
            updateImgBtn.Click += Select_UpdateImg;// 이미지 수정 버튼
            closeBtn2.Click += CloseBtn; //닫기 버튼
        }
        private void Design()
        {
            btnColor.ChangeSaveBtnColor(updateBtn);
            btnColor.ChangeCloseBtnColor(closeBtn2);
            updateImgBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            new[] { mainDeptCodeLabel, mainDeptNameLabel, subDeptCodeLabel, subDeptNameLabel, empCodeLabel, empNameLabel }
                    .ToList().ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));
        }
        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            mainDeptCodeCombo.Text = empInfo.DepartmentCode;
            mainDeptNameBox.Text = empInfo.DepartmentName;
            subDeptCodeCombo.Text = empInfo.SubDeptCode;
            subDeptNameBox.Text = empInfo.SubDeptName;
            empCodeBox.Text = empInfo.EmployeeCode;
            empNameBox.Text = empInfo.EmployeeName;
            empRankBox.Text = empInfo.EmployeeRank;
            empTypeBox.Text = empInfo.EmployeeType;
            phoneBox.Text = empInfo.Phone;
            emailBox.Text = empInfo.Email;
            messIdBox.Text = empInfo.MessId;
            memoBox.Text = empInfo.Memo;

            if (empInfo.Gender == EmployeeDto.GenderType.Male)
            {
                menCheckBox.Checked = true;
            }
            else if (empInfo.Gender == EmployeeDto.GenderType.Female)
            {
                womenCheckBox.Checked = true;
            }

            string folderPath = path.FolderPath() + empInfo.EmployeeId;
            if (ImgInfo != null)
            {
                string imgPath = folderPath + @"\" + ImgInfo.ImgName;

                if (!string.IsNullOrEmpty(ImgInfo.ImgName) && File.Exists(imgPath))
                {
                    updateImgBox.Image = Image.FromFile(imgPath);
                    imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }

            mainDeptCodeCombo.Properties.Items.Clear();
            mainDeptCodeCombo.Properties.Items.AddRange(MainDeptCodeInfo); // 상위 부서코드 콤보박스

            subDeptCodeCombo.Properties.Items.AddRange(SubDeptCodeInfo);// 하위 부서코드 콤보박스
        }

        private void Update_Employee(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainDeptCodeCombo.Text))
            {
                MessageBox.Show("상위 부서 코드를 선택해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(subDeptCodeCombo.Text))
            {
                MessageBox.Show("하위 부서 코드를 선택해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(empCodeBox.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(empNameBox.Text))
            {
                MessageBox.Show("사원명를 입력해주세요.");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(emailBox.Text) && !Regex.IsMatch(emailBox.Text, pattern.PatternCheck()["email"]))
            {
                MessageBox.Show("이메일 형식을 맞춰주세요.");
                return;
            }

            var getEmpCode = EmployeeRepository.EmpRepo.UpdateEmpCodeCheckLinq(empCodeBox.Text, empInfo.EmployeeCode);//사원코드 중복체크
            if (getEmpCode == true)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                return;
            }

            var UpdateEmpinfo = new Employee//사원 정보 수정한 데이터
            {
                departmentId = SelectMainDeptCode != null ? SelectMainDeptCode.DepartmentId : empInfo.DepartmentId,
                subDeptId = SelectSubDeptCode != null ? SelectSubDeptCode.SubDeptId : empInfo.SubDeptId,
                employeeCode = empCodeBox.Text,
                employeeName = empNameBox.Text,
                employeeRank = empRankBox.Text,
                employeeType = empTypeBox.Text,
                gender = (int)Gender,
                phone = phoneBox.Text,
                email = emailBox.Text,
                messId = messIdBox.Text,
                memo = memoBox.Text,
                employeeId = empInfo.EmployeeId,
            };

            var updateCheck = EmployeeRepository.EmpRepo.UpdateEmpLinq(UpdateEmpinfo); //사원 정보 수정 Linq

            //수정할 이미지파일 명
            var saveImgFile = imgClass.UpdateFormSaveImg(updateImgBox.Image, empInfo.EmployeeId, imgFormat, ImgInfo, imgChange, cnt);

            var updateImg = new ImgDto//수정한 이미지 정보
            {
                ImgName = saveImgFile,
                EmployeeId = empInfo.EmployeeId
            };

            EmployeeRepository.EmpRepo.UpdateImgLinq(updateImg); //이미지 수정 Linq

            if (updateCheck == 1)
            {
                MessageBox.Show("사원정보가 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사원정보 수정에 실패하였습니다.");
                return;
            }
        }

        private void SubDeptCode_Changed(object sender, EventArgs e)
        {
            subDeptNameBox.Text = SelectSubDeptCode.SubDeptName;
        }

        private void MainDeptCode_Change(object sender, EventArgs e)
        {
            mainDeptNameBox.Text = SelectMainDeptCode.DepartmentName;

            subDeptCodeCombo.Properties.Items.Clear();
            subDeptCodeCombo.Text = null;
            subDeptNameBox.Text = null;

            subDeptCodeCombo.Properties.Items.AddRange(SubDeptCodeInfo);
        }


        private void Men_CheckBox(object sender, EventArgs e) //남자 성별 체크박스
        {
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
            }
        }
        private void Women_CheckBox(object sender, EventArgs e)//여자 성별 체크박스
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;
            }
        }

        private void Select_UpdateImg(object sender, EventArgs e) // 이미지 수정 파일
        {
            if (imgClass.UpdateFormOpenImg(out Image changeImg, out string imgForm, out bool imgChageResult))
            {
                imgFormat = imgForm;
                imgChange = imgChageResult;
                if (changeImg != null)
                {
                    if (updateImgBox.Image != null)
                    {
                        updateImgBox.Image.Dispose();
                        updateImgBox.Image = null;
                    }
                }
                cnt++;
                updateImgBox.Image = changeImg;
                imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void DelImg(object sender, EventArgs e)
        {
            updateImgBox.Image.Dispose();
            updateImgBox.Image = null;

            imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            imgChange = false;
        }
        private void CloseBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
