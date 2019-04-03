namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListImageProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            DropColumn("dbo.Products", "ImagePath1");
            DropColumn("dbo.Products", "ImagePath2");
            DropColumn("dbo.Products", "ImagePath3");
            DropColumn("dbo.Products", "ImagePath4");
            DropColumn("dbo.Products", "ImagePath5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath5", c => c.String());
            AddColumn("dbo.Products", "ImagePath4", c => c.String());
            AddColumn("dbo.Products", "ImagePath3", c => c.String());
            AddColumn("dbo.Products", "ImagePath2", c => c.String());
            AddColumn("dbo.Products", "ImagePath1", c => c.String());
            DropForeignKey("dbo.ListImageProducts", "Product_ID", "dbo.Products");
            DropIndex("dbo.ListImageProducts", new[] { "Product_ID" });
            DropTable("dbo.ListImageProducts");
        }
    }
}
