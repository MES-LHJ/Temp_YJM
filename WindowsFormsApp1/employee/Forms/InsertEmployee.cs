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
using WindowsFormsApp1.department.Model;
using WindowsFormsApp1.employee.Model;

namespace WindowsFormsApp1
{
    public partial class InsertEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();
        private string imgFormat;

        public InsertEmployee()
        {
            InitializeComponent();
            Click_Event();
            Design();
            Img_Event();

            this.Load += AddEmployee_Load;
        }

        private void Click_Event()//이벤트 등록
        {
            addBtn.Click += Insert_Button;//추가버튼
            cancleBtn.Click += Cancel_Button;//닫기 버튼
            menCheckBox.CheckedChanged += MenCheck_Box;
            womenCheckBox.CheckedChanged += WomenCheck_Box;
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;
        }

        private void Img_Event()
        {
            imgSelectBtn.Click += Img_Select;
            imgDelBtn.Click += Img_Cancel;

        }
        private void Design()
        {
            deptCodeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            imgInsertBox.SizeMode = PictureBoxSizeMode.Zoom;
            imgDelBtn.Visible = false;
            imgInsertBox.ForeColor = Color.White;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            deptNameBox.ReadOnly = true;
            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화

            var deptList = EmployeeRepository.empRepo.GetDeptCode();
            foreach (var dept in deptList)
            {
                deptCodeComboBox.Items.Add(dept.departmentCode);
            }


        }

        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {
            employee.departmentCode = deptCodeComboBox.Text;
            var deptInfo = EmployeeRepository.empRepo.GetDeptName(employee.departmentCode);

            deptNameBox.Text = deptInfo.departmentName;
            employee.departmentId = Convert.ToInt32(deptInfo.departmentId.ToString());
        }

        private void Insert_Button(object sender, EventArgs e)
        {
            employee.departmentCode = deptCodeComboBox.Text;

            string email = emailBox.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//이메일 형식(@와 공백 제외 + @뒤에 오는문자가 @이나 공백이 아니면 + . +도메인(.다음에 공백이나 @가아니면)+문자열 끝

            if (deptCodeComboBox.Text.Equals(""))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
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
            else if (Regex.IsMatch(passwdBox.Text, "[^a-zA-Z0-9]"))//영문자나 숫자가 아닌
            {
                MessageBox.Show("비밀번호에 특수문자가 포함 되어있습니다.");
                return;
            }
            else if (passwdBox.Text.Length < 8)
            {
                MessageBox.Show("비밀번호를 8자리 이상 입력해주세요.");
                return;
            }
            else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("이메일 형식이 틀립니다.");
                return;
            }

            var getEmpCode = EmployeeRepository.empRepo.GetEmpCode(empCodeBox.Text);
            if (getEmpCode != null && getEmpCode.cnt > 0)
            {
                MessageBox.Show("중복하는 사원코드가 존재합니다.");
                return;
            }

            var getLoginCode = EmployeeRepository.empRepo.GetInsertLoginId(loginIdBox.Text);
            if (getLoginCode == 1)
            {
                MessageBox.Show("중복하는 로그인ID가 존재합니다.");
                return;
            }

            //이미지 저장
            Guid nGuid = Guid.NewGuid();
            string uuid = nGuid.ToString();//uuid

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";
            saveFileDialog.Title = "이미지 저장";
            saveFileDialog.FileName = uuid;
            string realFileName = saveFileDialog.FileName + imgFormat;

            if (imgInsertBox.Image == null)
            {
                realFileName = null;
            }

            var empDto = new EmployeeDto
            {
                departmentId = employee.departmentId,
                employeeCode = empCodeBox.Text,
                employeeName = empNameBox.Text,
                loginId = loginIdBox.Text,
                passwd = passwdBox.Text,
                employeeRank = empRankBox.Text,
                employeeType = empTypeBox.Text,
                phone = phoneBox.Text,
                email = emailBox.Text,
                messId = messageIdBox.Text,
                memo = memoBox.Text,
                gender = employee.gender,
                imgName = realFileName,
            };

            int newImgId = EmployeeRepository.empRepo.InsertImgFolder(realFileName);
            empDto.imgId = newImgId;

            EmployeeRepository.empRepo.InsertEmpInfo(empDto);
            MessageBox.Show("사원 정보가 성공적으로 추가되었습니다.");

            // 폴더 생성
            string folderPath = @"C:\NAS\" + newImgId;
            string savePath = folderPath + @"\" + saveFileDialog.FileName + imgFormat;

            if (imgInsertBox.Image != null)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                imgInsertBox.Image.Save(savePath);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void WomenCheck_Box(object sender, EventArgs e)
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;
                employee.gender = EmployeeDto.GenderType.Female;
            }

        }
        private void MenCheck_Box(object sender, EventArgs e)
        {
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
                employee.gender = EmployeeDto.GenderType.Male;
            }

        }
        private void Img_Select(object sender, EventArgs e)//이미지 선택
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "이미지 선택";
            openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;)|*.png;*.jpg;*.jpeg;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
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
