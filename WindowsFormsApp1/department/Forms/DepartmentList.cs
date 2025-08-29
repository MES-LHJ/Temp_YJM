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
using WindowsFormsApp1.department.Forms;
using WindowsFormsApp1.department.Model;

namespace WindowsFormsApp1
{
    public partial class DepartmentList : Form
    {
        private int departId; // 부서 ID를 저장할 변수
        private int idx;

        public DepartmentList()
        {
            InitializeComponent();
            Click_Event();
            Design();

            this.Load += DeptList_Load; // 부서 목록 로드
        }

        private void Click_Event()//버튼 클릭 이벤트
        {
            deptInsertBtn.Click += Insert_Button;// 추가 버튼
            deptDelBtn.Click += Del_Button; // 삭제 버튼
            deptUpdateBtn.Click += Update_Button; // 수정 버튼
            closeBtn.Click += Close_Btn;// 닫기 버튼
            chartBtn.Click += Chart_Btn;
        }

        private void Design()
        {
            deptListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            deptListView.ReadOnly = true;

            closeBtn.Alignment = ToolStripItemAlignment.Right;
            deptDelBtn.Alignment = ToolStripItemAlignment.Right;
            deptUpdateBtn.Alignment = ToolStripItemAlignment.Right;
            deptInsertBtn.Alignment = ToolStripItemAlignment.Right;
            chartBtn.Alignment = ToolStripItemAlignment.Right;

            deptListToolStrip.Items.Insert(1, closeBtn);
            deptListToolStrip.Items.Insert(2, chartBtn);
            deptListToolStrip.Items.Insert(3,deptDelBtn);
            deptListToolStrip.Items.Insert(4, deptUpdateBtn);
            deptListToolStrip.Items.Insert(5, deptInsertBtn);
        }

        private void Cell_Select()//셀 선택
        {
            var dept = deptListView.SelectedRows[0].DataBoundItem as DepartmentDto;
            departId = dept.departmentId;
            idx = deptListView.CurrentRow.Index;
        }

        private void DeptListRefresh()//부서 리스트 새로고침
        {
            var deptInfo = DepartmentRepository.deptRepo.GetDeptListInfo();
            deptListView.AutoGenerateColumns = false;
            deptListView.DataSource = deptInfo;
        }

        private void DeptList_Load(object sender, EventArgs e)
        {
            DeptListRefresh();
        }

        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            InsertDepartment insertDepartment = new InsertDepartment();
            if (insertDepartment.ShowDialog() == DialogResult.OK)
            {
                DeptListRefresh();
                deptListView.CurrentCell = deptListView.Rows[deptListView.RowCount-1].Cells[0];
            }
        }
        private void Update_Button(object sender, EventArgs e)//부서 수정 버튼
        {
            Cell_Select();
            Console.WriteLine(departId);
            UpdateDepartment updateDepartment = new UpdateDepartment(departId);
            if (updateDepartment.ShowDialog() == DialogResult.OK)
            {
                DeptListRefresh();
                deptListView.CurrentCell = deptListView.Rows[idx].Cells[0];
            }

        }

        private void Del_Button(object sender, EventArgs e)//부서 삭제 버튼
        {
            Cell_Select();

            DelDepartment delDepartment = new DelDepartment(departId);
            if (delDepartment.ShowDialog() == DialogResult.OK)
            {
                DeptListRefresh();
            }

        }

        private void Chart_Btn(object sender, EventArgs e)
        {
            ChartDepartment chartDepartment = new ChartDepartment(departId);
            chartDepartment.ShowDialog();
        }
        private void Close_Btn(object sender, EventArgs e)//부서 닫기 버튼
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
