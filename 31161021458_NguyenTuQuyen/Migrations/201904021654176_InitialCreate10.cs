namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListImageProducts", "Product_ID", "dbo.Products");
            DropIndex("dbo.ListImageProducts", new[] { "Product_ID" });
            AddColumn("dbo.Products", "ImagePath", c => c.String(nullable: false));
            DropTable("dbo.ListImageProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ListImageProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Products", "ImagePath");
            CreateIndex("dbo.ListImageProducts", "Product_ID");
            AddForeignKey("dbo.ListImageProducts", "Product_ID", "dbo.Products", "ID");
        }
    }
}
