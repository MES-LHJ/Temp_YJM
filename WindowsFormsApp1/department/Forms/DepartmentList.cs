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
using WindowsFormsApp1.department.Models;

namespace WindowsFormsApp1
{
    public partial class DepartmentList : Form
    {
        private int idx;//셀 인덱스 번호

        public DepartmentDto Dept { get => deptListView.SelectedRows.Count > 0 ? deptListView.SelectedRows[0].DataBoundItem as DepartmentDto : null; }

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
            chartBtn.Click += Chart_Btn;// 차트 버튼
        }

        private void Design()
        {
            deptListView.AutoGenerateColumns = false;
        }

        private void DeptListRefresh()//부서 리스트 새로고침
        {
            //var deptInfo = DepartmentRepository.DeptRepo.GetDeptListInfo();
     
            using(var context = new LinqContext())
            {
                var deptListInfo = context.Department
                                            .OrderBy(d => d.departmentId)
                                            .Select(d => new DepartmentDto
                                            {   
                                                DepartmentId = d.departmentId,
                                                DepartmentCode = d.departmentCode,
                                                DepartmentName = d.departmentName,
                                                Memo = d.memo
                                            })
                                            .ToList();
                if (deptListInfo != null)
                {
                    deptListView.DataSource = deptListInfo;
                }
                else
                {
                    MessageBox.Show("등록된 부서가 없습니다.");
                    return;
                }
            } 
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
                deptListView.CurrentCell = deptListView.Rows[deptListView.RowCount - 1].Cells[0];
            }
        }
        private void Update_Button(object sender, EventArgs e)//부서 수정 버튼
        {
            if (Dept != null)
            {
                idx = deptListView.CurrentRow.Index;
            }

            UpdateDepartment updateDepartment = new UpdateDepartment(Dept.DepartmentId);
            if (updateDepartment.ShowDialog() == DialogResult.OK)
            {
                DeptListRefresh();
                if (idx > 0) deptListView.CurrentCell = deptListView.Rows[idx].Cells[0];
            }
        }

        private void Del_Button(object sender, EventArgs e)//부서 삭제 버튼
        {
            DelDepartment delDepartment = new DelDepartment(Dept.DepartmentId);
            if (delDepartment.ShowDialog() == DialogResult.OK)
            {
                DeptListRefresh();
            }
        }

        private void Chart_Btn(object sender, EventArgs e)
        {
            ChartDepartment chartDepartment = new ChartDepartment(Dept.DepartmentId);
            chartDepartment.ShowDialog();
        }
        private void Close_Btn(object sender, EventArgs e)//부서 닫기 버튼
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
