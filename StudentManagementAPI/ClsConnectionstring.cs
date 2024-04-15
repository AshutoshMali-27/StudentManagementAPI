namespace StudentManagementAPI
{
    public class ClsConnectionstring
    {
        private static string cs = "server=;Database=StudentsDB;Trusted_Connection=true;";

        public static string dbcs { get => cs; }
    }
}
