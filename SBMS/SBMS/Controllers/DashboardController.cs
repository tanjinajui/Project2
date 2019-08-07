using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMS.BLL.BLL;
using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Model.Model;

namespace SBMS.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        //
        UserManager _userManager = new UserManager();
        User _user = new User();

        public ActionResult AdminDashboard()
        {
            object obj = Session["UserId"];
            if (obj != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult UserDashboard()
        {
            return View();
        }

    }
}