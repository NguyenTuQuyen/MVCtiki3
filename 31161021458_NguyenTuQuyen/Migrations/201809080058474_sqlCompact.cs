namespace MovieMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlCompact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaChiTietHoaDon = c.Int(nullable: false, identity: true),
                        MaHoaDon = c.Int(nullable: false),
                        MaMovie = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietHoaDon)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MaMovie, cascadeDelete: true)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaMovie);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        TongTien = c.Double(nullable: false),
                        NgayLap = c.DateTime(nullable: false),
                        MaKhachHang = c.Int(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Summary = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(maxLength: 10),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rated = c.Double(nullable: false),
                        PicturePath = c.String(),
                        Picture = c.Binary(),
                        GenreID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.GenreID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaMovie", "dbo.Movies");
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaMovie" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
