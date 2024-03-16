using BLL;
using RegisterUserAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterUserAssignment.Controllers
{
    public class RegistrationController : Controller
    {
        UserBLL userBLL = new UserBLL();

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            List<User> users = new List<User>();
            List<BLL.Models.User> users_bll = userBLL.GetUsers();
            foreach (BLL.Models.User entry in users_bll)
            {
                User user = new User
                {
                    Username = entry.Username,
                    Email = entry.Email,
                    Password = entry.Password, 
                    ConfirmPassword = entry.Password
                };
                users.Add(user);
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Register(User user, HttpPostedFileBase profilePicture)
        {
            //if (profilePicture != null && profilePicture.ContentLength > 0)
            //{
            //    using (var reader = new System.IO.BinaryReader(profilePicture.InputStream))
            //    {
            //        user.ProfilePicture = reader.ReadBytes(profilePicture.ContentLength);
            //    }
            //}

            if (ModelState.IsValid)
            {
                BLL.Models.User user_bll = new BLL.Models.User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                };
                userBLL.AddUser(user_bll);
                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToAction("AllUsers");
            }
            return View("Index", user);
        }
    }
}