using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;

namespace WindowsFormsApp1.department.Forms
{
    public partial class ChartDepartment : Form
    {
        private readonly int deptId;
        public ChartDepartment(int departId)
        {
            deptId = departId;
            InitializeComponent();
            deptChart.Dock = DockStyle.Fill;

            this.Load += ChartDept_Load;
        }

        private void ChartDept_Load(object sender, EventArgs e)
        {
            var chartInfo = DepartmentRepository.deptRepo.GetChart(deptId);
            deptChart.DataSource = chartInfo;

            foreach(var series in chartInfo)
            {
                deptChart.Series["department"].Points.AddXY(series.departmentName, series.departmentCnt);
            }
        }
    }
}
