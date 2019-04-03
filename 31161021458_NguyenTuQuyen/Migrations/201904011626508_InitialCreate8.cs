namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath1", c => c.String());
            AddColumn("dbo.Products", "ImagePath2", c => c.String());
            AddColumn("dbo.Products", "ImagePath3", c => c.String());
            AddColumn("dbo.Products", "ImagePath4", c => c.String());
            AddColumn("dbo.Products", "ImagePath5", c => c.String());
            DropColumn("dbo.Products", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropColumn("dbo.Products", "ImagePath5");
            DropColumn("dbo.Products", "ImagePath4");
            DropColumn("dbo.Products", "ImagePath3");
            DropColumn("dbo.Products", "ImagePath2");
            DropColumn("dbo.Products", "ImagePath1");
        }
    }
}
