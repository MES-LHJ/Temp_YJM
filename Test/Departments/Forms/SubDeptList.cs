using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class SubDeptList : Form
    {

        public List<DepartmentDto> MainDeptInfo
        {
            get => mainDeptGrid.DataSource as List<DepartmentDto>;
            set => mainDeptGrid.DataSource = value;
        }
        public List<DepartmentDto> SubDeptInfo
        {
            get => subDeptGrid.DataSource as List<DepartmentDto>;
            set => subDeptGrid.DataSource = value;
        }
        private GridView MainDeptGridView => mainDeptGrid.MainView as GridView;//상위 부서 그리드뷰
        public DepartmentDto SelectMainDept => MainDeptGridView.GetFocusedRow() as DepartmentDto;//상위 부서 그리드에서 선택된 행
        private GridView SubDeptView => subDeptGrid.MainView as GridView;//하위 부서 그리드뷰
        public DepartmentDto SelectSubDeptInfo => SubDeptView.GetFocusedRow() as DepartmentDto;//하위 부서 그리드에서 선택된 행
        public SubDeptList()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            this.Load += SubDeptList_Load;
            MainDeptGridView.FocusedRowChanged += Select_MainDept;
            subDeptInsertBtn.ItemClick += SubDept_Insert; // 하위 부서 추가 버튼
            mainDeptListBtn.ItemClick += MainDeptList_Info; // 상위 부서 조회 버튼
            deptChartBtn.ItemClick += DeptChartBtn_Click; // 차트 조회 버튼
            subDeptDelBtn.ItemClick += Del_SubDept; //하위 부서 삭제 버튼
            subDeptUpdateBtn.ItemClick += SubDeptUpdateBtn_Click;//하위 부서 업데이트
            treeLIstBtn.ItemClick += View_TreeList;//트리리스트 버튼
            closeBtn.ItemClick += CloseBtn_Click;//닫기 버튼
        }

        private void Design()
        {
            deptListSplit.SplitterPosition = deptListSplit.Width / 2;
            SubDeptView.OptionsBehavior.Editable = false;
        }
        private void MainDept_Refresh()
        {
            int mainDeptFocus = MainDeptGridView.FocusedRowHandle;
            int subDeptFocus = SubDeptView.FocusedRowHandle;

            MainDeptInfo = DepartmentRepository.DeptRepo.GetMainDeptInfo();
            SubDeptInfo = DepartmentRepository.DeptRepo.GetSubDeptInfo1(SelectMainDept.DepartmentId, SelectMainDept.DepartmentCode, SelectMainDept.DepartmentName);

            MainDeptGridView.FocusedRowHandle = mainDeptFocus;
            SubDeptView.FocusedRowHandle = subDeptFocus;
        }
        private void SubDeptList_Load(object sender, EventArgs e)
        {
            MainDept_Refresh();
        }
        private void Select_MainDept(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SubDeptInfo = DepartmentRepository.DeptRepo.GetSubDeptInfo1(SelectMainDept.DepartmentId, SelectMainDept.DepartmentCode, SelectMainDept.DepartmentName);
        }
        private void MainDeptList_Info(object sender, EventArgs e)
        {
            MainDeptList mainDeptList = new MainDeptList();
            if (mainDeptList.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }
        private void SubDept_Insert(object sender, EventArgs e)
        {
            AddSubDept addSubDept = new AddSubDept();
            if (addSubDept.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }

        private void DeptChartBtn_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChartDepartment chartDepartment = new ChartDepartment();
            chartDepartment.ShowDialog();
        }

        private void Del_SubDept(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DelSubDept delSubDept = new DelSubDept(SelectSubDeptInfo, SelectMainDept.DepartmentCode);
            if (delSubDept.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }

        private void SubDeptUpdateBtn_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateSubDept updateSubDept = new UpdateSubDept(SelectSubDeptInfo);
            if (updateSubDept.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }

        private void View_TreeList(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListDept treeListDept = new TreeListDept();
            if(treeListDept.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void CloseBtn_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
