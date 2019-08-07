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
    public class ProductController : Controller
    {
       
        // GET: Product
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult GetData()
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                List<Product> prodList = db.Products.ToList<Product>();

                return Json(new { data = prodList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Product product=new Product();


            if (id == 0)
                using (SBMS_DBContext db = new SBMS_DBContext())
                {
                    product.Categories = db.Categories.ToList<Category>();
                    return View(product);
                }
            else
            {
                using (SBMS_DBContext db = new SBMS_DBContext())
                {
                    product.Categories = db.Categories.ToList<Category>();
                    return View(db.Products.Where(x => x.Id == id).FirstOrDefault<Product>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Product product)
        {
            using (SBMS_DBContext db = new SBMS_DBContext())
            {
                if (product.Id == 0)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(product).State = EntityState.Modified;
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
                Product product = db.Products.Where(x => x.Id == id).FirstOrDefault<Product>();
                db.Products.Remove(product);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

     
    }
}