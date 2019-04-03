namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Product_ID", c => c.Int());
            CreateIndex("dbo.Products", "Product_ID");
            AddForeignKey("dbo.Products", "Product_ID", "dbo.Products", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Product_ID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Product_ID" });
            DropColumn("dbo.Products", "Product_ID");
        }
    }
}
