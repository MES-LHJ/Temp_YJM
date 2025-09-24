using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Svg;
using Test.Departments.Models;
using Test.Employees.Models;
using Test.Utility.Forms;

namespace Test.Departments.Forms
{
    public partial class DepartmentList : Form
    {
        public TreeListDto SelectDeptInfo => deptListTreeView.GetDataRecordByNode(deptListTreeView.FocusedNode) as TreeListDto;//트리뷰에서 선택된 행
        //private GridView gridView2 => subDeptGrid.MainView as GridView;//하위 부서 그리드뷰
        public DepartmentDto SelectSubDeptInfo => gridView2.GetFocusedRow() as DepartmentDto;//하위 부서 그리드에서 선택된 행
        private ImageClass imgClass = new ImageClass();
        public DepartmentList()
        {
            InitializeComponent();
            this.Load += DeptList_Load;
            Design();
            Event();
        }

        private void Event()
        {
            deptListTreeView.FocusedNodeChanged += SubDeptList_View;// 하위 부서 출력 변경

            subDeptInsertBtn.ItemClick += SubDept_Insert; // 하위 부서 추가 버튼
            mainDeptListBtn.ItemClick += MainDeptList_Info; // 상위 부서 조회 버튼
            deptChartBtn.ItemClick += DeptChartBtn_Click; // 차트 조회 버튼
            subDeptDelBtn.ItemClick += Del_SubDept; //하위 부서 삭제 버튼
            subDeptUpdateBtn.ItemClick += SubDeptUpdateBtn_Click;//하위 부서 업데이트
            closeBtn.ItemClick += CloseBtn_ItemClick;//닫기버튼
        }


        private void Design()
        {
            deptListSplit.SplitterPosition = deptListSplit.Width / 2;
            deptListTreeView.CollapseAll();//트리뷰 접기
            gridView2.OptionsBehavior.Editable = false;// 그리드뷰 읽기 전용

            
        }

        private void DeptRefresh()
        {
            TreeListNode focusedNode = deptListTreeView.FocusedNode;//트리리스트 포커스행
            int subDeptLastIdx = gridView2.FocusedRowHandle;// 하위부서 목록 포커스

            List<DepartmentDto> mainList = DepartmentRepository.DeptRepo.GetMainDeptInfo();  // DTO 반환
            List<DepartmentDto> subList = DepartmentRepository.DeptRepo.GetSubDeptInfo();    // DTO 반환
            List<EmployeeDto> empList = EmployeeRepository.EmpRepo.TreeListEmp();    // DTO 반환
            List<TreeListDto> allList = mainList.Select(d => new TreeListDto
            {//mainList
                Id = d.DepartmentId.ToString(),
                DepartmentCode = d.DepartmentCode,
                DepartmentName = d.DepartmentName,
                Memo = d.Memo,
            })
                                                    .Concat(subList.Select(s => new TreeListDto
                                                    {//subList
                                                        Id = $"S_{s.SubDeptId}",
                                                        ParentId = s.DepartmentId.ToString(),
                                                        DepartmentCode = s.SubDeptCode,
                                                        DepartmentName = s.SubDeptName,
                                                        Memo = s.Memo,
                                                    }))
                                                    .Concat(empList.Select(e => new TreeListDto
                                                    {//empList
                                                        ParentId = $"S_{e.SubDeptId}",
                                                        Id = $"E_{e.EmployeeId}",
                                                        DepartmentName = e.EmployeeName,
                                                        DepartmentCode = e.EmployeeCode
                                                    }))
                                                    .ToList();

            deptListTreeView.DataSource = allList;
            deptListTreeView.KeyFieldName = "Id";
            deptListTreeView.ParentFieldName = "ParentId";

            deptListTreeView.BestFitColumns();
            gridView2.BestFitColumns();

            if (focusedNode != null) deptListTreeView.FocusedNode = deptListTreeView.FindNodeByID(focusedNode.Id);//상위 부서 포커스 유지
            gridView2.FocusedRowHandle = subDeptLastIdx;//하위 부서 포커스 유지
        }
        private void DeptList_Load(object sender, EventArgs e)
        {
            var svgDoc = SvgDocument.Open(imgClass.MainImg());
            Bitmap bitmap = svgDoc.Draw();
            barImgBox.EditValue = bitmap;
            DeptRefresh();
        }

        private void MainDeptList_Info(object sender, EventArgs e)
        {
            MainDeptList mainDeptList = new MainDeptList();
            if (mainDeptList.ShowDialog() == DialogResult.OK)
            {
                DeptRefresh();
            }
        }

        private void SubDeptList_View(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (SelectDeptInfo != null)
            {
                if (e.Node != null && e.Node.ParentNode == null)//최상위 트리에만 클릭해서 정보뜨게
                {
                    var subDeptList = DepartmentRepository.DeptRepo.GetSubDeptInfo1(Convert.ToInt32(SelectDeptInfo.Id), SelectDeptInfo.DepartmentCode, SelectDeptInfo.DepartmentName);

                    subDeptGrid.DataSource = subDeptList;
                }
            }
        }

        private void SubDept_Insert(object sender, EventArgs e)
        {
            AddSubDept addSubDept = new AddSubDept();
            if (addSubDept.ShowDialog() == DialogResult.OK)
            {
                DeptRefresh();
            }
        }

        private void DeptChartBtn_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChartDepartment chartDepartment = new ChartDepartment();
            chartDepartment.ShowDialog();
        }

        private void Del_SubDept(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectDeptInfo != null && SelectSubDeptInfo != null)
            {
                DelSubDept delSubDept = new DelSubDept(SelectSubDeptInfo, SelectDeptInfo.DepartmentCode);
                if (delSubDept.ShowDialog() == DialogResult.OK)
                {
                    DeptRefresh();
                }
            }
        }

        private void SubDeptUpdateBtn_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectSubDeptInfo != null)
            {
                UpdateSubDept updateSubDept = new UpdateSubDept(SelectSubDeptInfo);
                if (updateSubDept.ShowDialog() == DialogResult.OK)
                {
                    DeptRefresh();
                }
            }
        }

        private void CloseBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
