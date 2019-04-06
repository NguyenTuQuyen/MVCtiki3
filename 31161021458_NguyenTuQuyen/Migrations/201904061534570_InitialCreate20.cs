namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryProductID", "dbo.Categories");
            AddColumn("dbo.Categories", "Product_ID", c => c.Int());
            AddColumn("dbo.Products", "Category_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Product_ID");
            CreateIndex("dbo.Products", "Category_ID");
            AddForeignKey("dbo.Categories", "Product_ID", "dbo.Products", "ID");
            AddForeignKey("dbo.Products", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Product_ID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Categories", new[] { "Product_ID" });
            DropColumn("dbo.Products", "Category_ID");
            DropColumn("dbo.Categories", "Product_ID");
            AddForeignKey("dbo.Products", "CategoryProductID", "dbo.Categories", "ID");
        }
    }
}
