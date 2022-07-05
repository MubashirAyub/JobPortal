using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobPortalProject.Controllers
{
    public class HomeController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(User objUser)
        {

            if (ModelState.IsValid)
            {
                using (JobPortalEntities db = new JobPortalEntities())
                {
                    var obj = db.Users.Where(a => a.User_Username.Equals(objUser.User_Username) && a.User_Password.Equals(objUser.User_Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_ID.ToString();
                        HttpContext.Session["Id"] = obj.User_ID.ToString();
                        Session["UserName"] = obj.User_Username.ToString();
                        Session["UserFirstName"] = obj.Usre_FirstName.ToString();
                        Session["UserType"] = obj.User_Type.ToString();
                        
                        Session["UserContact"] = obj.User_Contact.ToString();

                        //Registration rec = new Registration
                        //{
                        //    UserType = obj.UserType.ToString(),
                        //    UserId = obj.UserId,
                        //    UserName = obj.UserName.ToString(),
                        //    Password = obj.Password.ToString(),
                        //    UploadView = obj.UploadView.ToString()
                        //};

                        //TempData["mydata"] = rec;
                        return RedirectToAction("Index", "JobPosts");
                    }

                }
            }

            return View(objUser);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult StartPage()
        {

            return View(db.JobPosts.ToList());
        }


    }
}