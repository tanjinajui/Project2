namespace SBMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SBMS.DatabaseContext.DatabaseContext.SBMS_DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SBMS.DatabaseContext.DatabaseContext.SBMS_DBContext";
        }

        protected override void Seed(SBMS.DatabaseContext.DatabaseContext.SBMS_DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
