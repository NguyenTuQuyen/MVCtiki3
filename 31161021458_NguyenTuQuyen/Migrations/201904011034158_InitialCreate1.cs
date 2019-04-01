namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Icon", c => c.String(nullable: false));
        }
    }
}
