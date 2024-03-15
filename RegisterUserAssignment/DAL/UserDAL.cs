using RegisterUserAssignment.Models;
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

        public List<User> GetUsers()
        {
            // User List
            List<User> userList = new List<User>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string sqlQuery = "SELECT Username, Email, Password FROM Users";
                SqlCommand command = new SqlCommand(sqlQuery, con);

                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString(),
                            ConfirmPassword = reader["Password"].ToString()
                        };
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sqlQuery = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}