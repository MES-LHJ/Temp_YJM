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

namespace Test.Employees.Forms
{
    public partial class AddEmployee : Form
    {
        public Pattern pattern = new Pattern();//정규식 패턴
        public FIleType fileType = new FIleType();//파일 타입
        public PathAddr path = new PathAddr();

        public int insertEmpId;
        public List<DepartmentDto> MainDeptInfo => DepartmentRepository.DeptRepo.GetMainDeptInfo();// 상위 부서 가져오기
        public DepartmentDto SelectMainDept => mainDeptCodeCombo.SelectedItem as DepartmentDto; // 콤보박스에 선택된 상위부서
        public List<DepartmentDto> SubDeptInfo => DepartmentRepository.DeptRepo.GetSubDeptCode(SelectMainDept.DepartmentId); //하위 부서 정보 가쟈오기
        public DepartmentDto SelectSubDept => subDeptCodeCombo.SelectedItem as DepartmentDto; // 콤보박스에 선택된 하위부서
        string imgFormat;

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


        public AddEmployee()
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
            menCheckBox.CheckedChanged += Men_CheckBox; //남성 체크박스 이벤트 
            womenCheckBox.CheckedChanged += Women_CheckBox; // 여성 체크박스 이벤트
            closeBtn.Click += CloseBtn_Click;//닫기 버튼
            imgSelectBtn.Click += ImgSelect;//이미지 선택
            imgDelBtn.Click += ImgDel;//이미지 삭제
        }
        private void Design()
        {
            imgDelBtn.Visible = false;
            insertBtn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            closeBtn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            mainDeptCodeCombo.Properties.Items.Clear();
            mainDeptCodeCombo.Properties.Items.AddRange(MainDeptInfo);
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
            
            var saveFile = fileType.SaveFile();

            Guid nGuid = Guid.NewGuid();
            string uuid = nGuid.ToString();

            saveFile.FileName = uuid;
            string realFileName = saveFile.FileName + imgFormat;

            if (imgBox.Image == null)
            {
                realFileName = null;
            }

            var getEmpCode = EmployeeRepository.EmpRepo.GetEmpCode(empCodeBox.Text);
            if (getEmpCode != null && getEmpCode.Cnt > 0)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                return;
            }

            var getLoginCode = EmployeeRepository.EmpRepo.GetInsertLoginId(loginIdBox.Text);
            if (getLoginCode == 1)
            {
                MessageBox.Show("중복하는 로그인ID가 존재합니다.");
                return;
            }

            Employee insertEmpInfo = new Employee
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
            insertEmpId = EmployeeRepository.EmpRepo.InsertEmpLinq(insertEmpInfo);
            //System.Diagnostics.Debug.WriteLine(insertEmpId);
            //return;
            string folderPath = path.FolderPath() + insertEmpId;
            string savePath = folderPath + @"\" + saveFile.FileName + imgFormat;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (imgBox.Image != null)
            {

                imgBox.Image.Save(savePath);
            }

            ImgDto insertImg = new ImgDto
            {
                ImgName = realFileName,
                EmployeeId = insertEmpId
            };
            EmployeeRepository.EmpRepo.InsertImgFile(insertImg);

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
            var openFile = fileType.OpenFile();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                imgFormat = Path.GetExtension(filePath).ToLower();

                // 이미지 미리보기
                imgBox.Image = Image.FromFile(filePath);
                imgDelBtn.Visible = true;
            }
        }

        private void ImgDel(object sender, EventArgs e)
        {
            imgBox.Image = null;
            imgDelBtn.Visible = false;
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
