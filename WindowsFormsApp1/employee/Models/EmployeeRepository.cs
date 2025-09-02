using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1.employee.Models
{
    public class EmployeeRepository
    {
        private static readonly EmployeeRepository instance = new EmployeeRepository();
        private EmployeeRepository() { }
        public static EmployeeRepository EmpRepo => instance;

        public List<EmployeeDto> GetEmpList()//사원 리스트 가져오기
        {
            var list = new List<EmployeeDto>();
            string employeeInfoSql = "SELECT b.departmentCode, b.departmentName, a.employeeCode, a.employeeName, a.loginId, a.passwd, a.employeeRank," +
               "a.employeeType, a.phone, a.email, a.messId, a.memo, a.employeeId, c.imgId FROM employee a JOIN department b on a.departmentId = b.departmentId JOIN img c ON a.imgId =c.imgId  " +
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
                        DepartmentCode = reader["departmentCode"].ToString(),
                        DepartmentName = reader["departmentName"].ToString(),
                        EmployeeCode = reader["employeeCode"].ToString(),
                        EmployeeName = reader["employeeName"].ToString(),
                        LoginId = reader["loginId"].ToString(),
                        Passwd = reader["passwd"].ToString(),
                        EmployeeRank = reader["employeeRank"].ToString(),
                        EmployeeType = reader["employeeType"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        MessId = reader["messId"].ToString(),
                        Memo = reader["memo"].ToString(),
                        EmployeeId = Convert.ToInt32(reader["employeeId"]),
                        ImgId = Convert.ToInt32(reader["imgId"])
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
                        DepartmentCode = reader["departmentCode"].ToString()
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
                        DepartmentName = reader["departmentName"].ToString(),
                        DepartmentId = Convert.ToInt32(reader["departmentId"].ToString()),
                        Cnt = 1

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
                        EmployeeCode = reader["employeeCode"].ToString(),
                        EmployeeId = Convert.ToInt32(reader["employeeId"].ToString()),
                        LoginId = reader["loginid"].ToString(),
                        Cnt = 1
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
        public int InsertImgFolder(string imgName)
        {
            string imgInserSql = "INSERT INTO img (imgName) VALUES (@imgName); SELECT SCOPE_IDENTITY();";
            using (SqlConnection Conn = new SqlConnection(Server.connStr))
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(imgInserSql, Conn);

                cmd.Parameters.AddWithValue("@imgName", (object)imgName ?? DBNull.Value);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());

                return newId;
            }
        }

        public void InsertEmpInfo(EmployeeDto empDto)//사원정보 추가
        {

            string insertEmpsql = "INSERT INTO employee (departmentId, employeeCode, employeeName, loginId, passwd, employeeRank, employeeType, phone, email, messId, memo, gender,imgId) " +
                         "VALUES (@departmentId, @employeeCode, @employeeName, @loginId, @passwd, @employeeRank, @employeeType, @phone, @email, @messId, @memo, @gender,@imgId)";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                SqlCommand cmd2 = new SqlCommand(insertEmpsql, conn);
                cmd2.Parameters.AddWithValue("@departmentId", empDto.DepartmentId);
                cmd2.Parameters.AddWithValue("@employeeCode", empDto.EmployeeCode);
                cmd2.Parameters.AddWithValue("@employeeName", empDto.EmployeeName);
                cmd2.Parameters.AddWithValue("@loginId", empDto.LoginId);
                cmd2.Parameters.AddWithValue("@passwd", empDto.Passwd);
                cmd2.Parameters.AddWithValue("@employeeRank", empDto.EmployeeRank);
                cmd2.Parameters.AddWithValue("@employeeType", empDto.EmployeeType);
                cmd2.Parameters.AddWithValue("@phone", empDto.Phone);
                cmd2.Parameters.AddWithValue("@email", empDto.Email);
                cmd2.Parameters.AddWithValue("@messId", empDto.MessId);
                cmd2.Parameters.AddWithValue("@memo", empDto.Memo);
                cmd2.Parameters.AddWithValue("@gender", empDto.Gender);
                cmd2.Parameters.AddWithValue("@imgId", empDto.ImgId);

                //cmd1.Parameters.AddWithValue("@imgName", (object)empDto.imgName??DBNull.Value);
                cmd2.ExecuteNonQuery();

            }
        }

        public EmployeeDto empDelInfo(int empId)//사원 삭제시 사원명, 사원코드 가져오기
        {
            string sql = "SELECT a.employeeCode , a.employeeName, a.imgId, b.imgName, a.employeeId FROM employee a JOIN img b ON a.imgId = b.imgId WHERE employeeId =@employeeId"
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
                        EmployeeId = Convert.ToInt32(reader["employeeId"]),
                        EmployeeCode = reader["employeeCode"].ToString(),
                        EmployeeName = reader["employeeName"].ToString(),
                        ImgId = Convert.ToInt32(reader["imgid"]),
                        ImgName = reader["imgName"].ToString()
                    };
                }
            }
            return null;
        }

        public int DelEmp(int empId, int imgId)//사원 삭제
        {
            string delImgSql = "DELETE FROM img WHERE imgId = @imgId";
            string sql = "DELETE FROM employee WHERE employeeId = @employeeId";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();

                bool success = false;

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", empId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)// 1개이상 영향을 받았을 때
                {
                    success = true;
                }
                reader.Close();

                SqlCommand cmd1 = new SqlCommand(delImgSql, conn);
                cmd1.Parameters.AddWithValue("@imgId", imgId);
                cmd1.ExecuteNonQuery();

                if (success)
                {
                    return 1;
                }

            }
            return 0;
        }
        public EmployeeDto UpdateEmpInfo(int employeeId)//사원정보 수정
        {
            string sql = "SELECT b.departmentCode, b.departmentName, a.employeeName, a.employeeCode, c.imgName, a.loginId, a.passwd, a.employeeRank,a.imgId, " +
                "a.employeeType, a.phone, a.email, a.messId, a.memo, a.gender, a.departmentId FROM employee a JOIN department b on a.departmentId = b.departmentId JOIN img c ON a.imgId = c.imgId WHERE employeeId=@employeeId";
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
                        DepartmentCode = reader["departmentCode"].ToString(),
                        DepartmentName = reader["departmentName"].ToString(),
                        ImgId = Convert.ToInt32(reader["imgId"]),
                        EmployeeCode = reader["employeeCode"].ToString(),
                        EmployeeName = reader["employeeName"].ToString(),
                        LoginId = reader["loginId"].ToString(),
                        Passwd = reader["passwd"].ToString(),
                        EmployeeRank = reader["employeeRank"].ToString(),
                        EmployeeType = reader["employeeType"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        MessId = reader["messId"].ToString(),
                        Memo = reader["memo"].ToString(),
                        Gender = (EmployeeDto.GenderType)Convert.ToInt32(reader["gender"]),
                        ImgName = reader["imgName"].ToString(),
                        DepartmentId = Convert.ToInt32(reader["departmentId"])
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
        public int UdpateImg(string imgName)
        {
            string updateImgNameSql = "UPDATE img SET imgName = @imgName";
            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(updateImgNameSql, conn);
                cmd.Parameters.AddWithValue("@imgName", (object)imgName ?? DBNull.Value);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.RecordsAffected > 0)
                {
                    return 1;
                }

            }
            return 0;
        }
        public int UpdateEmp(EmployeeDto empDto)//사원정보 수정
        {

            string sql = "UPDATE employee SET employeeCode=@employeeCode, employeeName = @employeeName, departmentId = @departmentId," +
                             "employeeRank = @employeeRank, employeeType = @employeeType," +
                             "phone = @phone, email = @email, messId = @messId, memo = @memo,gender=@gender WHERE employeeId = @employeeId";

            using (SqlConnection conn = new SqlConnection(Server.connStr))
            {

                conn.Open();

                SqlCommand cmd1 = new SqlCommand(sql, conn);

                cmd1.Parameters.AddWithValue("@departmentId", empDto.DepartmentId);
                cmd1.Parameters.AddWithValue("@employeeCode", empDto.EmployeeCode);
                cmd1.Parameters.AddWithValue("@employeeName", empDto.EmployeeName);
                cmd1.Parameters.AddWithValue("@employeeRank", empDto.EmployeeRank);
                cmd1.Parameters.AddWithValue("@employeeType", empDto.EmployeeType);
                cmd1.Parameters.AddWithValue("@phone", empDto.Phone);
                cmd1.Parameters.AddWithValue("@email", empDto.Email);
                cmd1.Parameters.AddWithValue("@messId", empDto.MessId);
                cmd1.Parameters.AddWithValue("@memo", empDto.Memo);
                cmd1.Parameters.AddWithValue("@gender", empDto.Gender);
                cmd1.Parameters.AddWithValue("@employeeId", empDto.EmployeeId);
                // cmd1.Parameters.AddWithValue("@imgName", (object)empDto.imgName ?? DBNull.Value);

                SqlDataReader reader = cmd1.ExecuteReader();
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

        public List<EmployeeDto> GetLinqEmpInfo()
        {
            using (var context = new LinqContext())
            {
                var list = context.Employee
                                    .Join(context.Department, e => e.departmentId, d => d.departmentId, (e, d) => new { e, d })
                                    .Join(context.img, ed => ed.e.imgId, i => i.imgId, (ed, i) => new EmployeeDto
                                    {
                                        EmployeeCode = ed.e.employeeCode,
                                        EmployeeName = ed.e.employeeName,
                                        LoginId = ed.e.loginId,
                                        Passwd = ed.e.passwd,
                                        EmployeeRank = ed.e.employeeRank,
                                        EmployeeType = ed.e.employeeType,
                                        Phone = ed.e.phone,
                                        Email = ed.e.email,
                                        MessId = ed.e.messId,
                                        Memo = ed.e.memo,
                                        EmployeeId = ed.e.employeeId,
                                        DepartmentCode = ed.d.departmentCode,
                                        DepartmentName = ed.d.departmentName,
                                        ImgId = i.imgId
                                    })
                                    .OrderBy(emp => emp.EmployeeId)
                                    .ToList();
                return list;
            }
        }

    }
}

