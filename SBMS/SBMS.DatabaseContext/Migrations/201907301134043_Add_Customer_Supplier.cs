namespace SBMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Customer_Supplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ClietId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        LoyaltyPoint = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ClietId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        LoyaltyPoint = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.SupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
        }
    }
}
