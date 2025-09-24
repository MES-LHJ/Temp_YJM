namespace Test.Api.Dept.Dtos
{
    public class DeptListDto
    {
        public long Id { get; set; }
        public string Code {  get; set; }
        public string Name { get; set; }
        public string Memo {  get; set; }
        public long FactoryId {  get; set; }
        public string FactoryCode {  get; set; }
        public string FactoryName { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}
