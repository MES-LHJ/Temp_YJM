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

namespace WindowsFormsApp1
{
    public partial class DepartmentList : Form
    {
        private int departId; // 부서 ID를 저장할 변수
        public DepartmentList()
        {
            InitializeComponent();

            deptIdBox.Visible = false;
            this.Load += DeptList_Load; // 부서 목록 로드
            deptInsertBtn.Click += Insert_Button;// 추가 버튼
            deptDelBtn.Click += Del_Button; // 삭제 버튼
            deptUpdateBtn.Click += Update_Button; // 수정 버튼
            closeBtn.Click += CloseBtn_Click; // 닫기 버튼
            deptListView.CellClick += Cell_Click; // 부서코드 가져오기 위해
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeptList_Load(object sender, EventArgs e)
        {
            deptListView.Rows.Clear();

            string sql = "SELECT departmentCode , departmentName, memo FROM department ORDER BY departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = deptListView.Rows.Add(); // 새로운 행 추가
                    DataGridViewRow newRow = deptListView.Rows[rowIndex]; // 새로 추가된 행을 가져옴
                    newRow.Cells["departmentCode"].Value = reader["departmentCode"];
                    newRow.Cells["departmentName"].Value = reader["departmentName"];
                    newRow.Cells["memo"].Value = reader["memo"];
                }
            }
        }

        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            InsertDepartment insertDepartment = new InsertDepartment();
            insertDepartment.ShowDialog(); // Form7을 모달로 열기
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
                updateDepartment.ShowDialog();
            }
                
        }
        private void Cell_Click(object sender, DataGridViewCellEventArgs e)//부서 id 가져오기 위해
        {
            int rowIndex = e.RowIndex; // 클릭한 행의 인덱스
            string departCode = deptListView.Rows[rowIndex].Cells["departmentCode"].Value.ToString();
            //Console.WriteLine(departCode);
            string sql = "SELECT departmentId FROM department WHERE departmentCode = '" + departCode + "'";
          
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {

                    departId = Convert.ToInt32(reader["departmentId"].ToString());
                }
                
            }
            //Console.WriteLine("222222222: " + departId);
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
                delDepartment.ShowDialog();
            }
        }
        private void Close_Btn(object sender, EventArgs e)//부서 닫기 버튼
        {
            this.Close();
        }

        private void deptListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
