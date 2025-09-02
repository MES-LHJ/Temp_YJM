using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using WindowsFormsApp1.department.Models;
using WindowsFormsApp1.employee;
using WindowsFormsApp1.employee.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class EmployeeList : Form
    {
        private string myLoginId;//수정할 로그인 아이디
        private int idx;//선택된 행 인덱스

        //선택된 행의 사원 정보
        public EmployeeDto Emp { get => empListView.SelectedRows.Count > 0 ? empListView.SelectedRows[0].DataBoundItem as EmployeeDto : null; }


        public EmployeeList()
        {
            InitializeComponent();
            Click_Event();
            Design();
        }
        private void Click_Event()//버튼 클릭 이벤트
        {
            deptListBtn.Click += Department_Button; //부서 리스트 버튼
            empListBtn.Click += Search_Button; //조회 버튼
            empAddBtn.Click += Add_Button; //사원 추가 버튼
            empUpdateBtn.Click += Update_Button;//사원 정보 수정 버튼
            empDelBtn.Click += Delete_Button;//사원 삭제 버튼
            closeBtn.Click += Close_Btn;//닫기 버튼
            loginInfoBtn.Click += UpdateLoginInfo_Page;//id.passwd 변경 페이지이동
            excelExportBtn.Click += Excel_Export;//엑셀 내보내기 버튼
        }

        private void Design()
        {
            empListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            empListView.ReadOnly = true;
            empListView.AutoGenerateColumns = false;
        }

        private void EmpListRefresh()//사원 리스트 새로고침
        {
            using (var context = new LinqContext())
            {
                var list = context.Employee
                                    .Join(context.Department, e => e.departmentId, d => d.departmentId, (e, d) => new { e, d })
                                    .Join(context.img, ed => ed.e.imgId, i => i.imgId, (ed, i) => new EmployeeDto
                                    {
                                        EmployeeCode = ed.e.employeeCode,
                                        EmployeeName = ed.e.employeeName,
                                        LoginId = ed.e.loginId,
                                        Passwd = ed.e.passwd,
                                        EmployeeRank = ed.e.employeeRank,
                                        EmployeeType = ed.e.employeeType,
                                        Phone = ed.e.phone,
                                        Email = ed.e.email,
                                        MessId = ed.e.messId,
                                        Memo = ed.e.memo,
                                        EmployeeId = ed.e.employeeId,
                                        DepartmentCode = ed.d.departmentCode,
                                        DepartmentName = ed.d.departmentName,
                                        ImgId = i.imgId
                                    })
                                    .OrderBy(emp => emp.EmployeeId)
                                    .ToList();

                empListView.DataSource = list;
                if(Emp != null)
                {
                    myLoginId = Emp.LoginId;
                }
               
            }
        }

        //private void Cell_Select()//선택된 셀의 사원Id
        //{
        //    if (emp != null)
        //    {
        //        myLoginId = emp.loginId;
        //       idx = empListView.CurrentRow.Index;
        //    }
        //}

        private void Search_Button(object sender, EventArgs e) //조회 버튼 클릭
        {
            EmpListRefresh();

        }

        private void Add_Button(object sender, EventArgs e) //추가 버튼 클릭
        {   
            InsertEmployee insertEmployee = new InsertEmployee();
            if (insertEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
                empListView.CurrentCell = empListView.Rows[empListView.RowCount-1].Cells[0];
            }
        }

        private void Update_Button(object sender, EventArgs e) //수정 버튼 클릭
        {
            if (Emp != null)
            {
                idx = empListView.CurrentRow.Index;
            }
            //Cell_Select();
            if (Emp != null)
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(Emp.EmployeeId);
                if (updateEmployee.ShowDialog() == DialogResult.OK)
                {
                    EmpListRefresh();
                    if (idx > 0) empListView.CurrentCell = empListView.Rows[idx].Cells[0];
                }
            }
            else
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }
        }

        private void UpdateLoginInfo_Page(object sender, EventArgs e)//id.passwd 변경 버튼 클릭
        {
            if (Emp != null)
            {
                idx = empListView.CurrentRow.Index;
            }
            if (Emp.EmployeeId == 0)
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }
            UpdateLoginInfo updateLoginInfo = new UpdateLoginInfo(Emp.EmployeeId, myLoginId);
            if (updateLoginInfo.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
                if (idx > 0) empListView.CurrentCell = empListView.Rows[idx].Cells[0];
            }
        }

        private void Delete_Button(object sender, EventArgs e) //삭제 버튼 클릭
        {
            if (Emp.EmployeeId == 0)
            {
                MessageBox.Show("조회 버튼을 눌러주세요.");
                return;
            }

            DelEmployee delEmployee = new DelEmployee(Emp.EmployeeId);
            if (delEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
            }
        }

        private void Department_Button(object sender, EventArgs e) //부서 버튼
        {
            DepartmentList departmentList = new DepartmentList();
            if (departmentList.ShowDialog() == DialogResult.OK)
            {
                EmpListRefresh();
            }
        }
        private void Excel_Export(object sender, EventArgs e) //엑셀 내보내기 버튼 클릭
        {
            EmpListRefresh();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = ".xlsx | *.xlsx";
                saveFileDialog.FileName = "기본";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable();//엑셀로 내보낼 데이터 테이블 생성
                    foreach (DataGridViewColumn col in empListView.Columns)
                    {
                        dt.Columns.Add(col.HeaderText);//컬럼명 추가
                    }
                    foreach (DataGridViewRow row in empListView.Rows)
                    {
                        DataRow dataRow = dt.NewRow();//새로운 행 추가
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dataRow[cell.ColumnIndex] = cell.Value;//셀 값 추가
                        }
                        dt.Rows.Add(dataRow);//행 추가
                    }
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        workbook.Worksheets.Add(dt, "EmployeeList");//데이터 테이블을 워크시트로 추가

                        try
                        {
                            MessageBox.Show("엑셀 저장에 성공하였습니다.");

                            workbook.SaveAs(saveFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("엑셀 저장에 실패하였습니다." + ex.Message);
                        }
                    }
                }
            }
        }
        private void Close_Btn(object sender, EventArgs e)//닫기 버튼 클릭
        {
            this.Close();
        }
    }
}
