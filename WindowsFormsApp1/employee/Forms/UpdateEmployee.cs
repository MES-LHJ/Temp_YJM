using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.department.Models;
using WindowsFormsApp1.employee.Models;
using WindowsFormsApp1.Utiliity;

namespace WindowsFormsApp1
{
    public partial class UpdateEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();
        private readonly Util util = new Util();//공통코드
        private string myEmpCode;//원래 사원코드
        private string imgFormat;//이미지 확장자
        private string originImg;//원본 이미지명
        private bool imgChange = false;
        private int cnt;

        public DepartmentDto SelectDeptDto => deptCodeComboBox.SelectedItem as DepartmentDto;//선택된 부서코드 콤보박스

        public UpdateEmployee(int empId)
        {
            employee.EmployeeId = empId;

            InitializeComponent();
            Click_Event();// 버튼 클릭 이벤트
            CheckBox_Event();// 체크박스 이벤트
            ComboBox_Event();// 콤보박스 이벤트
        }

        private void Click_Event()
        {
            updateBtn.Click += Complete_Button; // 수정 완료 버튼 클릭 이벤트 핸들러 등록
            closeBtn.Click += Close_Button; // 닫기 버튼 클릭 이벤트 핸들러 등록
            imgUpdateBtn.Click += Img_Update;// 이미지 선택
            imgDelBtn.Click += Img_Del;// 이미지 x 버튼

        }
        private void ComboBox_Event()
        {
            deptCodeComboBox.SelectedIndexChanged += DepName_Change;//부서코드 변경시 부서명 바뀌게
        }

        private void CheckBox_Event()
        {
            menCheckBox.CheckedChanged += MenCheck_Box;// 남자 체크박스
            womenCheckBox.CheckedChanged += WomenCheck_Box;// 여자 체크박스
        }
        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            
            var empInfo = EmployeeRepository.EmpRepo.GetLinqUpdateEmpInfo(employee.EmployeeId);//linq 업데이트할 사원 정보

            deptCodeComboBox.Text = empInfo.DepartmentCode;
            deptNameBox.Text = empInfo.DepartmentName;
            empCodeBox.Text = empInfo.EmployeeCode;
            empNameBox.Text = empInfo.EmployeeName;
            empRankBox.Text = empInfo.EmployeeRank;
            empTypeBox.Text = empInfo.EmployeeType;
            phoneBox.Text = empInfo.Phone;
            emailBox.Text = empInfo.Email;
            messageBox.Text = empInfo.MessId;
            memoBox.Text = empInfo.Memo;
            employee.DepartmentId = Convert.ToInt32(empInfo.DepartmentId.ToString());
            myEmpCode = empInfo.EmployeeCode;
            originImg = empInfo.ImgName;
            employee.ImgId = Convert.ToInt32(empInfo.ImgId);
            employee.Gender = (EmployeeDto.GenderType)empInfo.Gender;

            string folderPath = util.ImgFolderPath() + employee.ImgId;
            string imgPath = folderPath + @"\" + empInfo.ImgName;
            if (!string.IsNullOrEmpty(empInfo.ImgName) && File.Exists(imgPath))
            {
                imgUpdateBox.Image = Image.FromFile(imgPath);
                imgDelBtn.Visible = true;
            }
            else
            {
                imgDelBtn.Visible = false;
            }

            if (employee.Gender == EmployeeDto.GenderType.Male)
            {
                menCheckBox.Checked = true;
            }
            else if (employee.Gender == EmployeeDto.GenderType.Female)
            {
                womenCheckBox.Checked = true;
            }

            var deptList = DepartmentRepository.DeptRepo.GetDeptListInfo();// 부서 정보  리스트 가져오기
            deptCodeComboBox.Items.AddRange(deptList.ToArray());// 콤보박스에 부서 코드 리스트 추가
        }


        private void DepName_Change(object sender, EventArgs e)
        {
            if (SelectDeptDto != null)
            {
                deptNameBox.Text = SelectDeptDto.DepartmentName;
            }
        }

        private void Complete_Button(object sender, EventArgs e)
        {
            string email = emailBox.Text;

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
            else if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, util.Pattern()["email"]))
            {
                MessageBox.Show("이메일 형식이 틀립니다.");
                return;
            }


            string empCode = empCodeBox.Text;
            //var checkEmpCode = EmployeeRepository.empRepo.UpdateCheckEmpCode(empCode, myEmpCode);
            using (var context = new LinqContext())
            {
                var checkEmpCode = context.Employee
                                            .Where(a => a.employeeCode == empCode && a.employeeCode != myEmpCode)
                                            .Select(a => a.employeeCode)
                                            .Any();

                if (checkEmpCode == true)
                {
                    MessageBox.Show("중복된 사원코드가 존재합니다.");
                    return;
                }
            }

            try
            {
                
                var saveFile = util.ImgSaveType();// 이미지 저장 공통코드
                string folderPath = util.ImgFolderPath() + employee.ImgId;
                string imgPath = folderPath + @"\" + originImg;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //파일 삭제 조건
                if (imgChange && !string.IsNullOrEmpty(originImg) && imgUpdateBox.Image != null) // 업데이트 사진 있을 시 원본 사진 지움
                {
                    File.Delete(imgPath);
                }
                else if (imgUpdateBox.Image == null && !string.IsNullOrEmpty(originImg) && !imgChange && cnt < 1)  //업데이트 사진 없고 원본 사진 있을 때 x 버튼
                {
                    File.Delete(imgPath);
                }

                saveFile.FileName = originImg;
                //이미지명 변경 조건
                if (imgUpdateBox.Image == null && !string.IsNullOrEmpty(originImg) && !imgChange && cnt < 1)// 업데이트 사진 없고 원본 사진 있을 때 x 버튼
                {
                    saveFile.FileName = null;

                }
                else if (imgChange && imgUpdateBox.Image != null)// 사진 변경 있을 시
                {
                    saveFile.FileName = util.Uuid() + imgFormat;
                    imgUpdateBox.Image.Save(folderPath + @"\" + saveFile.FileName);

                }
                //체크 박스 변경 시 gender 값
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

                //EmployeeDto empDto = new EmployeeDto
                //{
                //    DepartmentId = employee.DepartmentId,
                //    EmployeeId = employee.EmployeeId,
                //    EmployeeCode = empCodeBox.Text,
                //    EmployeeName = empNameBox.Text,
                //    EmployeeRank = empRankBox.Text,
                //    EmployeeType = empTypeBox.Text,
                //    Phone = phoneBox.Text,
                //    Email = emailBox.Text,
                //    MessId = messageBox.Text,
                //    Memo = memoBox.Text,
                //    Gender = employee.Gender,
                //    ImgName = fileName
                //};

                //EmployeeRepository.empRepo.UpdateEmp(empDto);
                //EmployeeRepository.empRepo.UdpateImg(empDto.imgName);
                using (var context = new LinqContext())
                {
                    var updateEmp = context.Employee.FirstOrDefault(a => a.employeeId == employee.EmployeeId);
                    if (updateEmp != null)
                    {
                        if (SelectDeptDto != null) updateEmp.departmentId = SelectDeptDto.DepartmentId;
                        else updateEmp.departmentId = employee.DepartmentId;
                        updateEmp.employeeId = employee.EmployeeId;
                        updateEmp.employeeCode = empCodeBox.Text;
                        updateEmp.employeeName = empNameBox.Text;
                        updateEmp.employeeRank = empRankBox.Text;
                        updateEmp.employeeType = empTypeBox.Text;
                        updateEmp.phone = phoneBox.Text;
                        updateEmp.email = emailBox.Text;
                        updateEmp.messId = messageBox.Text;
                        updateEmp.memo = memoBox.Text;
                        updateEmp.gender = Convert.ToInt32(employee.Gender);

                        context.SaveChanges();
                    }
                    var imgIdCheck = context.img.FirstOrDefault(i => i.imgId == employee.ImgId);
                    if (imgIdCheck != null)
                    {
                        imgIdCheck.imgName = saveFile.FileName;
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("수정이 완료되었습니다.");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("수정 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void WomenCheck_Box(object sender, EventArgs e)// 여자 체크박스
        {
            if (womenCheckBox.Checked)
            {
                menCheckBox.Checked = false;
            }

        }
        private void MenCheck_Box(object sender, EventArgs e)// 남자 체크박스
        {
            if (menCheckBox.Checked)
            {
                womenCheckBox.Checked = false;
            }
        }
        private void Img_Update(object sender, EventArgs e)// 이미지 선택
        {
            var openFile = util.ImgOpenType();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;

                imgFormat = Path.GetExtension(fileName).ToLower();
                imgChange = true;
                if (imgUpdateBox.Image != null)
                {
                    imgUpdateBox.Image.Dispose();
                    imgUpdateBox.Image = null;
                }
                cnt++;

                imgUpdateBox.Image = Image.FromFile(fileName);
                imgDelBtn.Visible = true;
            }
        }
        private void Img_Del(object sender, EventArgs e)// 이미지 x 버튼
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
