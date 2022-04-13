using AuthorizeandAuthenticate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizeandAuthenticate.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserModel userModel)
        {
            //if (ModelState.IsValid)
            //{
                UserRegistrationManager userRegistrationManager = new UserRegistrationManager();
                userModel = userRegistrationManager.RegisterUserDetail(userModel);
            //}
            return View("RegisterUser",userModel);
        }
    }
}