namespace Test.Api.Emp.Dtos
{
    public class EmpListDto
    {
        public long Id { get; set; }
        public long FactoryId {  get; set; }
        public string FactoryCode {  get; set; }
        public string FactoryName { get; set; }
        public long DepartmentId {  get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode {  get; set; }
        public string ContractType {  get; set; }
        public string Code {  get; set; }
        public string Name {  get; set; }
        public string Position {  get; set; }
        public string LoginId {  get; set; }
        public string LoginPassword {  get; set; }
        public string Email {  get; set; }
        public string PhoneNumber {  get; set; }
        public string MessengerId {  get; set; }
        public string Memo {  get; set; }
        public string LoginTag { get; set; }
        public bool IsAdmin { get; set; }


    }
}
