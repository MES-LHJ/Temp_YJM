using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using WindowsFormsApp1.department.Models;
using WindowsFormsApp1.employee.Models;
using WindowsFormsApp1.Utiliity;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace WindowsFormsApp1
{
    public partial class UpdateEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();
        private Util util = new Util();//공통코드
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
            Click_Event();
            CheckBox_Event();
            ComboBox_Event();
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

            //var empInfo = EmployeeRepository.empRepo.UpdateEmpInfo(employee.employeeId);// 수정할 사원 정보 가져오기

            using (var context = new LinqContext())// 수정할 사원 정보 가져오기
            {
                var empInfo = context.Employee
                                        .Join(context.Department, a => a.departmentId, d => d.departmentId, (a, d) => new { a, d })
                                        .Join(context.img, ed => ed.a.imgId, i => i.imgId, (ed, i) => new
                                        {
                                            ed.d.departmentCode,
                                            ed.d.departmentName,
                                            ed.a.employeeName,
                                            ed.a.employeeCode,
                                            i.imgName,
                                            ed.a.loginId,
                                            ed.a.passwd,
                                            ed.a.employeeRank,
                                            ed.a.imgId,
                                            ed.a.employeeType,
                                            ed.a.phone,
                                            ed.a.email,
                                            ed.a.messId,
                                            ed.a.memo,
                                            ed.a.gender,
                                            ed.a.departmentId,
                                            ed.a.employeeId

                                        })
                                        .FirstOrDefault(emp => emp.employeeId == employee.EmployeeId);

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
                employee.DepartmentId = Convert.ToInt32(empInfo.departmentId.ToString());
                myEmpCode = empInfo.employeeCode;
                originImg = empInfo.imgName;
                employee.ImgId = Convert.ToInt32(empInfo.imgId);
                employee.Gender = (EmployeeDto.GenderType)empInfo.gender;

                string imgPath = @"C:\NAS\" + employee.ImgId + @"\" + empInfo.imgName;
                if (!string.IsNullOrEmpty(empInfo.imgName) && File.Exists(imgPath))
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

        }
        private void DepName_Change(object sender, EventArgs e)// 부서코드 변경시 부서 명 바뀌게
        {
            if (SelectDeptDto != null)
            {
                deptNameBox.Text = SelectDeptDto.DepartmentName;
            }
        }

        private void Complete_Button(object sender, EventArgs e) //수정 완료 버튼
        {

            string empCode = empCodeBox.Text;
            //var checkEmpCode = EmployeeRepository.empRepo.UpdateCheckEmpCode(empCode, myEmpCode);
            using (var context = new LinqContext())
            {
                var checkEmpCode = context.Employee
                                            .Where(a => a.employeeCode == empCode && a.employeeCode != myEmpCode)
                                            .Select(a => a.employeeCode)
                                            .FirstOrDefault();

                if (checkEmpCode != null)
                {
                    MessageBox.Show("중복된 사원코드가 존재합니다.");
                    return;
                }
            }


            try
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

                var saveFile = util.ImgSaveType();// 이미지 저장 다이얼로그
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
                if (menCheckBox.Checked)
                {
                    employee.Gender = EmployeeDto.GenderType.Male;
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
