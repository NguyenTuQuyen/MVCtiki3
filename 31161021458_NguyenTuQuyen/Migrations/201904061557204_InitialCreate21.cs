namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Product_ID", "dbo.Products");
            DropIndex("dbo.Categories", new[] { "Product_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropColumn("dbo.Products", "CategoryProductID");
            RenameColumn(table: "dbo.Products", name: "Category_ID", newName: "CategoryProductID");
            DropColumn("dbo.Categories", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Product_ID", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CategoryProductID", newName: "Category_ID");
            AddColumn("dbo.Products", "CategoryProductID", c => c.Int());
            CreateIndex("dbo.Products", "Category_ID");
            CreateIndex("dbo.Categories", "Product_ID");
            AddForeignKey("dbo.Categories", "Product_ID", "dbo.Products", "ID");
        }
    }
}
