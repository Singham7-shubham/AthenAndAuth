using AuthorizeandAuthenticate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthorizeandAuthenticate.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Login()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            UserAuthenticationManager userAuthenticationManager = new UserAuthenticationManager();
            userModel= userAuthenticationManager.UserAuth(userModel);
            if (userModel.IsValid == 1)
            {
                Session["UserEmail"] = userModel.UserEmail;
                FormsAuthentication.SetAuthCookie(userModel.UserName, false);

                var authTicket = new FormsAuthenticationTicket(1, userModel.UserEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, userModel.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index","Home");
            }

            else
            {
                userModel.LoginErrorMessage = "Email and password are not matching";
                return View("Login", userModel);
            }

        }

    }
}