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
    public class Supplier
    {
        [Key]
        public int SupId { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "ContactPerson is required")]
        [Phone]
        public string Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
    }
}
