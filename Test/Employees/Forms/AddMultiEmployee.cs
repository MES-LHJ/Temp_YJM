using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Repository;
using Test.Departments.Models;
using Test.Employees.Models;
using Test.Utility;


namespace Test.Employees.Forms
{
    public partial class AddMultiEmployee : Form
    {
        private string changeMainCode;//변경된 상위부서코드
        private int selectMainDeptId;//선택된 상위부서 ID
        private Pattern pattern = new Pattern();
        private ColorInfo btnColor = new ColorInfo();

        public List<DepartmentDto> MainDeptInfo => DepartmentRepository.DeptRepo.GetDeptListInfo(); //상위 정보 부서
        public List<DepartmentDto> SubDeptInfo => DepartmentRepository.DeptRepo.GetSubDeptCode2(selectMainDeptId); //하위 부서 정보
        private Worksheet AddMultiWorkSheet => addMultiSheet.Document.Worksheets[0];//엑셀 사용할 시트
        private Dictionary<string, int> MainDeptDic => MainDeptInfo.ToDictionary(d => d.DepartmentCode, d => d.DepartmentId);//상위부서 코드에 따라 상위부서명 변경
        //private Dictionary<string, DepartmentDto> SubDeptDic => SubDeptInfo.ToDictionary(d => d.SubDeptCode);//하위부서 코드에 따라 하위부서명 변경

        public AddMultiEmployee()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            this.Load += AddMultiEmployee_Load;
            addMultiSheet.CellBeginEdit += SubDeptCell_Protect;//텍스트 입력 막기 (셀편집 시작할때)
            addMultiSheet.CellValueChanged += ComboBox_ValueChange;//엑셀 콤보박스 변경 이벤트
            empInsertBtn.Click += AddMulti_Emp;//일괄추가 버튼
            cancelBtn.Click += CancelBtn_Click;//취소 버튼
            addMultiSheet.CustomCellEdit += Passwd_Custom; // 비밀번호 입력시 *
            addMultiSheet.CustomDrawCell += CustomDraw; // 셀 벗어나도 비밀번호 *
        }

        private void Design()
        {
            btnColor.ChangeSaveBtnColor(empInsertBtn);
            btnColor.ChangeCancelBtnColor(cancelBtn);
        }

        //엑셀 컬럼 추가
        private void AddMultiEmployee_Load(object sender, EventArgs e)
        {
            AddMultiWorkSheet.Cells["A1"].Value = "상위 부서코드";
            AddMultiWorkSheet.Cells["B1"].Value = "하위 부서코드";
            AddMultiWorkSheet.Cells["C1"].Value = "사원코드";
            AddMultiWorkSheet.Cells["D1"].Value = "사원명";
            AddMultiWorkSheet.Cells["E1"].Value = "로그인ID";
            AddMultiWorkSheet.Cells["F1"].Value = "비밀번호";
            AddMultiWorkSheet.Cells["G1"].Value = "직위";
            AddMultiWorkSheet.Cells["H1"].Value = "고용형태";
            AddMultiWorkSheet.Cells["I1"].Value = "성별";
            AddMultiWorkSheet.Cells["J1"].Value = "휴대전화";
            AddMultiWorkSheet.Cells["K1"].Value = "이메일";
            AddMultiWorkSheet.Cells["L1"].Value = "메신저ID";
            AddMultiWorkSheet.Cells["M1"].Value = "메모";

            AddMultiWorkSheet.Range["A:M"].AutoFitColumns();// 텍스트에 맞게 열 자동 설정
            //상위 부서 콤보박스 생성
            string deptCode = string.Join(",", MainDeptInfo.Select(d => d.DepartmentCode));
            //상위부서 코드 콤보박스
            var maindDeptCodeCombo = AddMultiWorkSheet.DataValidations.Add(AddMultiWorkSheet.Range[$"A2:A1048576"], DataValidationType.List, deptCode);
            //성별 콤보박스
            var genderCombo = AddMultiWorkSheet.DataValidations.Add(AddMultiWorkSheet.Range["I2:I1048576"], DataValidationType.List, "남,여");

            maindDeptCodeCombo.ShowErrorMessage = false;
            genderCombo.ShowErrorMessage = false;
        }

        private void Passwd_Custom(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCustomCellEditEventArgs e) // 비밀번호 입력시 *모양
        {
            if (e.ColumnIndex == 5 && e.RowIndex > 0 && e.RowIndex <= 49)
            {
                RepositoryItemTextEdit repositoryItemTextEdit = new RepositoryItemTextEdit();//특정 마스크를 주기위해서
                repositoryItemTextEdit.PasswordChar = '*';

                e.RepositoryItem = repositoryItemTextEdit;//입력창 벗어나면 text 원래대로 바뀜
            }
        }

        private void CustomDraw(object sender, DevExpress.XtraSpreadsheet.CustomDrawCellEventArgs e) // 비밀번호 셀 벗어나도 *유지
        {
            if (e.Cell.ColumnIndex == 5 && e.Cell.RowIndex > 0 && e.Cell.RowIndex <= 49)
            {
                string passReal = e.Cell.Value.ToString(); //비밀번호 원래 입력문
                if (!string.IsNullOrEmpty(passReal))
                {
                    e.Text = new string('*', passReal.Length);
                }
            }
        }

        private void SubDeptCell_Protect(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)//하위부서코드 텍스트 입력 막기
        {
            if (e.RowIndex == 0)
            {
                e.Cancel = true;
            }
        }

        private void ComboBox_ValueChange(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e) //엑셀 콤보 박스 수정시
        {
            if (e.ColumnIndex == 0)
            {
                AddMultiWorkSheet.Cells[e.RowIndex, 1].Value = "";//하위부서 초기화

                //상위 부서
                changeMainCode = AddMultiWorkSheet.Cells[e.RowIndex, e.ColumnIndex].Value.ToString();//변경된 상위부서 코드
                string subDeptCode;//콤보박스에 생성할 하위부서 코드들

                if (!string.IsNullOrEmpty(changeMainCode) && MainDeptDic.ContainsKey(changeMainCode))
                {
                    selectMainDeptId = MainDeptDic[changeMainCode];//변경된 상위부서 아이디

                    subDeptCode = string.Join(",", SubDeptInfo.Select(d => d.SubDeptCode));//하위부서 코드
                }
                else
                {
                    subDeptCode = "";
                }
                    var subDeptCombo = AddMultiWorkSheet.DataValidations.Add(AddMultiWorkSheet.Cells[e.RowIndex, 1], DataValidationType.List, subDeptCode);
                    subDeptCombo.ShowErrorMessage = false;
            }

        }

        private void AddMulti_Emp(object sender, EventArgs e) // 일괄 추가 버튼
        {
            //var range = Worksheet.GetUsedRange();
            var checkBottomRow = addMultiSheet.ActiveWorksheet.GetDataRange().BottomRowIndex;// 시트에 사용된 마지막 데이터 까지

            List<string> errMessage = new List<string>(); //에러 메시지 모음
            //List<Employee> multiInsertEmpList = new List<Employee>(); //저장할 테이블 리스트

            int cnt = 0;
            for (int row = 1; row <= checkBottomRow; row++)
            {
                var mainDeptCode = AddMultiWorkSheet.Cells[row, 0].Value.ToString();
                var subDeptCode = AddMultiWorkSheet.Cells[row, 1].Value.ToString();

                //int gender = 0;
                var mainDeptId = 0;
                var subDeptId = 0;
                if (MainDeptDic.ContainsKey(mainDeptCode))
                {
                    mainDeptId = MainDeptDic[mainDeptCode];

                    var subInfo = DepartmentRepository.DeptRepo.GetSubDeptCode2(mainDeptId);
                    var subDic = subInfo.ToDictionary(s => s.SubDeptCode);

                    if (!string.IsNullOrEmpty(subDeptCode) && subDic.ContainsKey(subDeptCode))
                    {
                        subDeptId = subDic[subDeptCode].SubDeptId;
                    }
                }
                //스프레드 시트에 담긴 값들
                var empCode = AddMultiWorkSheet[row, 2].Value.ToString();
                var empName = AddMultiWorkSheet[row, 3].Value.ToString();
                var loginId = AddMultiWorkSheet[row, 4].Value.ToString();
                var passwd = AddMultiWorkSheet[row, 5].Value.ToString();
                var empRank = AddMultiWorkSheet[row, 6].Value.ToString();
                var empType = AddMultiWorkSheet[row, 7].Value.ToString();
                var CellGender = AddMultiWorkSheet[row, 8].Value.ToString();
                var phone = AddMultiWorkSheet[row, 9].Value.ToString();
                var email = AddMultiWorkSheet[row, 10].Value.ToString();
                var messId = AddMultiWorkSheet[row, 11].Value.ToString();
                var memo = AddMultiWorkSheet[row, 12].Value.ToString();

                if (string.IsNullOrEmpty(empCode))
                {
                    errMessage.Add(row + 1 + "행의 사원 코드를 입력해주세요.");
                    continue;
                }
                if (string.IsNullOrEmpty(empName))
                {
                    errMessage.Add(row + 1 + "행의 사원명을 입력해주세요.");
                    continue;
                }
                if (string.IsNullOrEmpty(loginId))
                {
                    errMessage.Add(row + 1 + "행의 로그인ID를 입력해주세요.");
                    continue;
                }
                if (string.IsNullOrEmpty(passwd))
                {
                    errMessage.Add(row + 1 + "행의 비밀번호를 입력해주세요.");
                    continue;
                }
                if (Regex.IsMatch(passwd, pattern.PatternCheck()["passwd"]))
                {
                    errMessage.Add(row + 1 + "행의 비밀번호에 특수문자가 포함되어 있습니다.");
                    continue;
                }
                if (passwd.Length < 8)
                {
                    errMessage.Add(row + 1 + "행의 비밀번호를 8자리 이상 입력해주세요.");
                    continue;
                }
                if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, pattern.PatternCheck()["email"]))
                {
                    errMessage.Add(row + 1 + "행의 이메일 형식을 확인해주세요.");
                    continue;
                }

                var empCodeCheck = EmployeeRepository.EmpRepo.InsertEmpIdCheck(empCode); //사원코드 중복 체크
                if (empCodeCheck == 1)
                {
                    errMessage.Add(row + 1 + "행의 사원코드가 중복되었습니다.");
                    continue;
                }
                var loginIdCheck = EmployeeRepository.EmpRepo.GetInsertLoginId(loginId);
                if (loginIdCheck == 1)
                {
                    errMessage.Add(row + 1 + "행의 로그인ID가 중복입니다.");
                    continue;
                }
                //성별 선택
                EmployeeDto.GenderType gender = EmployeeDto.GenderType.noSelect;
                if (CellGender.Equals("남"))
                {
                    gender = EmployeeDto.GenderType.Male;
                }
                else if (CellGender.Equals("여"))
                {
                    gender = EmployeeDto.GenderType.Female;
                }
                //상위 부서코드 체크
                var mainCodeCheck = EmployeeRepository.EmpRepo.MainDeptCodeCheck(mainDeptId);
                if (mainCodeCheck == 0)
                {
                    errMessage.Add(row + 1 + "행의 상위부서 코드가 존재하지 않습니다.");
                    continue;
                }
                //하위 부서코드 체크
                var subCodeCheck = EmployeeRepository.EmpRepo.SubDeptCodeCheck(mainDeptId, subDeptId);
                if (subCodeCheck == 0)
                {
                    errMessage.Add(row + 1 + "행의 하위부서 코드가 존재하지 않습니다.");
                    continue;
                }

                var emp = new EmployeeDto // 데이터베이스에 보낼 사원정보 담기
                {
                    DepartmentId = mainDeptId,
                    SubDeptId = subDeptId,
                    EmployeeCode = empCode,
                    EmployeeName = empName,
                    LoginId = loginId,
                    Passwd = passwd,
                    EmployeeRank = empRank,
                    EmployeeType = empType,
                    Phone = phone,
                    Email = email,
                    MessId = messId,
                    Memo = memo,
                    Gender = gender
                };
                //사원 일괄 추가
                var insertCheck = EmployeeRepository.EmpRepo.MultiInsertEmp(emp);
                if (insertCheck == 1)
                {
                    cnt++;
                }
            }
            //에러 메시지 존재시 에러메시지 출력
            if (errMessage.Count > 0)
            {
                string err = string.Join("\n", errMessage);
                MessageBox.Show($"총 {checkBottomRow}건 중에 {cnt}건을 성공하였습니다. \n{err}");
                return;
            }
            else
            {
                MessageBox.Show("모든 사원정보가 추가 되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
