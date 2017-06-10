using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseLayer
{
    public class Connection
    {
        public static string Address = ConfigurationManager.ConnectionStrings["BRM"].ConnectionString;
        public static  SqlConnection con = new SqlConnection(Address);
        public static void Open()
        {
            try
            {              
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        public static void close()
        {
            con.Close();
        }
    }

    public class User
    {
       public bool AuthenticateUser(string Username, string Password)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("spAuthenticate", Connection.con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUsername = new SqlParameter("@Username", Username);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);
            cmd.Parameters.Add(paramUsername);
            cmd.Parameters.Add(paramPassword);
            int ReturnCode = (int)cmd.ExecuteScalar();
            return ReturnCode == 1;
        }
    }
}
