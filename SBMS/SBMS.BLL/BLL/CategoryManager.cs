using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.Model.Model;
using SBMS.Repository.Repository;

namespace SBMS.BLL.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public bool Delete(Category category)
        {
            return _categoryRepository.Delete(category);
        }
        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetByID(Category category)
        {
            return _categoryRepository.GetByID(category);

        }

        public IEnumerable<Category> GetCategoyList()
        {
            return _categoryRepository.GetCategoyList();
        }

        public Category GetCategoyID(int CatID)
        {
            return _categoryRepository.GetCategoyID(CatID);
        }
        
    }
}
