using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.department.Models
{
    public class DepartmentDto
    {
        public string DepartmentCode {  get; set; }
        public string DepartmentName { get; set; }
        public string Memo {  get; set; }

        public int DepartmentId { get; set; }   
        public int DepartmentCnt {  get; set; }

        public override string ToString()
        {
            return DepartmentCode;
        }

    }
}
