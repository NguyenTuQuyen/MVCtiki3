namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
        }
    }
}
