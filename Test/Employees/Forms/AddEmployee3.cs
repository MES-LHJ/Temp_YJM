using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Test.Departments.Models;
using Test.Employees.Dtos;
using Test.Employees.Models;
using Test.Utility;
using Test.Utility.Forms;

namespace Test.Employees.Forms
{
    public partial class AddEmployee3 : Form
    {
        public Pattern pattern = new Pattern();//정규식 패턴
        public FIleType fileType = new FIleType();//파일 타입
        public PathAddr path = new PathAddr();
        public ImageClass imgClass = new ImageClass();
        public ColorInfo btnColor =new ColorInfo();

        public int insertEmpId;
        public string imgFormat;
        public List<DepartmentDto> MainDeptInfo => DepartmentRepository.DeptRepo.GetMainDeptInfo();// 상위 부서 가져오기
        public DepartmentDto SelectMainDept => mainDeptCodeCombo.SelectedItem as DepartmentDto; // 콤보박스에 선택된 상위부서
        public List<DepartmentDto> SubDeptInfo => DepartmentRepository.DeptRepo.GetSubDeptCode(SelectMainDept.DepartmentId); //하위 부서 정보 가쟈오기
        public DepartmentDto SelectSubDept => subDeptCodeCombo.SelectedItem as DepartmentDto; // 콤보박스에 선택된 하위부서

        public EmployeeDto.GenderType Gender // 체크박스 성별 선택 시 
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

        public AddEmployee3()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            this.Load += AddEmployee_Load;

            mainDeptCodeCombo.Properties.SelectedIndexChanged += Select_MainDeptCode;//상위 부서 코드 변경시
            subDeptCodeCombo.Properties.SelectedIndexChanged += SubDeptName_Change;//하위 부서 코드 변경시

            insertBtn.Click += Insert_Employee;// 저장 버튼
            cancelBtn.Click += CloseBtn_Click;//닫기 버튼
            imgSelectBtn.Click += ImgSelect;//이미지 선택
            imgDelBtn.Click += ImgDel;//이미지 삭제

            menCheckBox.CheckedChanged += Men_CheckBox; //남성 체크박스 이벤트 
            womenCheckBox.CheckedChanged += Women_CheckBox; // 여성 체크박스 이벤트
           
        }
        private void Design()
        {
            imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; //이미지 x 버튼 설정

            //insertBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            btnColor.ChangeSaveBtnColor(insertBtn);
            btnColor.ChangeCancelBtnColor(cancelBtn);
            imgSelectBtn.Appearance.BackColor = ColorTranslator.FromHtml("#0072C6");
            new[] { mainDeptCodeLabel, mainDeptNameLabel, subDeptCodeLabel, subDeptNameLabel, empCodeLabel, empNameLabel, loginIdLabel, passwdLabel }
                    .ToList().ForEach(x => x.AppearanceItemCaption.ForeColor = ColorTranslator.FromHtml("#F4503B"));

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            mainDeptCodeCombo.Properties.Items.Clear();
            mainDeptCodeCombo.Properties.Items.AddRange(MainDeptInfo); // 상위 부서코드 콤보박스 채우기
        }

        private void Select_MainDeptCode(object sender, EventArgs e)
        {
            mainDeptNameBox.Text = SelectMainDept.DepartmentCode; // 상위 부서 부서명 가져오기

            subDeptCodeCombo.Properties.Items.Clear();
            subDeptCodeCombo.Text = null;
            subDeptNameBox.Text = null;

            if (SubDeptInfo != null)
            {
                subDeptCodeCombo.Properties.Items.AddRange(SubDeptInfo);
            }
        }

        private void Insert_Employee(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectMainDept.DepartmentCode))
            {
                MessageBox.Show("상위 부서 코드를 선택해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(SelectSubDept.DepartmentCode))
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
            else if (string.IsNullOrEmpty(loginIdBox.Text))
            {
                MessageBox.Show("로그인ID를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrEmpty(passwdBox.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            else if (Regex.IsMatch(passwdBox.Text, pattern.PatternCheck()["passwd"]))
            {
                MessageBox.Show("비밀번호에 특수문자가 포함되어 있습니다.");
                return;
            }
            else if (passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(emailBox.Text) && !Regex.IsMatch(emailBox.Text, pattern.PatternCheck()["email"]))
            {
                MessageBox.Show("이메일 형식을 맞춰주세요.");
                return;
            }
            //사원코드 중복체크
            var getEmpCode = EmployeeRepository.EmpRepo.GetEmpCode(empCodeBox.Text);
            if (getEmpCode != null && getEmpCode.Cnt > 0)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                return;
            }
            //로그인ID 중복채크
            var getLoginCode = EmployeeRepository.EmpRepo.GetInsertLoginId(loginIdBox.Text);
            if (getLoginCode == 1)
            {
                MessageBox.Show("중복하는 로그인ID가 존재합니다.");
                return;
            }


            Employee insertEmpInfo = new Employee//사원 추가할 정보들
            {
                departmentId = SelectMainDept.DepartmentId,
                subDeptId = SelectSubDept.SubDeptId,
                employeeCode = empCodeBox.Text,
                employeeName = empNameBox.Text,
                loginId = loginIdBox.Text,
                passwd = passwdBox.Text,
                employeeRank = empRankBox.Text,
                employeeType = empTypeBox.Text,
                phone = phoneBox.Text,
                email = emailBox.Text,
                messId = messIdBox.Text,
                memo = memoBox.Text,
                gender = (int)Gender
            };
            insertEmpId = EmployeeRepository.EmpRepo.InsertEmpLinq(insertEmpInfo);//사원 추가 linq
         
            var realFileName = imgClass.InsertFormSaveImg(imgBox.Image, insertEmpId, imgFormat);//추가할 이미지 파일명

            ImgDto insertImg = new ImgDto // 추가할 이미지 정보
            {
                ImgName = realFileName,
                EmployeeId = insertEmpId
            };

            EmployeeRepository.EmpRepo.InsertImgFile(insertImg);//이미지 추가 linq

            if (insertEmpId != 0)
            {
                MessageBox.Show("사원 추가에 성공하였습니다.");

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사원 추가에 실패하였습니다.");
                return;
            }

        }

        private void ImgSelect(object sender, EventArgs e) //이미지 선택
        {
            if (imgClass.InsertFormOpenImg(out Image selectImg, out string format))
            {
                imgBox.Image = selectImg;
                imgFormat = format;
                imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

        }

        private void ImgDel(object sender, EventArgs e)//이미지 미리보기 삭제
        {
            imgBox.Image = null;
            imgDelLayout.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubDeptName_Change(object sender, EventArgs e)//하위 부서코드 변경시
        {
            subDeptNameBox.Text = SelectSubDept.SubDeptName;
        }

        private void Men_CheckBox(object sender, EventArgs e)//남자 체크박스
        {
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
            }
        }

        private void Women_CheckBox(object sender, EventArgs e)//여자 체크박스
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;
            }
        }

    }
}
