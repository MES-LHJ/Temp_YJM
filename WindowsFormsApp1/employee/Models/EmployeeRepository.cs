using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1.employee.Model
{
    public class EmployeeRepository
    {

        public List<EmployeeDto> GetEmpList()//사원 리스트 가져오기
        {
            var list = new List<EmployeeDto>();
            string employeeInfoSql = "SELECT b.departmentCode, b.departmentName, a.employeeCode, a.employeeName, a.loginId, a.passwd, a.employeeRank," +
               "a.employeeType, a.phone, a.email, a.messId, a.memo, a.employeeId FROM employee a JOIN department b on a.departmentId = b.departmentId " +
               "Order by employeeId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(employeeInfoSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new EmployeeDto
                    {
                        departmentCode = reader["departmentCode"].ToString(),
                        departmentName = reader["departmentName"].ToString(),
                        employeeCode = reader["employeeCode"].ToString(),
                        employeeName = reader["employeeName"].ToString(),
                        loginId = reader["loginId"].ToString(),
                        passwd = reader["passwd"].ToString(),
                        employeeRank = reader["employeeRank"].ToString(),
                        employeeType = reader["employeeType"].ToString(),
                        phone = reader["phone"].ToString(),
                        email = reader["email"].ToString(),
                        messId = reader["messId"].ToString(),
                        memo = reader["memo"].ToString(),
                        employeeId = Convert.ToInt32(reader["employeeId"])
                    });
                }
            }
            return list;
        }

        public List<EmployeeDto> GetDeptCode()//부서코드 가져오기
        {
            var list = new List<EmployeeDto>();
            string sql = "SELECT departmentCode from department ORDER BY departmentId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new EmployeeDto
                    {
                        departmentCode = reader["departmentCode"].ToString()
                    });
                }
            }
            return list;
        }

        public EmployeeDto GetDeptName(string departmentCode)//부서명, 부서ID 가져오기
        {
            string sql = "SELECT departmentId,departmentName FROM department WHERE departmentCode=@departmentCode";
            var list = new List<EmployeeDto>();
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    return new EmployeeDto
                    {
                        departmentName = reader["departmentName"].ToString(),
                        departmentId = Convert.ToInt32(reader["departmentId"].ToString()),
                        cnt = 1

                    };

                }

            }
            return null;
        }

        public EmployeeDto GetEmpCode(string empCode)//사원코드 중복 체크
        {
            string empCodeCheckSql = "SELECT employeeCode,employeeId,loginId FROM employee WHERE employeeCode = @empCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))//사원코드 중복 체크
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(empCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@empCode", empCode);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new EmployeeDto
                    {
                        employeeCode = reader["employeeCode"].ToString(),
                        employeeId = Convert.ToInt32(reader["employeeId"].ToString()),
                        loginId = reader["loginid"].ToString(),
                        cnt = 1
                    };
                }
            }
            return null;
        }
        public int GetInsertLoginId(string loginId)//로그인ID 중복 체크
        {
            string logIdCheckSql = "SELECT loginId FROM employee WHERE loginId = @logId ";
            using (SqlConnection conn = new SqlConnection(Server.connStr))//로그인 Id 중복체크
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(logIdCheckSql, conn);
                cmd.Parameters.AddWithValue("@logId", loginId);
               
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }


        public int GetLoginId(string loginId, string myLoginId)//로그인ID 중복 체크
        {
            string logIdCheckSql = "SELECT loginId FROM employee WHERE loginId = @logId AND loginId <> @myLoginId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(logIdCheckSql, conn);
                cmd.Parameters.AddWithValue("@logId", loginId);
                cmd.Parameters.AddWithValue("@myLoginId", myLoginId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public void InsertEmpInfo(EmployeeDto empDto)//사원정보 추가
        {
            string insertEmpsql = "INSERT INTO employee (departmentId, employeeCode, employeeName, loginId, passwd, employeeRank, employeeType, phone, email, messId, memo, gender) " +
                         "VALUES (@departmentId, @employeeCode, @employeeName, @loginId, @passwd, @employeeRank, @employeeType, @phone, @email, @messId, @memo, @gender)";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertEmpsql, conn);
                cmd.Parameters.AddWithValue("@departmentId", empDto.departmentId);
                cmd.Parameters.AddWithValue("@employeeCode", empDto.employeeCode);
                cmd.Parameters.AddWithValue("@employeeName", empDto.employeeName);
                cmd.Parameters.AddWithValue("@loginId", empDto.loginId);
                cmd.Parameters.AddWithValue("@passwd", empDto.passwd);
                cmd.Parameters.AddWithValue("@employeeRank", empDto.employeeRank);
                cmd.Parameters.AddWithValue("@employeeType", empDto.employeeType);
                cmd.Parameters.AddWithValue("@phone", empDto.phone);
                cmd.Parameters.AddWithValue("@email", empDto.email);
                cmd.Parameters.AddWithValue("@messId", empDto.messId);
                cmd.Parameters.AddWithValue("@memo", empDto.memo);
                cmd.Parameters.AddWithValue("@gender", empDto.gender);
                cmd.ExecuteNonQuery();

            }
        }

        public EmployeeDto empDelInfo(int empId)//사원 삭제시 사원명, 사원코드 가져오기
        {
            string sql = "SELECT employeeCode , employeeName FROM employee WHERE employeeId =@employeeId"
                ;
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("employeeId", empId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new EmployeeDto
                    {
                        employeeCode = reader["employeeCode"].ToString(),
                        employeeName = reader["employeeName"].ToString()
                    };
                }
            }
            return null;
        }

        public int DelEmp(int empId)//사원 삭제
        {
            string sql = "DELETE FROM employee WHERE employeeId =  @employeeId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", empId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)// 1개이상 영향을 받았을 때
                {
                    return 1;
                }

            }
            return 0;
        }
        public EmployeeDto UpdateEmpInfo(int employeeId)//사원정보 수정
        {
            string sql = "SELECT b.departmentCode, b.departmentName, a.employeeName, a.employeeCode, a.loginId, a.passwd, a.employeeRank," +
                "a.employeeType, a.phone, a.email, a.messId, a.memo, a.gender, a.departmentId FROM employee a JOIN department b on a.departmentId = b.departmentId " +
                "WHERE employeeId=@employeeId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new EmployeeDto
                    {
                        departmentCode = reader["departmentCode"].ToString(),
                        departmentName = reader["departmentName"].ToString(),
                        employeeCode = reader["employeeCode"].ToString(),
                        employeeName = reader["employeeName"].ToString(),
                        loginId = reader["loginId"].ToString(),
                        passwd = reader["passwd"].ToString(),
                        employeeRank = reader["employeeRank"].ToString(),
                        employeeType = reader["employeeType"].ToString(),
                        phone = reader["phone"].ToString(),
                        email = reader["email"].ToString(),
                        messId = reader["messId"].ToString(),
                        memo = reader["memo"].ToString(),
                        gender = Convert.ToInt32(reader["gender"].ToString()),
                    };
                }
            }
            return null;
        }
        public int UpdateCheckEmpCode(string employeeCode, string myEmpCode)//사원코드 중복 체크(수정시)
        {
            string empCodeCheckSql = "SELECT employeeCode FROM employee WHERE employeeCode = @empCode ANd employeeCode <> @myEmpCode";
            using (SqlConnection conn = new SqlConnection(Server.connStr))//사원코드 중복체크
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(empCodeCheckSql, conn);
                cmd.Parameters.AddWithValue("@empCode", employeeCode);
                cmd.Parameters.AddWithValue("@myEmpCode", myEmpCode);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public int UpdateEmp(EmployeeDto empDto, int empId)//사원정보 수정
        {
            string sql = "UPDATE employee SET employeeCode=@employeeCode, employeeName = @employeeName, " +
                             "employeeRank = @employeeRank, employeeType = @employeeType, " +
                             "phone = @phone, email = @email, messId = @messId, memo = @memo,gender=@gender WHERE employeeId = @employeeId";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@employeeCode", empDto.employeeCode);
                cmd.Parameters.AddWithValue("@employeeName", empDto.employeeName);
                cmd.Parameters.AddWithValue("@employeeRank", empDto.employeeRank);
                cmd.Parameters.AddWithValue("@employeeType", empDto.employeeType);
                cmd.Parameters.AddWithValue("@phone", empDto.phone);
                cmd.Parameters.AddWithValue("@email", empDto.email);
                cmd.Parameters.AddWithValue("@messId", empDto.messId);
                cmd.Parameters.AddWithValue("@memo", empDto.memo);
                cmd.Parameters.AddWithValue("@gender", empDto.gender);
                cmd.Parameters.AddWithValue("@employeeId", empId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)// 1개이상 영향을 받았을 때
                {
                    return 1;
                }
            }
            return 0;
        }

        public int UpdateLogin(int empId, string loginId, string passwd)//로그인ID, 비밀번호 수정
        {
            string sql = "UPDATE employee SET loginId = @loginId, passwd = @passwd WHERE employeeId = @employeeId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", empId);
                cmd.Parameters.AddWithValue("@loginId", loginId);
                cmd.Parameters.AddWithValue("@passwd", passwd);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.RecordsAffected > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
        public int CheckLogin(string loginId, string passwd)//로그인ID, 비밀번호 체크
        {
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                string sql = "SELECT employeeId FROM employee WHERE loginId = @loginId AND passwd= @passwd ";
                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@loginId", loginId);
                cmd.Parameters.AddWithValue("@passwd", passwd);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }

            }
            return 0;
        }
    }
}

