using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegisterUserAssignment.DAL
{
    public class UserDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionString"].ToString();

        public void GetUsers()
        {
            System.Diagnostics.Debug.WriteLine("FAT");
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sqlQuery = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine(reader["FirstName"]);
                        break;
                    }
                }
            }
        }
    }
}