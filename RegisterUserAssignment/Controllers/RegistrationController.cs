using RegisterUserAssignment.DAL;
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
        UserDAL userDAL = new UserDAL();

        private static List<User> users = new List<User>();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}