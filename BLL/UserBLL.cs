using BLL.Models;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        public List<User> GetUsers()
        {
            List<User> users_bll = new List<User>();

            UserDAL userDAL = new UserDAL();

            foreach(DAL.Models.User entry in userDAL.GetUsers())
            {
                User user = new User
                {
                    Username = entry.Username,
                    Email = entry.Email,
                    Password = entry.Password + " Some business logic"
                };
                users_bll.Add(user);
            }
            return users_bll;
        }
    }
}
