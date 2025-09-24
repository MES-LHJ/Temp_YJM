using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class ChartDepartment : Form
    {

        public Dictionary<int, string> departmentIdToNameMap = new Dictionary<int, string>();//부서 아이디와 이름 매핑해서 x축 변경하기 위해
        public List<DepartmentDto> ChartList => DepartmentRepository.DeptRepo.GetTestChart();//차트에 표시할 부서 리스트
        public ChartDepartment()
        {
            InitializeComponent();
            Event();
        }

        private void Event()
        {
            this.Load += ChartDepartment_Load;

            //deptChart.CustomDrawAxisLabel += DeptChart_CustomDrawAxisLabel;// 차트 x축 라벨명 바꾸기 위해서
            //deptChart.CustomDrawCrosshair += DeptChart_CustomDrawCrosshair; // 툴팁 타이틀명 바꾸기 위해서
        }

        private void ChartDepartment_Load(object sender, EventArgs e)
        {
            deptChart.Series.Clear();

            var sortChartList = ChartList.OrderBy(x => x.DepartmentId)
                                            .ToList();

            departmentIdToNameMap = sortChartList.GroupBy(x => x.DepartmentId).ToDictionary(g => g.Key, g => g.First().DepartmentName);
            //하위부서 <아이디,name> dictionary
            Dictionary<int, string> subDeptIdToSubNameMap = sortChartList.GroupBy(x => x.SubDeptId).ToDictionary(g => g.Key, g => g.First().SubDeptName);

            deptChart.DataSource = sortChartList;

            deptChart.SeriesDataMember = "SubDeptId";//시리즈
            deptChart.SeriesTemplate.ArgumentDataMember = "DepartmentId";//x축
            deptChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "DepartmentCnt" });//y축

            deptChart.SeriesTemplate.View = new StackedBarSeriesView();// 차트 스택바 형식
            deptChart.SeriesTemplate.ArgumentScaleType = ScaleType.Qualitative;// deptId가 숫자형식이라 카테고리 식으로 바꿔서 자동생성 안되게

            deptChart.CrosshairOptions.GroupHeaderPattern = "{DepartmentName}"; //툴팁 타이틀 변경
            deptChart.SeriesTemplate.CrosshairLabelPattern = "{SubDeptName} : {V}명";//툴팁 안에 내용 변경

            // Legend Text 변경
            deptChart.Series.Cast<Series>().ToList().ForEach(s =>
            {
                if (subDeptIdToSubNameMap.TryGetValue(Convert.ToInt32(s.Name), out string subDeptName)) s.LegendTextPattern = subDeptName;
            });

            XYDiagram diagram = (XYDiagram)deptChart.Diagram;
            //x축 Label명 변경
            departmentIdToNameMap.ToList().ForEach(x => diagram.AxisX.CustomLabels.Add(new CustomAxisLabel { AxisValue = x.Key, Name = x.Value }));

            //this.Controls.Add(deptChart);
        }

        //private void DeptChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        //{

        //    var mainDeptId = Convert.ToInt32(e.Item.AxisValue);

        //    if (departmentIdToNameMap.TryGetValue(mainDeptId, out string mainDeptName)) //departmentId가 있으면 departmentName 값 나오게
        //    {
        //        e.Item.Text = mainDeptName;
        //    }
        //}

        //private void DeptChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        //{
        //    foreach (var ele in e.CrosshairElementGroups)
        //    {

        //        var header = ele.HeaderElement;//마우스 오버 시 툴팁이 있는지 확인
        //        if (header != null)
        //        {
        //            var firstEle = ele.CrosshairElements.FirstOrDefault();//그리고 그 리스트 중 첫번쨰 요소
        //            if (firstEle != null)
        //            {
        //                string originText = firstEle.SeriesPoint.Argument.ToString();//대상의 x축(argument)의 값
        //                string displayText = originText;

        //                if (departmentIdToNameMap.TryGetValue(Convert.ToInt32(originText), out string DepartName))
        //                {
        //                    displayText = DepartName;
        //                }
        //                header.Text = displayText;
        //            }
        //        }
        //    }
        //}


    }
}
