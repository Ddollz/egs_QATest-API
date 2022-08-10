using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace egs_QATest_API.Models
{
    public class EgsAccount
    {
        SqlConnection con = new SqlConnection("Data Source=WORKSTATION-181\\SQLEXPRESS;Initial Catalog=EgsQAsuite;Integrated Security=True");
        public EgsAccount()
        {
            EgsProjects = new HashSet<EgsProject>();
            EgsSuites = new HashSet<EgsSuite>();
            EgsTestCaseComments = new HashSet<EgsTestCaseComment>();
            EgsTestCases = new HashSet<EgsTestCase>();
            EgsTestRuns = new HashSet<EgsTestRun>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public int UserIsAdmin { get; set; }
        public int UserStatus { get; set; }
        public int RoleId { get; set; }
        //public EgsRole? Role { get; set; }

        public virtual EgsRole? Role { get; set; }

        public virtual ICollection<EgsProject> EgsProjects { get; set; }
        public virtual ICollection<EgsSuite> EgsSuites { get; set; }
        public virtual ICollection<EgsTestCaseComment> EgsTestCaseComments { get; set; }
        public virtual ICollection<EgsTestCase> EgsTestCases { get; set; }
        public virtual ICollection<EgsTestRun> EgsTestRuns { get; set; }


        public string EgsAccountOpt(EgsAccount acc)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("egsQAAccountInsertUpdate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@User_id", acc.UserId);
                com.Parameters.AddWithValue("@User_Email", acc.UserEmail);
                com.Parameters.AddWithValue("@User_Password", acc.UserPassword);
                com.Parameters.AddWithValue("@User_Role", acc.UserRole);
                com.Parameters.AddWithValue("@User_isAdmin", acc.UserIsAdmin);
                com.Parameters.AddWithValue("@User_Status", acc.UserStatus);
                com.Parameters.AddWithValue("@Role_ID", acc.RoleId);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "success";
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }

    }
}
