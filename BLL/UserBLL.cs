using BLL.Models;
using DAL;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BLL
{
    public class UserBLL
    {
        public List<User> GetUsers()
        {
            List<User> users_bll = new List<User>();

            UserDAL userDAL = new UserDAL();

            foreach (DAL.Models.User entry in userDAL.GetUsers())
            {
                User user = new User
                {
                    Username = entry.Username,
                    Email = entry.Email + " Some business logic",
                    Password = entry.Password
                };
                users_bll.Add(user);
            }
            return users_bll;
        }

        public void AddUser(User user)
        {
            UserDAL userDAL = new UserDAL();

            DAL.Models.User user_dal = new DAL.Models.User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            userDAL.AddUser(user_dal);
        }
    }
}
