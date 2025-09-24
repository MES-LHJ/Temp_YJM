namespace Test.Departments.Models
{
    public class DepartmentDto 
    {
        public string DepartmentCode {  get; set; }
        public string DepartmentName { get; set; }
        public string Memo {  get; set; }

        public int DepartmentId { get; set; }   
        public int DepartmentCnt {  get; set; }
        public int Count {  get; set; }

        public int SubDeptId { get; set; }
        public string SubDeptCode { get; set; }
        public string SubDeptName { get; set; }
        
        public int ParentId {  get; set; }

        public bool IsDeptCode { get; set; }
        public int Id {  get; set; }

        public string ChartDisplay {  get; set; }

        public override string ToString()
        {
            return DepartmentCode;
            //if (IsDeptCode) return DepartmentCode;
            //else return SubDeptCode;
        }

    }
}
