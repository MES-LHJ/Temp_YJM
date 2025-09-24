using Newtonsoft.Json;

namespace Test.Employees.Models
{
    public class EmployeeDto 
    {
   
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string LoginId { get; set; }
        public string Passwd { get; set; }

        public string PasswdMask => new string('*', Passwd.Length);
        public string EmployeeRank { get; set; }
        public string EmployeeType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MessId { get; set; }
        public string Memo { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string ImgName {  get; set; }
        public int ParentId { get; set; }
        public int ImgId { get; set; }
        public string SubDeptCode { get; set; }
        public string SubDeptName { get; set; }
        public int SubDeptId { get; set; }
        public int Id {  get; set; }
        public GenderType Gender { get; set; }

        public enum GenderType
        {   
            noSelect = 0,
            Male=1,
            Female = 2
        }
        public int Cnt { get; set; }

    }
}
