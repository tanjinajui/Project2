using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBMS.BLL.BLL;
using SBMS.Model.Model;
using SBMS.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace SBMS.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        private Category _category = new Category();
        SBMS_DBContext db = new SBMS_DBContext();
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            //IEnumerable<Category> cagories = _categoryManager.GetCategoyList();
            //ViewBag.PageNumber = (Request.QueryString["grid-page"] == null) ? "1" : Request.QueryString["grid-page"];
            //return View(cagories);
            var categories = _categoryManager.GetAll();
            _category.Categories = categories;
            return View(_category);

        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    TempData["notice"] = "Category Created Successfully"; 
                }
                else
                {
                    TempData["notice"] = "Failed";
                }
            }
            else
            {
                TempData["notice"] = "Validation Error";
            }

            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: MyFirstTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
               if (_categoryManager.Update(category))
                {
                    ViewBag.SuccessMsg = "Updated";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
                return RedirectToAction("Index","Category");
            }
            return View(category);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.Delete(category))
                {
                    ViewBag.SuccessMsg = "Updated";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }


    }
}