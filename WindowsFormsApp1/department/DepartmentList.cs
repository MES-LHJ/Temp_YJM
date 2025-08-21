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

namespace WindowsFormsApp1
{
    public partial class DepartmentList : Form
    {
        private string departId; // 부서 ID를 저장할 변수
        public DepartmentList()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string sql = "SELECT departmentId , departmentName, memo FROM department ORDER BY departmentNo";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowIndex = dataGridView1.Rows.Add(); // 새로운 행 추가
                    DataGridViewRow newRow = dataGridView1.Rows[rowIndex]; // 새로 추가된 행을 가져옴
                    newRow.Cells["department"].Value = reader["departmentId"];
                    newRow.Cells["departmentName"].Value = reader["departmentName"];
                    newRow.Cells["memo"].Value = reader["memo"];
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Insert_Button(object sender, EventArgs e)//부서 추가 버튼
        {
            AddDepartment form7 = new AddDepartment();
            form7.ShowDialog(); // Form7을 모달로 열기
        }
        private void Update_Button(object sender, EventArgs e)//부서 수정 버튼
        {
            UpdateDepartment form8 = new UpdateDepartment(departId);
            form8.ShowDialog(); // Form8을 모달로 열기
        }
        private void Cell_Click(object sender, DataGridViewCellEventArgs e)//부서 id 가져오기 위해
        {
            int rowIndex = e.RowIndex; // 클릭한 행의 인덱스
            departId = dataGridView1.Rows[rowIndex].Cells["department"].Value.ToString(); // 부서 ID를 가져옴;
        }
        private void Del_Button(object sender, EventArgs e)
        {
            DelDepartment form9 = new DelDepartment(departId);
            form9.ShowDialog();
        }
        private void Close_Btn(object sender, EventArgs e)//부서 닫기 버튼
        {
            this.Close();
        }
    }
}
