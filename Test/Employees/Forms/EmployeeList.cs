using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Test.Departments.Forms;
using Test.Employees.Models;
using Test.Utility;
using Svg;
using Test.Utility.Forms;

namespace Test.Employees.Forms
{
    public partial class EmployeeList : Form
    {
        public List<EmployeeDto> EmpList//사원 리스트
        {
            get => empListGrid.DataSource as List<EmployeeDto>;
            set => empListGrid.DataSource = value;
        }
        //public GridView gridView1 => empListGrid.MainView as GridView;//사원 리스트 뷰
        public EmployeeDto SelectEmp => gridView1.GetFocusedRow() as EmployeeDto;//선택된 사원 정보
        private ImageClass imgClass =new ImageClass();
        public EmployeeList()
        {
            InitializeComponent();
            Event();
            Design();
        }

        private void Event()
        {
            this.Load += EmployeeList_Load;
            searchBtn.ItemClick += SearchBtn_ItemClick;

            searchBtn.ItemClick += SearchBtn_Click;//조회버튼
            addMultiBtn.ItemClick += AddMutilBtn_Click;//일괄 추가 버튼
            departmentListBtn.ItemClick += DepartmentListView;//부서 버튼
            empAddBtn.ItemClick += EmpAddBtn_Click; // 사원 추가 버튼
            empUpdateBtn.ItemClick += EmpUpdatBtn_Click;// 사원 수정 버튼
            empDelBtn.ItemClick += EmpDelBtn_Click;//사원 삭제 버튼
            updateLoginInfoBtn.ItemClick += Update_LoginInfo;//로그인 정보 수정 버튼
            excelExportBtn.ItemClick += ExcelExport; //엑셀 내보내기
        }

        private void SearchBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void Design()
        {
            gridView1.OptionsBehavior.Editable = false;// 셀 수정 불가
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            var svgDoc = SvgDocument.Open(imgClass.MainImg());
            Bitmap bmp = svgDoc.Draw();// svg라 변환 
            barImgBox.EditValue = bmp;
        }

        private void EmpRefresh() //새로고침
        {
            int LastFocuse = gridView1.FocusedRowHandle; //폼 이동전 마지막 포커스
            gridView1.BestFitColumns();// 셀 크기 텍스트에 맞게 조절
          
            EmpList = EmployeeRepository.EmpRepo.GetLinqEmpInfo();
            gridView1.FocusedRowHandle = LastFocuse;
        }

        //데이터 조회
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            EmpRefresh();
        }

        //사원 단일추가
        private void EmpAddBtn_Click(object sender, ItemClickEventArgs e) //사원 추가
        {
            AddEmployee3 addEmployee = new AddEmployee3();
            if (addEmployee.ShowDialog() == DialogResult.OK)
            {
                int newEmpId = addEmployee.insertEmpId; //추가된 사원 ID

                EmpRefresh();

                int rowIdx = gridView1.LocateByValue("EmployeeId", newEmpId);
                gridView1.FocusedRowHandle = rowIdx;
            }
        }

        //일괄추가
        private void AddMutilBtn_Click(object sender, EventArgs e) //사원 일괄 추가
        {
            AddMultiEmployee addMultiEmployee = new AddMultiEmployee();
            if (addMultiEmployee.ShowDialog() == DialogResult.OK)
            {
                EmpRefresh();
            }
        }

        private void DepartmentListView(object sender, EventArgs e) //부서 목록
        {

            DepartmentList subDepartmentList = new DepartmentList();
            if (subDepartmentList.ShowDialog() == DialogResult.OK)
            {
                EmpRefresh();
            }
        }

        private void EmpUpdatBtn_Click(Object sender, EventArgs e) //사원 수정
        {
            if (EmpList == null)
            {
                MessageBox.Show("조회버튼을 눌러주세요.");
                return;
            }
            if (SelectEmp != null)
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(SelectEmp);
                if (updateEmployee.ShowDialog() == DialogResult.OK)
                {
                    EmpRefresh();
                }
            }
        }
        private void EmpDelBtn_Click(object sender, ItemClickEventArgs e) //사원 삭제
        {
            if (EmpList == null)
            {
                MessageBox.Show("조회버튼을 눌러주세요.");
                return;
            }
            if (SelectEmp != null)
            {
                DelEmployee delEmployee = new DelEmployee(SelectEmp);
                if (delEmployee.ShowDialog() == DialogResult.OK)
                {
                    EmpRefresh();
                }
            }
        }

        private void Update_LoginInfo(object sender, ItemClickEventArgs e) //로그인 정보 수정
        {
            if (SelectEmp != null)
            {
                UpdateLoginInfo updateLoginInfo = new UpdateLoginInfo(SelectEmp);
                if (updateLoginInfo.ShowDialog() == DialogResult.OK)
                {
                    EmpRefresh();
                }
            }
        }

        private void ExcelExport(object sender, ItemClickEventArgs e) //엑셀 내보내기
        {
            EmpRefresh();

            var fileType = new FIleType();
            var saveExcelFile = fileType.ExcelExport();

            if (saveExcelFile.ShowDialog() == DialogResult.OK)
            {
                
                empListGrid.ExportToXls(saveExcelFile.FileName);//엑셀 내보내기
            }
        }
    }
}
