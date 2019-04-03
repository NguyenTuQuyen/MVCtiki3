namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Rated", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Comment", c => c.String());
            DropColumn("dbo.Products", "Rated");
        }
    }
}
