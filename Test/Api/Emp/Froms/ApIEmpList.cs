using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Svg;
using Test.Api.Dept.Forms;
using Test.Api.Emp.Dtos;
using Test.Api.Emp.Froms;
using Test.Utility.Forms;

namespace Test.Api.Emp.Forms
{
    public partial class ApiEmpList : Form
    {
        //private int pageSize = 10;
        //private int pageIdx = 0;
        //private int total = 0;
        //private int totalPage = 0;
        public EmpListDto SelectEmp => gridView1.GetFocusedRow() as EmpListDto; //그리드뷰에서 선택된 사원
        private readonly ImageClass imgClass = new ImageClass();
        public ApiEmpList()
        {
            InitializeComponent();

            Event();
            Design();
        }
        private void Event()
        {
            this.Load += ApiEmpList_Load;
            deptListBtn.Click += DeptListBtn_Click;//부서페이지 이동 버튼
            searchBtn.Click += SearchBtn_Click;//조회버튼
            insertBtn.Click += InsertBtn_Click;//추가버튼
            updateBtn.Click += UpdateBtn_Click;//수정버튼
            delBtn.Click += DelBtn_Click;//삭제버튼
        }

        private void ApiEmpList_Load(object sender, EventArgs e)
        {
            var svgDoc = SvgDocument.Open(imgClass.MainImg());
            Bitmap bmp = svgDoc.Draw();// svg라 변환 
            mainImgBox.EditValue = bmp;
        }

        private void Design()
        {
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;

            new[] { deptListBtn, searchBtn, insertBtn, updateBtn, delBtn }
                        .ToList().ForEach(btn => btn.ButtonStyle = BorderStyles.NoBorder);//버튼 테두리 없애기

            apiEmpGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            apiEmpGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;//그리드뷰 사용자 속성우선 적용하기 위해서
        }

        private async Task EmpList_Refresh()
        {
            var empList = await EmpRepository.EmpRepo.GetEmpList();//사원 리스트 불러오기
            
            //total = empList.Count;
            //totalPage = (int)Math.Ceiling((double)total / pageSize);

            //var pageData = empList.OrderBy(x=>x.Id)
            //                        .Skip(pageIdx *  pageSize) // 0페이지면 0-9, 1페이지면 10-19
            //                        .Take(pageSize) // 한페이지당 
            //                        .ToList();

            apiEmpGrid.DataSource = empList;
           
        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            await EmpList_Refresh();
        }

        private async void InsertBtn_Click(object sender, EventArgs e)
        {
            ApiInsertEmp apiInsertEmp = new ApiInsertEmp();
            if (apiInsertEmp.ShowDialog() == DialogResult.OK)
            {
                long newEmpId = apiInsertEmp.empId; //추가된 사원 ID

                await EmpList_Refresh();
                int rowIdx = gridView1.LocateByValue("Id", newEmpId);
                //MessageBox.Show(rowIdx.ToString());
                gridView1.FocusedRowHandle = rowIdx;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (SelectEmp != null)
            {
                ApiUdpateEmp apiUdpateEmp = new ApiUdpateEmp(SelectEmp);

                if (apiUdpateEmp.ShowDialog() == DialogResult.OK)
                {
                    var lastFocus = gridView1.FocusedRowHandle;
                    await EmpList_Refresh();
                    gridView1.FocusedRowHandle = lastFocus;
                }
            }
        }

        private async void DelBtn_Click(object sender, EventArgs e)
        {
            if (SelectEmp != null)
            {
                ApiDelEmp apiDelEmp = new ApiDelEmp(SelectEmp);
                if (apiDelEmp.ShowDialog() == DialogResult.OK)
                {
                    await EmpList_Refresh();
                }
            }
        }

        private async void DeptListBtn_Click(object sender, EventArgs e)
        {
            ApiDeptList apiDeptList = new ApiDeptList();
            if (apiDeptList.ShowDialog() == DialogResult.OK)
            {
                await EmpList_Refresh();
            }
        }
    }
}
