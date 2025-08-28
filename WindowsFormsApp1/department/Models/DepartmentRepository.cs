using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1.department.Model
{
    public class DepartmentRepository
    {
        private static DepartmentRepository _instance = new DepartmentRepository();
        private DepartmentRepository() { }

        public static DepartmentRepository deptRepo = _instance;

        public List<DepartmentDto> GetDeptListInfo()//부서 리스트 가져오기
        {
            var list = new List<DepartmentDto>();
            string sql = "SELECT departmentCode , departmentName, memo, departmentId FROM department ORDER BY departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DepartmentDto
                    {
                        departmentCode = reader["departmentCode"].ToString(),
                        departmentName = reader["departmentName"].ToString(),
                        memo = reader["memo"].ToString(),
                        departmentId = Convert.ToInt32(reader["departmentId"].ToString())
                    });
                }
            }
            return list;
        }

        public DepartmentDto GetDeptId(string departmentCode)//부서코드로 부서ID 가져오기
        {
            string sql = "SELECT departmentId FROM department WHERE departmentCode = @departmentCode";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DepartmentDto
                    {
                        departmentId = Convert.ToInt32(reader["departmentId"].ToString())
                    };
                }

            }
            return null;
        }

        public int InsertDeptCodeCheck(string departmentCode)//부서코드 중복체크
        {
            string deptCodeCheckSql = "SELECT departmentCode FROM department WHERE departmentCode = @departmentCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(deptCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public int UpdateDeptCodeCheck(string departmentCode, string myDeptCode)//부서코드 중복체크
        {
            string deptCodeCheckSql = "SELECT departmentCode FROM department WHERE departmentCode = @departmentCode AND departmentCode <> @myDeptCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(deptCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);
                cmd.Parameters.AddWithValue("@myDeptCode", myDeptCode);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public int InsertDepartment(DepartmentDto departmentDto)//부서 추가
        {
            string sql = "INSERT INTO department (departmentCode, departmentName, memo) " +
                             "VALUES (@departmentCode, @departmentName, @memo)";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentDto.departmentCode);
                cmd.Parameters.AddWithValue("@departmentName", departmentDto.departmentName);
                cmd.Parameters.AddWithValue("@memo", departmentDto.memo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)
                {
                    return 1;
                }
            }
            return 0;
        }

        public DepartmentDto DepartmentInfo(int departId)//부서 상세정보
        {
            string sql = "SELECT departmentCode, departmentName, memo FROM department WHERE departmentId=@departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", departId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new DepartmentDto
                    {
                        departmentCode = reader["departmentCode"].ToString(),
                        departmentName = reader["departmentName"].ToString(),
                        memo = reader["memo"].ToString()
                    };

                }
            }
            return null;
        }
        public int CheckEmployee(int deptId)
        {
            string sql = "SELECT employeeId FROM employee WHERE departmentId = @departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }return 0;
        }
        public int DelDepartment(int deptId)//부서 삭제
        {
            string sql = "DELETE FROM department WHERE departmentId = @departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)
                {
                    return 1;
                }
            }
            return 0;
        }

        public int UpdateDept(DepartmentDto deptDto)//부서 수정
        {
            string sql = "UPDATE department SET departmentCode = @departmentCode, departmentName = @departmentName, memo = @memo " +
                    "WHERE departmentId = @departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", deptDto.departmentCode);
                cmd.Parameters.AddWithValue("@departmentName", deptDto.departmentName);
                cmd.Parameters.AddWithValue("@memo", deptDto.memo);
                cmd.Parameters.AddWithValue("@departmentId", deptDto.departmentId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public List<DepartmentDto> GetChart(int deptId)//차트
        {
            var list = new List<DepartmentDto>();
            string chartSql = "SELECT d.departmentName, count(*) AS CNT FROM employee e JOIN department d ON e.departmentId = d.departmentId GROUP BY d.departmentName";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(chartSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DepartmentDto
                    {
                        departmentName = reader["departmentName"].ToString(),
                        departmentCnt = Convert.ToInt32(reader["CNT"].ToString())
                    });
                }

            }
            return list;
        }
    }
}
