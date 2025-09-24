using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Svg;
using Test.Departments.Models;
using Test.Utility.Forms;

namespace Test.Departments.Forms
{
    public partial class MainDeptList : Form
    {
       // public GridView gridView1 => mainDeptGrid.gridView1 as GridView;
        //public int FocusHandle => gridView1.FocusedRowHandle;
        public DepartmentDto SelectDept => gridView1.GetFocusedRow() as DepartmentDto;//선택된 상위 부서
        private ImageClass imgClass = new ImageClass();
        public List<DepartmentDto> MainDeptInfo // 상위 부서 리스트
        {
            get => mainDeptGrid.DataSource as List<DepartmentDto>;
            set => mainDeptGrid.DataSource = value;
        }
        public MainDeptList()
        {
            InitializeComponent();
            Event();

            this.Load += MainDeftList_Load;
        }

        public void Event()
        {
            mainDeptUdpateBtn.ItemClick += MainUdpateBtn_Click; // 상위 부서 수정 버튼
            mainDeptDelBtn.ItemClick += MainDeltDel_Click; // 상위 부서 삭제 버튼
            mainAddBtn.ItemClick += MainAddBtn_ItemClick; // 상위 부서 추가 버튼
            closeBtn.ItemClick += CloseBtn_ItemClick; // 상위 부서 닫기 버튼
            mainChartBtn.ItemClick += MainChart_View;// 상위부서 소속 사원 차트
        }
        public void Design()
        {
            //grid
        }
        private void MainAddBtn_ItemClick(object sender, EventArgs e)
        {
            AddMainDept addMainDept = new AddMainDept();
            if (addMainDept.ShowDialog() == DialogResult.OK)
            {
                int newMainDeptId = addMainDept.newMainDeptId;//추가된 상위부서 id

                MainDept_Refresh();

                int rowIdx = gridView1.LocateByValue("DepartmentId", newMainDeptId);
                gridView1.FocusedRowHandle = rowIdx;
            }
        }

        public void MainDept_Refresh()
        {
            int lastIdx = gridView1.FocusedRowHandle;
            MainDeptInfo = DepartmentRepository.DeptRepo.GetMainDeptInfo();
            gridView1.FocusedRowHandle = lastIdx;
        }
        public void MainDeftList_Load(object sender, EventArgs e)
        {
            var svgDoc = SvgDocument.Open(imgClass.MainImg());
            Bitmap bitmap = svgDoc.Draw();//svg 파일변환
            barImgBox.EditValue = bitmap;

            MainDept_Refresh();
        }
        public void MainUdpateBtn_Click(object sender, EventArgs e)
        {

            UpdateMainDept updateMainDept = new UpdateMainDept(SelectDept);
            if (updateMainDept.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }
        public void MainDeltDel_Click(object sender, EventArgs e)
        {
            DelMainDept delMainDept = new DelMainDept(SelectDept);
            if (delMainDept.ShowDialog() == DialogResult.OK)
            {
                MainDept_Refresh();
            }
        }
        private void CloseBtn_ItemClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void MainChart_View(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChartMainDept chartMainDept = new ChartMainDept();
            if (chartMainDept.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
