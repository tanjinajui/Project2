using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.DatabaseContext.DatabaseContext;
using SBMS.Model.Model;

namespace SBMS.Repository.Repository
{
    public class CategoryRepository
    {
        SBMS_DBContext db = new SBMS_DBContext();
        public bool Add(Category sCategory)
        {

            int isExecuted = 0;
            db.Categories.Add(sCategory);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Category sCategory)
        {
            int isExecuted = 0;
            Category category = db.Categories.FirstOrDefault(c => c.CatID == sCategory.CatID);
            if (category != null)
            {
                db.Categories.Remove(category);
                isExecuted = db.SaveChanges();
            }

            if (isExecuted > 0)
            { return true; }
            else { return false; }


        }

        public bool Update(Category sCategory)
        {
            int isExecuted = 0;
            db.Entry(sCategory).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;

            }

            else
            {
                return false;
            }

        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Category> GetCategoyList()
        {
            return db.Categories.ToList();
        }



        public Category GetByID(Category sCategory)
        {
            Category category = db.Categories.FirstOrDefault(c => c.CatID == sCategory.CatID);
            return category;
        }
        public Category GetCategoyID(int catid)
        {
            Category category = db.Categories.FirstOrDefault(c => c.CatID == catid);
            return category;
        }
        
    }
}
