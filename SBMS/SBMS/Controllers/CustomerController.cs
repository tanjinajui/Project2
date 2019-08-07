using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBMS.Model.Model;
using SBMS.BLL.BLL;
using SBMS.DatabaseContext.DatabaseContext;
using System.Data.Entity;


namespace SBMS.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                List<Customer> customerList = db.Customers.ToList<Customer>();
                return Json(new { data = customerList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            //Customer customer = new Customer();

            if (id == 0)
            { return View(new Customer());}
                
            else
            {
                using (SBMS_DBContext db = new SBMS_DBContext())
                {
                    return View(db.Customers.Where(x => x.ClietId == id).FirstOrDefault<Customer>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Customer customer)
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                if (customer.ClietId == 0)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(customer).State = EntityState.Modified;
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
                Customer customer = db.Customers.Where(x => x.ClietId == id).FirstOrDefault<Customer>();
                db.Customers.Remove(customer);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}