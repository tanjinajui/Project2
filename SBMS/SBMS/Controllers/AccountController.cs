using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Collections.Generic;
using System.Net;
using WebMatrix.WebData;
using SBMS.Model.Model;
using SBMS.DatabaseContext.DatabaseContext;
using SBMS.BLL.BLL;
using SBMS.Filters;

namespace SBMS.Controllers
{
    public class AccountController : Controller
    {
        UserManager _userManager = new UserManager();
        User _user = new User();

        // GET: Account
        public ActionResult Index()
        {
            //using (SmallBusinessDBContext db = new SmallBusinessDBContext())
            //{
            //    return View(db.Users.ToList());
            //}
            return View();
        }
        public ActionResult GetData()
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                List<User> userList = db.Users.ToList<User>();
                return Json(new { data = userList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
            {
                using (SBMS_DBContext db = new SBMS_DBContext())
                {
                    return View(db.Users.Where(x => x.UserID == id).FirstOrDefault<User>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                if (user.UserID == 0)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                User user = db.Users.Where(x => x.UserID == id).FirstOrDefault<User>();
                db.Users.Remove(user);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (SBMS_DBContext db = new SBMS_DBContext())
                {
                    var get_user = db.Users.FirstOrDefault(p => p.UserName == user.UserName);
                    if (get_user == null)
                    {
                        user.Password = user.Password;
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "UserName already exists";
                        return View();
                    }
                }
                ModelState.Clear();
                ViewBag.Message = "Successfully Registered Mr. " + 
                                  user.FullName;
            }
            return RedirectToAction("Login");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                var get_user = db.Users.SingleOrDefault(c => c.UserName == login.UserName && c.Password == login.Password);
                if (get_user != null)
                {
                    Session["UserId"] = get_user.UserID.ToString();
                    Session["UserName"] = get_user.UserName.ToString();
                    Session["UserType"] = "Admin";

                    if (string.Equals(Convert.ToString(Session["UserType"]), "Admin"))
                    {
                        //return RedirectToAction("AdminDashboard", "Dashboard");
                        //FormsAuthentication.SetAuthCookie(login.UserName, true);
                        int timeout = 1; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.UserName, false, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        //return RedirectToAction("LoggedIn", "Account");
                        return RedirectToAction("AdminDashboard", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard", "Dashboard");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password does not match.");
                    return View(login);
                }

            }
            //return View(login);
        }


        // Logoff & Change Password
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Response.Redirect("~/account/login");
            return View();
        }

       // [HttpGet]
       // [MyExceptionHandler]
       // public ActionResult Changepassword()
       // {
       //     return View(new ChangepasswordVM());
       // }

       // [HttpPost]
       // [MyExceptionHandler]
       // [ValidateAntiForgeryToken]
       // public ActionResult Changepassword(ChangepasswordVM VM)
       // {
       //     //if (ModelState.IsValid)
       //     //{
       //     //    if (!WebSecurity.UserExists(Convert.ToString(Session["UserName"])))
       //     //    {
       //     //        ModelState.AddModelError("Error", "UserName ");

       //     //    }
       //     //    else
       //     //    {
       //     //        var value = WebSecurity.ChangePassword(Session["UserName"].ToString(), VM.OldPassword, VM.Newpassword);

       //     //        if (value == false)
       //     //        {
       //     //            ModelState.AddModelError("Error", "Incorrect Old Password");
       //     //            return View(VM);
       //     //        }
       //     //        else
       //     //        {
       //     //            ViewBag.ResultMessage = "Password Changed Successfully";
       //     //        }

       //     //    }
       //     //}
       //     //else
       //     //{
       //     //    ModelState.AddModelError("Error", "Fill on Fields");
       //     //}
       //     if (ModelState.IsValid)
       //     {
       //         if (_userManager.ChangePassword(Session["UserName"].ToString()))
       //         {
       //             ViewBag.SuccessMsg = "Updated";
       //         }
       //         else
       //         {
       //             ViewBag.FailMsg = "Failed";
       //         }
       //     }
       //     else
       //     {
       //         ViewBag.FailMsg = "Validation Error";
       //     }

       //     return RedirectToAction("AdminDashboard","Dashboard");

       //}
    }
}