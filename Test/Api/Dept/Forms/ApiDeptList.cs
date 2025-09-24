using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Svg;
using Test.Api.Dept.Dtos;
using Test.Utility.Forms;
namespace Test.Api.Dept.Forms
{
    public partial class ApiDeptList : Form
    {   
        private readonly ImageClass imgClass = new ImageClass();
        public List<DeptListDto> deptList;//부서 리스트
        public DeptListDto SelectDept => gridView1.GetFocusedRow() as DeptListDto;//그리드뷰에서 선택된 부서
        public ApiDeptList()
        {
            InitializeComponent();
            Event();
            Design();
        }
        private void Event()
        {
            this.Load += ApiDeptList_Load;
            insertBtn.Click += Insert_Dept;//추가버튼 클릭
            updateBtn.Click += UpdateBtn_Click;//수정버튼 클릭
            delBtn.Click += DelBtn_Click;//삭제버튼 클릭
            closeBtn.Click += CloseBtn_Click;//닫기버튼 클릭
        }

        private void Design()
        {
            new[] { insertBtn, updateBtn, delBtn, closeBtn }
                            .ToList().ForEach(x => x.ButtonStyle = BorderStyles.NoBorder);//버튼 테두리 없애기

            deptListGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            deptListGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

        }

        private async Task Dept_Refresh()
        {
            deptList = await DeptRepository.DepartmentRepo.GetDepartmentCode();//부서 리스트 불러오기
            var lastFocus = gridView1.FocusedRowHandle;
            deptListGrid.DataSource = deptList;
            gridView1.FocusedRowHandle = lastFocus;
        }

        private async void ApiDeptList_Load(object sender, EventArgs e)
        {
            var svgDoc = SvgDocument.Open(imgClass.MainImg());
            Bitmap bmp = svgDoc.Draw();// svg라 변환 
            mainImgBox.EditValue = bmp;
            await Dept_Refresh();
        }

        private async void Insert_Dept(object sender, EventArgs e)
        {
            ApiInsertDept apiInsertDept = new ApiInsertDept();
            if (apiInsertDept.ShowDialog() == DialogResult.OK)
            {
                long newDeptId = apiInsertDept.deptId;
                await Dept_Refresh();
                int rowIdx = gridView1.LocateByValue("Id", newDeptId);
                //Console.WriteLine("111111111111111111row: " + rowIdx);
                gridView1.FocusedRowHandle = rowIdx;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (SelectDept != null)
            {
                ApiUpdateDept apiUpdateDept = new ApiUpdateDept(SelectDept);
                if (apiUpdateDept.ShowDialog() == DialogResult.OK)
                {
                    var lastFocus = gridView1.FocusedRowHandle; // 업데트한 부서 포커스
                    await Dept_Refresh();
                    gridView1.FocusedRowHandle = lastFocus;
                }
            }
        }

        private async void DelBtn_Click(object sender, EventArgs e)
        {
            if (SelectDept != null)
            {
                ApiDelDept apiDelDept = new ApiDelDept(SelectDept);
                if (apiDelDept.ShowDialog() == DialogResult.OK)
                {
                    await Dept_Refresh();
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
