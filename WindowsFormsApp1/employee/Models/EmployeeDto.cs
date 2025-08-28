using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.department.Model
{
    public class EmployeeDto
    {
        public string departmentCode { get; set; }
        public string departmentName { get; set; }
        public string employeeCode { get; set; }
        public string employeeName { get; set; }
        public string loginId { get; set; }
        public string passwd { get; set; }

        public string passwdMask => new string('*', passwd.Length);
        public string employeeRank { get; set; }
        public string employeeType { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string messId { get; set; }
        public string memo { get; set; }
        public int employeeId { get; set; }
        public int departmentId { get; set; }
        public string imgName {  get; set; }

        public int imgId { get; set; }

        public GenderType gender { get; set; }

        public enum GenderType
        {
            Male=1,
            Female = 2
        }
        public int cnt { get; set; }

    }
}
