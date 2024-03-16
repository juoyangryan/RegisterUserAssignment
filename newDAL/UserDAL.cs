using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class UserDAL
    {
        string conString = "Data Source=192.168.4.50,1433;database=ASPAssignment;user id=sa;password=dockerStrongPwd123;";

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
                            Password = reader["Password"].ToString()
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
                //command.Parameters.AddWithValue("@ProfilePic", user.ProfilePicture);


                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
