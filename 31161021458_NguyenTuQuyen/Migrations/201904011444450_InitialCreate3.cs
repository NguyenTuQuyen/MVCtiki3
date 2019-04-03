namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Image1 = c.String(nullable: false),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Image4 = c.String(),
                        Image5 = c.String(),
                        CategoryProductID = c.String(nullable: false),
                        Ship24h = c.Boolean(nullable: false),
                        Sale = c.Double(nullable: false),
                        Comment = c.String(),
                        Installment = c.Boolean(nullable: false),
                        PromotionCode = c.String(),
                        Feature = c.String(),
                        Description = c.String(),
                        Buyed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
