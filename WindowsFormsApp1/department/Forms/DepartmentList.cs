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
using WindowsFormsApp1.department.Model;

namespace WindowsFormsApp1
{
    public partial class DepartmentList : Form
    {
        private int departId; // 부서 ID를 저장할 변수
        DepartmentRepository deptRepo = new DepartmentRepository();
        public DepartmentList()
        {
            InitializeComponent();

           
            this.Load += DeptList_Load; // 부서 목록 로드
            deptInsertBtn.Click += Insert_Button;// 추가 버튼
            deptDelBtn.Click += Del_Button; // 삭제 버튼
            deptUpdateBtn.Click += Update_Button; // 수정 버튼
            closeBtn.Click += Close_Btn;
            deptListView.CellClick += Cell_Click; // 부서코드 가져오기 위해
        }


        private void DeptList_Load(object sender, EventArgs e)
        {

            var deptInfo = deptRepo.GetDeptListInfo();
            deptListView.AutoGenerateColumns = false;
            deptListView.DataSource = deptInfo;

            deptListView.Columns["departmentCode"].DataPropertyName = "departmentCode";
            deptListView.Columns["departmentName"].DataPropertyName = "departmentName";
            deptListView.Columns["memo"].DataPropertyName = "memo";

        }

        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            InsertDepartment insertDepartment = new InsertDepartment();
            if (insertDepartment.ShowDialog() == DialogResult.OK)
            {
                this.DeptList_Load(sender, e);
            }   
        }
        private void Update_Button(object sender, EventArgs e)//부서 수정 버튼
        {
            if (departId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                UpdateDepartment updateDepartment = new UpdateDepartment(departId);
                if (updateDepartment.ShowDialog() == DialogResult.OK)
                {
                    this.DeptList_Load(sender, e);
                }
            }
                
        }
        private void Cell_Click(object sender, DataGridViewCellEventArgs e)//부서 id 가져오기 위해
        {
            int rowIndex = e.RowIndex; // 클릭한 행의 인덱스
            string departCode = deptListView.Rows[rowIndex].Cells["departmentCode"].Value.ToString();
            //Console.WriteLine(departCode);
            var clickDeptInfo =  deptRepo.GetDeptId(departCode);
            departId = clickDeptInfo.departmentId;

        }
        private void Del_Button(object sender, EventArgs e)
        {
            if (departId == 0)
            {
                MessageBox.Show("셀을 클릭해주세요.");
                return;
            }
            else
            {
                DelDepartment delDepartment = new DelDepartment(departId);
                if(delDepartment.ShowDialog() == DialogResult.OK)
                {
                    this.DeptList_Load(sender, e);
                }
            }
        }
        private void Close_Btn(object sender, EventArgs e)//부서 닫기 버튼
        {
            this.Close();
        }
    }
}
