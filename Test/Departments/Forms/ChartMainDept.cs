using System.Windows.Forms;
using DevExpress.XtraCharts;
using Test.Departments.Models;

namespace Test.Departments.Forms
{
    public partial class ChartMainDept : Form
    {
        public ChartMainDept()
        {
            InitializeComponent();

            this.Load += ChartMainDept_Load;
        }

        private void ChartMainDept_Load(object sender, System.EventArgs e)
        {
            var charList = DepartmentRepository.DeptRepo.GeChartLinq();
            mainChart.Series.Clear();
            foreach (var info in charList)
            {   
                Series series = new Series(info.DepartmentName, ViewType.Bar);

                series.Points.Add(new SeriesPoint(info.DepartmentId, info.Count));//시리즈에 데이터 추가
                mainChart.Series.Add(series);
            }

        }
    }
}
