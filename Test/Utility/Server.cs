namespace WindowsFormsApp1.Utility
{
    public class Server
    {
        public string ConnStr()
        {
            string connStr = @"Server = DESKTOP-S3H1PN6\SQLEXPRESS; Database=test2; Integrated Security=True; TrustServerCertificate= True";
            return connStr;
        }
    }
}
