using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SBMS.Model.Model;


namespace SBMS.DatabaseContext.DatabaseContext
{
    public class SBMS_DBContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
    }
}
