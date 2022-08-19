namespace egs_QATest_API.Models
{
    public class egsAccount
    {
        public string User_email { get; set; } = string.Empty;
        public string User_Firstname { get; set; } = string.Empty;
        public string User_LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int User_isAdmin { get; set; } = -1;
        public int User_Status { get; set; } = -1;
        public int Role_ID { get; set; } = 3;
        public string RoleTitle { get; set; } = string.Empty;


    }
}
