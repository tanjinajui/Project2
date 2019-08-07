using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SBMS.Model.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Code is required")]
        public string PCode { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string  ProductName { get; set; }
        [Required(ErrorMessage = "Reorderlabel is required")]
        public int Reorderlabel { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        [DisplayName("Category")]
        public int? CatId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public List<Category>  Categories { get; set; }

    }
}
