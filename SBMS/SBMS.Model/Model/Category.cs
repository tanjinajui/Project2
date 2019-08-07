using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBMS.Model.Model
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string CategoryName { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
        
    }
}
