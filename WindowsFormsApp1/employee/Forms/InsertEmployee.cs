using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.department.Models;
using WindowsFormsApp1.employee.Models;
using WindowsFormsApp1.Utiliity;

namespace WindowsFormsApp1
{
    public partial class InsertEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();
        private readonly Util util = new Util();//공통 코드
        private string imgFormat;//이미지 확장자

        /// 사원코드
        public string EmployeeCode { get => empCodeBox.Text; private set => empCodeBox.Text = value; }

        /// 선택된 부서
        public DepartmentDto SelectedDepartDto => deptCodeComboBox.SelectedItem as DepartmentDto;

        public InsertEmployee()
        {
            InitializeComponent();
            Click_Event();
            Design();
            CheckBox_Event();
            ComboBox_Event();

            this.Load += AddEmployee_Load;
        }

        private void Click_Event()//이벤트 등록
        {
            addBtn.Click += Insert_Button;//추가버튼
            cancleBtn.Click += Cancel_Button;//닫기 버튼
            imgSelectBtn.Click += Img_Select;//이미지 선택
            imgDelBtn.Click += Img_Cancel;//이미지 x 버튼
        }
        private void CheckBox_Event()
        {
            menCheckBox.CheckedChanged += MenCheck_Box;// 남자 체크박스
            womenCheckBox.CheckedChanged += WomenCheck_Box;// 여자 체크박스
        }
        private void ComboBox_Event()
        {
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;//부서코드 변경시 부서명 바뀌게
        }

        private void Design()
        {
            imgDelBtn.Visible = false;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // 데이터 불러오기
            //var deptList = DepartmentRepository.deptRepo.GetDeptListInfo();
            using (var context = new LinqContext())
            {
                var deptListInfo = context.Department
                                            .OrderBy(d => d.departmentId)
                                            .Select(d => new DepartmentDto
                                            {
                                                DepartmentId = d.departmentId,
                                                DepartmentName = d.departmentName,
                                                DepartmentCode = d.departmentCode,
                                                Memo = d.memo
                                            })
                                            .ToList();
                // 콤보박스 파싱 초기화
                deptCodeComboBox.Items.Clear(); // 콤보박스 초기화
                //파싱
                deptCodeComboBox.Items.AddRange(deptListInfo.ToArray());
            }
        }

        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {
            // 선택값 확인 후 부서명 변경
            if (SelectedDepartDto != null)
            {
                deptNameBox.Text = SelectedDepartDto.DepartmentName;
            }
        }

        private void Insert_Button(object sender, EventArgs e)
        {
            string email = emailBox.Text;

            if (SelectedDepartDto == null)
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            else if (string.IsNullOrWhiteSpace(EmployeeCode))
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
            else if (Regex.IsMatch(passwdBox.Text, util.Pattern()["passwd"]))
            {
                MessageBox.Show("비밀번호에 특수문자가 포함 되어있습니다.");
                return;
            }
            else if (passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, util.Pattern()["email"]))
            {
                MessageBox.Show("이메일 형식이 틀립니다.");
                return;
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
            //성별 변경
            if (womenCheckBox.Checked)
            {
                employee.Gender = EmployeeDto.GenderType.Female;
            }
            else if (menCheckBox.Checked)
            {
                employee.Gender = EmployeeDto.GenderType.Male;
            }
            else
            {
                employee.Gender = EmployeeDto.GenderType.noSelect;
            }

                //이미지 저장
                var saveFile = util.ImgSaveType();

            saveFile.FileName = util.Uuid();
            string realFileName = saveFile.FileName + imgFormat;

            if (imgInsertBox.Image == null)
            {
                realFileName = null;
            }

            //int newImgId = EmployeeRepository.empRepo.InsertImgFolder(realFileName);
            try
            {
                using (var context = new LinqContext())
                {
                    var newImg = new img { imgName = realFileName };
                    context.img.Add(newImg);
                    context.SaveChanges();
                    var newImgId = newImg.imgId;

                    // 폴더 생성
                    string folderPath = util.ImgFolderPath() + newImgId;
                    string savePath = folderPath + @"\" + saveFile.FileName + imgFormat;

                    if (imgInsertBox.Image != null)
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        imgInsertBox.Image.Save(savePath);
                    }

                    var empDto = new Employee
                    {
                        departmentId = SelectedDepartDto.DepartmentId,
                        employeeCode = EmployeeCode,
                        employeeName = empNameBox.Text,
                        loginId = loginIdBox.Text,
                        passwd = passwdBox.Text,
                        employeeRank = empRankBox.Text,
                        employeeType = empTypeBox.Text,
                        phone = phoneBox.Text,
                        email = emailBox.Text,
                        messId = messageIdBox.Text,
                        memo = memoBox.Text,
                        gender = Convert.ToInt32(employee.Gender),
                        imgId = newImgId
                    };
                    //EmployeeRepository.empRepo.InsertEmpInfo(empDto);
                    context.Employee.Add(empDto);
                    context.SaveChanges();

                    MessageBox.Show("사원 정보가 성공적으로 추가되었습니다.");

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("사원 정보 추가 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void WomenCheck_Box(object sender, EventArgs e)
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;

            }

        }
        private void MenCheck_Box(object sender, EventArgs e)
        {
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
            }

        }
        private void Img_Select(object sender, EventArgs e)//이미지 선택
        {
            var openFile = util.ImgOpenType();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                imgFormat = Path.GetExtension(filePath).ToLower();

                // 이미지 미리보기
                imgInsertBox.Image = Image.FromFile(filePath);
                imgDelBtn.Visible = true;
            }
        }
        private void Img_Cancel(object sender, EventArgs e)
        {
            imgInsertBox.Image = null;
            imgDelBtn.Visible = false;
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
