namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImagePath");
        }
    }
}
