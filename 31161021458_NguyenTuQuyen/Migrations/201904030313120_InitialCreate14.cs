namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Product_ID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Product_ID" });
            AddColumn("dbo.Products", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "CategoryProductID", c => c.Int());
            CreateIndex("dbo.Products", "CategoryProductID");
            AddForeignKey("dbo.Products", "CategoryProductID", "dbo.Categories", "ID");
            DropColumn("dbo.Products", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Product_ID", c => c.Int());
            DropForeignKey("dbo.Products", "CategoryProductID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryProductID" });
            AlterColumn("dbo.Products", "CategoryProductID", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Category");
            CreateIndex("dbo.Products", "Product_ID");
            AddForeignKey("dbo.Products", "Product_ID", "dbo.Products", "ID");
        }
    }
}
