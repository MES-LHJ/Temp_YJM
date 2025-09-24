using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WindowsFormsApp1.Utility;

namespace Test.Departments.Models
{
    public class DepartmentRepository
    {
        public Server server = new Server();
        private static DepartmentRepository _instance = new DepartmentRepository();
        private DepartmentRepository() { }

        public static DepartmentRepository DeptRepo = _instance;

        public List<DepartmentDto> GetDeptListInfo()//부서 리스트 가져오기
        {
            var list = new List<DepartmentDto>();
            string sql = "SELECT departmentCode , departmentName, memo, departmentId FROM department ORDER BY departmentId";
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DepartmentDto
                    {
                        DepartmentCode = reader["departmentCode"].ToString(),
                        DepartmentName = reader["departmentName"].ToString(),
                        Memo = reader["memo"].ToString(),
                        DepartmentId = Convert.ToInt32(reader["departmentId"].ToString())
                    });
                }
            }
            return list;
        }

        public DepartmentDto GetDeptId(string departmentCode)//부서코드로 부서ID 가져오기
        {
            string sql = "SELECT departmentId FROM department WHERE departmentCode = @departmentCode";

            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DepartmentDto
                    {
                        DepartmentId = Convert.ToInt32(reader["departmentId"].ToString())
                    };
                }

            }
            return null;
        }

        public int InsertDeptCodeCheck(string departmentCode)//부서코드 중복체크
        {
            string deptCodeCheckSql = "SELECT departmentCode FROM department WHERE departmentCode = @departmentCode";
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
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
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
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
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", departmentDto.DepartmentCode);
                cmd.Parameters.AddWithValue("@departmentName", departmentDto.DepartmentName);
                cmd.Parameters.AddWithValue("@memo", departmentDto.Memo);

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
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", departId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new DepartmentDto
                    {
                        DepartmentCode = reader["departmentCode"].ToString(),
                        DepartmentName = reader["departmentName"].ToString(),
                        Memo = reader["memo"].ToString()
                    };

                }
            }
            return null;
        }
        public int CheckEmployee(int deptId)
        {
            string sql = "SELECT employeeId FROM employee WHERE departmentId = @departmentId";
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentId", deptId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }
        public int DelDepartment(int deptId)//부서 삭제
        {
            string sql = "DELETE FROM department WHERE departmentId = @departmentId";
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
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
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@departmentCode", deptDto.DepartmentCode);
                cmd.Parameters.AddWithValue("@departmentName", deptDto.DepartmentName);
                cmd.Parameters.AddWithValue("@memo", deptDto.Memo);
                cmd.Parameters.AddWithValue("@departmentId", deptDto.DepartmentId);

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
            string chartSql = "SELECT d.departmentName, count(a.employeeId) AS CNT FROM employee e Right JOIN department d ON e.departmentId = d.departmentId GROUP BY d.departmentName";
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(chartSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DepartmentDto
                    {
                        DepartmentName = reader["departmentName"].ToString(),
                        DepartmentCnt = Convert.ToInt32(reader["CNT"].ToString())
                    });
                }

            }
            return list;
        }

        public List<DepartmentDto> GetTestChart()
        {
            var list = new List<DepartmentDto>();
            string chartSql = " SELECT COUNT(s.departmentId) AS TOTAL, COUNT(e.employeeId) AS CNT, s.subDeptName,d.departmentId, s.subDeptId, " +
                "d.departmentName FROM department d Left JOIN Employee e ON d.departmentId = e.departmentId left JOIN subDepartment s " +
                "ON e.subDeptId = s.subDeptId GROUP BY s.subDeptName, d.departmentName, d.departmentId, s.subDeptId";
      
            using (SqlConnection conn = new SqlConnection(server.ConnStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(chartSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DepartmentDto
                    {
                        DepartmentName = reader["departmentName"] != DBNull.Value ? reader["departmentName"].ToString() : null,

                        //SubDeptId = reader["subDeptId"] != DBNull.Value ? Convert.ToInt32(reader["subDeptId"]) : 0,
                        DepartmentId = Convert.ToInt32(reader["departmentId"]),//reader["departmentId"] != DBNull.Value ? Convert.ToInt32(reader["departmentId"]) : 0,
                        DepartmentCnt = reader["CNT"] != DBNull.Value ? Convert.ToInt32(reader["CNT"].ToString()) : 0,
                        SubDeptName = reader["subDeptName"] != DBNull.Value ? reader["subDeptName"].ToString() : null,
                        SubDeptId = reader["subDeptId"] != DBNull.Value ? Convert.ToInt32(reader["subDeptId"]) : 0,
                        ChartDisplay = "[ID : "+reader["departmentId"].ToString()+"]-" + reader["departmentName"]
                    });
                }
            }
            return list;
        }
        //public List<DepartmentDto> GetTestChartLinq()
        //{
        //    using (var context = new Linq2Context())
        //    {
        //        var chartList = context.Department
        //                                    .GroupJoin(context.SubDepartment, d => d.departmentId, s => s.departmentId, (d, s) => new { d, s })
        //                                    .GroupJoin(context.Employee, ds => ds.d.departmentId, e => e.departmentId, (ds, e) =>
        //                                    new DepartmentDto
        //                                    {
        //                                        DepartmentId = ds.d.departmentId,
        //                                        DepartmentName = ds.d.departmentName,
        //                                        E

        //                                    });

        //    }
        //}
        public List<DepartmentDto> GeChartLinq()
        {
            using (var context = new Linq2Context())
            {
                var list = context.Department
                                    .GroupJoin(context.Employee, d => d.departmentId, b => b.departmentId, (d, a) => new DepartmentDto { DepartmentName = d.departmentName, DepartmentId = d.departmentId, Count = a.Count() })
                                    .OrderByDescending(a => a.Count)
                                    .ToList();
                return list;
            }
        }
        public List<DepartmentDto> GetLinqDeptListInfo()
        {
            using (var context = new Linq2Context())
            {
                var deptListInfo = context.Department
                                            .OrderBy(d => d.departmentId)
                                            .Select(d => new DepartmentDto
                                            {
                                                DepartmentId = d.departmentId,
                                                DepartmentName = d.departmentName,
                                                DepartmentCode = d.departmentCode,
                                                Memo = d.memo,
                                            })
                                            .ToList();
                return deptListInfo;
            }
        }

        public List<DepartmentDto> GetSubDeptInfo1(int deptId, string mainDeptCode, string mainDeptName)
        {
            using (var context = new Linq2Context())
            {
                var subDepInfo = context.SubDepartment
                                           .OrderBy(s => s.subDeptId)
                                           .Where(s => s.departmentId == deptId)
                                           .Select(s => new DepartmentDto
                                           {
                                               DepartmentName = mainDeptName,
                                               DepartmentCode = mainDeptCode,
                                               DepartmentId = s.departmentId,
                                               SubDeptId = s.subDeptId,
                                               SubDeptCode = s.subDeptCode,
                                               SubDeptName = s.subDeptName,
                                               Memo = s.memo
                                           })

                                           .ToList();
                return subDepInfo;
            }
        }
        //public DataTable GetMainDeptInfoTable()
        //{
        //    using (SqlConnection conn = new SqlConnection(server.ConnStr()))
        //    {
        //        string sql = @"SELECT departmentId AS id, NULL AS parentId, departmentCode, departmentName, memo FROM department";
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
        //        {
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        //public DataTable GetSubDeptInfoTable()
        //{
        //    using (SqlConnection conn = new SqlConnection(server.ConnStr()))
        //    {
        //        string sql = @"SELECT subDeptId AS id, departmentId AS parentId, subDeptCode AS departmentCode, subDeptName AS departmentName, memo FROM subDepartment";
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
        //        {
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}
        public List<DepartmentDto> GetMainDeptInfo()
        {
            using (var context = new Linq2Context())
            {
                var mainDeptList = context.Department
                                            .Select(e => new DepartmentDto
                                            {
                                                DepartmentId = e.departmentId,
                                                DepartmentName = e.departmentName,
                                                Memo = e.memo,
                                                DepartmentCode = e.departmentCode,

                                            })
                                            .ToList();
                return mainDeptList;
            }

        }

        public List<DepartmentDto> GetSubDeptInfo()
        {
            using (var context = new Linq2Context())
            {
                var subDeptList = context.SubDepartment
                                            .Select(e => new DepartmentDto
                                            {
                                                DepartmentId = e.departmentId,
                                                SubDeptName = e.subDeptName,
                                                Memo = e.memo,
                                                SubDeptCode = e.subDeptCode,
                                                SubDeptId = e.subDeptId,
                                            })
                                            .ToList();
                return subDeptList;
            }
        }
        public List<DepartmentDto> GetSubDeptCode(int deptId)
        {
            using (var context = new Linq2Context())
            {
                var subDeptList = context.SubDepartment
                                            .Where(e => e.departmentId == deptId)
                                            .Select(e => new DepartmentDto
                                            {
                                                DepartmentId = e.departmentId,
                                                SubDeptName = e.subDeptName,
                                                Memo = e.memo,
                                                DepartmentCode = e.subDeptCode,
                                                SubDeptId = e.subDeptId,
                                            })
                                            .ToList();
                return subDeptList;

            }
        }
        public List<DepartmentDto> GetSubDeptCode2(int deptId)
        {
            using (var context = new Linq2Context())
            {
                var subDeptList = context.SubDepartment
                                            .Where(e => e.departmentId == deptId)
                                            .Select(e => new DepartmentDto
                                            {
                                                SubDeptName = e.subDeptName,
                                                Memo = e.memo,
                                                SubDeptCode = e.subDeptCode,
                                                SubDeptId = e.subDeptId,
                                            })
                                            .ToList();
                return subDeptList;

            }
        }

        public int MainDeptUdpate(DepartmentDto deptDto)
        {
            using (var context = new Linq2Context())
            {
                var mainDeptUpdate = context.Department
                                                .FirstOrDefault(d => d.departmentId == deptDto.DepartmentId);
                if (mainDeptUpdate != null)
                {
                    mainDeptUpdate.departmentCode = deptDto.DepartmentCode;
                    mainDeptUpdate.departmentName = deptDto.DepartmentName;
                    mainDeptUpdate.memo = deptDto.Memo;

                    context.SaveChanges();

                    return 1;
                }
                else return 0;
            }
        }
        public int DelMainDeptLinq(int deptId)
        {
            using (var context = new Linq2Context())
            {
                var delMainDept = context.Department
                                            .FirstOrDefault(d => d.departmentId == deptId);
                if (delMainDept != null)
                {
                    context.Department.Remove(delMainDept);
                    context.SaveChanges();

                    return 1;
                }
                else return 0;
            }
        }

        public int LowDeptInfo(int dpetId)
        {
            using (var context = new Linq2Context())
            {
                var lowDept = context.SubDepartment
                                        .Any(s => s.departmentId == dpetId);
                if (lowDept == true)
                {
                    return 1;
                }
                else return 0;
            }
        }
        public int InsertMainDept(Department mainDept)
        {
            using (var context = new Linq2Context())
            {
                //Department insertMainDept = new Department
                //{
                //    departmentName = mainDeptDto.DepartmentName,
                //    departmentCode = mainDeptDto.DepartmentCode,
                //    memo = mainDeptDto.Memo,
                //};
                if (mainDept != null)
                {
                    context.Department.Add(mainDept);
                    context.SaveChanges();
                    return mainDept.departmentId;
                }
                else return 0;
            }
        }
        public int DeleteSubDeptLinq(int deptId, int subDeptId)
        {
            using (var context = new Linq2Context())
            {
                var delSubDept = context.SubDepartment
                                            .FirstOrDefault(s => s.departmentId == deptId && s.subDeptId == subDeptId);
                if (delSubDept != null)
                {
                    context.SubDepartment.Remove(delSubDept);
                    context.SaveChanges();
                    return 1;
                }
                else return 0;
            }
        }
        public int CheckSubDeptEmp(int subDeptId)
        {
            using (var context = new Linq2Context())
            {
                var checkEmp = context.Employee
                                        .Any(e => e.subDeptId == subDeptId);
                if (checkEmp == true)
                {
                    return 1;
                }
                else return 0;
            }
        }
        public int UpdateSubDeptLinq(SubDepartment updateSubDeptInfo)
        {
            using (var context = new Linq2Context())
            {
                var updateSubDept = context.SubDepartment
                                                .FirstOrDefault(s => s.subDeptId == updateSubDeptInfo.subDeptId);
                if (updateSubDept != null)
                {
                    updateSubDept.departmentId = updateSubDeptInfo.departmentId;
                    updateSubDept.subDeptCode = updateSubDeptInfo.subDeptCode;
                    updateSubDept.subDeptName = updateSubDeptInfo.subDeptName;
                    updateSubDept.memo = updateSubDeptInfo.memo;

                    context.SaveChanges();
                    return 1;
                }
                else return 0;
            }
        }
        public int UpdateDeptIdEmployee(int originDeptId, int subDeptd, int updateDeptId)
        {
            using (var context = new Linq2Context())
            {
                var updateDeptIdEmp = context.Employee
                                                .Where(e => e.departmentId == originDeptId && e.subDeptId == subDeptd)
                                                .ToList();

                if (updateDeptIdEmp != null)
                {

                    foreach (var updateDept in updateDeptIdEmp)
                    {
                        updateDept.departmentId = updateDeptId;
                        context.SaveChanges();
                    }

                    return 1;

                }
                else return 0;
            }
        }
    }
}
