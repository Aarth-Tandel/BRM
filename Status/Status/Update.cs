using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Status
{
    public class Update
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["LOGIN"].ConnectionString;

        public void SaveStatus(string Status, int JobID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Update brm.logs set status = @Status where ID = @ID"))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", JobID);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
