using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private readonly EmployeeDto employee = new EmployeeDto();
        private string myEmpCode;
        private string imgFormat;
        private string originImg;

        private bool imgChange = false;


        public UpdateEmployee(int empId)
        {
            employee.employeeId = empId;
            InitializeComponent();
            Click_Event();
            Design();
            Img_Event();
        }

        private void Click_Event()
        {
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;
            updateBtn.Click += Complete_Button; // 수정 완료 버튼 클릭 이벤트 핸들러 등록
            closeBtn.Click += Close_Button; // 닫기 버튼 클릭 이벤트 핸들러 등록
            menCheckBox.CheckedChanged += MenCheck_Box;
            womenCheckBox.CheckedChanged += WomenCheck_Box;

        }
        private void Design()
        {
            deptNameBox.ReadOnly = true;
            imgUpdateBox.SizeMode = PictureBoxSizeMode.Zoom;
            imgUpdateBtn.ForeColor = Color.White;
        }
        private void Img_Event()
        {
            imgUpdateBtn.Click += Img_Update;
            imgDelBtn.Click += Img_Del;
        }
        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

            deptCodeComboBox.Items.Clear(); // 콤보박스 초기화

            var empInfo = EmployeeRepository.empRepo.UpdateEmpInfo(employee.employeeId);// 수정할 사원 정보 가져오기

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
            employee.departmentId = Convert.ToInt32(empInfo.departmentId.ToString());
            employee.gender = empInfo.gender;
            myEmpCode = empInfo.employeeCode;
            originImg = empInfo.imgName;
            employee.imgId = empInfo.imgId;


            string imgPath = @"C:\NAS\" + employee.imgId + @"\" + empInfo.imgName;
            if (!string.IsNullOrEmpty(empInfo.imgName) && File.Exists(imgPath))
            {
                imgUpdateBox.Image = Image.FromFile(imgPath);
                imgDelBtn.Visible = true;
            }
            else
            {
                //imgUpdateBox.Image.Dispose();
                //imgUpdateBox.Image = null;
                imgDelBtn.Visible = false;
            }

            if (employee.gender == EmployeeDto.GenderType.Male)
            {
                menCheckBox.Checked = true;
            }
            else if (employee.gender == EmployeeDto.GenderType.Female)
            {
                womenCheckBox.Checked = true;
            }

            var deptList = EmployeeRepository.empRepo.GetDeptCode();// 부서 코드 리스트 가져오기
            foreach (var dept in deptList)
            {
                deptCodeComboBox.Items.Add(dept.departmentCode);
            }
        }
        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {

            string deptCode = deptCodeComboBox.Text;
            var deptInfo = EmployeeRepository.empRepo.GetDeptName(deptCode);

            deptNameBox.Text = deptInfo.departmentName;
            employee.departmentId = Convert.ToInt32(deptInfo.departmentId.ToString());
        }

        private void Complete_Button(object sender, EventArgs e) //수정 완료 버튼
        {

            string employeeCode = empCodeBox.Text;
            var checkEmpCode = EmployeeRepository.empRepo.UpdateCheckEmpCode(employeeCode, myEmpCode);

            Guid nGuid = Guid.NewGuid();
            string uuid = nGuid.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "이미지 수정 완료";
            saveFileDialog.Filter = "이미지 파일 (*.png;*.jpeg;*.jpg;)|*.png;*.jpeg;*.jpg;";

            string fileName = uuid + imgFormat;

            if (checkEmpCode == 1)
            {
                MessageBox.Show("중복된 사원코드가 존재합니다.");
                return;
            }

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
                string folderPath = @"C:\NAS\" + employee.imgId;
                string imgPath = folderPath + @"\" + originImg;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (imgChange && !string.IsNullOrEmpty(originImg))
                {
                    //imgUpdateBox.Image.Dispose();
                    File.Delete(imgPath);
                }
                else if (imgUpdateBox.Image == null && !string.IsNullOrEmpty(originImg))
                {
                    File.Delete(imgPath);
                }


                if (imgUpdateBox.Image == null)
                {
                    fileName = null;

                }
                else if (imgUpdateBox.Image != null && !imgChange)
                {
                    fileName = originImg;

                }
                else if (imgChange && imgUpdateBox.Image != null)
                {
                    imgUpdateBox.Image.Save(folderPath + @"\" + fileName);

                }

                EmployeeDto empDto = new EmployeeDto
                {
                    departmentId = employee.departmentId,
                    employeeId = employee.employeeId,
                    employeeCode = empCodeBox.Text,
                    employeeName = empNameBox.Text,
                    employeeRank = empRankBox.Text,
                    employeeType = empTypeBox.Text,
                    phone = phoneBox.Text,
                    email = emailBox.Text,
                    messId = messageBox.Text,
                    memo = memoBox.Text,
                    gender = employee.gender,
                    imgName = fileName
                };

                EmployeeRepository.empRepo.UpdateEmp(empDto);
                MessageBox.Show("수정이 완료되었습니다.");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("수정 중 오류가 발생했습니다: " + ex.Message);
            }

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
        private void Img_Update(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "이미지 수정";
            openFileDialog.Filter = "이미지 파일 (*.png;*.jpeg;*.jpg;)|*.png;*.jpeg;*.jpg;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                imgFormat = Path.GetExtension(fileName).ToLower();
                imgChange = true;
                if (imgUpdateBox.Image != null)
                {
                    imgUpdateBox.Image.Dispose();
                    imgUpdateBox.Image = null;
                }


                imgUpdateBox.Image = Image.FromFile(fileName);
                imgDelBtn.Visible = true;

            }
        }
        private void Img_Del(object sender, EventArgs e)
        {
            imgUpdateBox.Image.Dispose();
            imgUpdateBox.Image = null;
            imgDelBtn.Visible = false;
            imgChange = false;
        }
        private void Close_Button(object sender, EventArgs e)// 닫기 버튼
        {
            this.Close();
        }
    }
}
