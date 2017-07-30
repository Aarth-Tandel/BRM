using System.Web.Mvc;
using BRM.Models;
using BusinessLayer;
using System.Web.Security;
using WebMatrix.WebData;
using System;

namespace BRM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            BLUser isValid = new BLUser();
            if (isValid.Authenticate(model.Username, model.Password))
            {
                Session["UserName"] = model.Username;
                int ID = isValid.GetUserID(model.Username);
                Session["ID"] = ID;
                return RedirectToAction("Application","Dashboard");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LoginModel model)
        {
            BLAddUser user = new BLAddUser();
            if (model != null)
            {
                if (user.CheckUser(model.Username))
                {
                    user.AddUser(model.FirstName, model.LastName, model.Username, model.Password, model.Email);
                }
            }
            return View("Login", model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string UserName)
        {
            BLForgotPassword User = new BLForgotPassword();

            //check user existance
            
            if (!User.CheckUser(UserName))
            {
                TempData["Message"] = "User Not exist.";
            }
            else
            {

                string token = Guid.NewGuid().ToString();
                //create url with above token
                var resetLink = "<a href='" + Url.Action("ResetPassword", "Home", new { un = UserName, rt = token }, "http") + "'>Reset Password</a>";

                var emailid = User.GetEmail(UserName);

                //send mail
                string subject = "Password Reset Token";
                string body = "<b>Please find the Password Reset Token</b><br/>" + resetLink; //edit it
                try
                {
                    User.SendEMail(emailid, subject, body);
                    User.AddToken(token, UserName);
                    TempData["Message"] = "Mail Sent.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error occured while sending email." + ex.Message;
                }
                //only for testing
                TempData["Message"] = resetLink;
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string un, string rt)
        {
            BLForgotPassword User = new BLForgotPassword();

            //check userid and token matches
            bool any = User.CheckToken(un, rt);

            if (any == false)
            {
                //generate random password
                string newpassword = GenerateRandomPassword(6);
                //reset password
                bool response = User.ResetPassword(un, newpassword);
                if (response == true)
                {
                    //get user emailid to send password
                    var emailid = User.GetEmail(un);
                    //send email
                    string subject = "New Password";
                    string body = "<b>Please find the New Password</b><br/>" + newpassword; 
                    try
                    {
                        User.SendEMail(emailid, subject, body);
                        TempData["Message"] = "Mail Sent.";
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Error occured while sending email." + ex.Message;
                    }

                    //display message
                    TempData["Message"] = "Success! Check email we sent. Your New Password Is " + newpassword;
                }
                else
                {
                    TempData["Message"] = "Hey, avoid random request on this page.";
                }
            }
            else
            {
                TempData["Message"] = "Username and token not maching.";
            }

            return View();
        }


        private string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }

    }
}