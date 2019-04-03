namespace _31161021458_NguyenTuQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaChiTietHoaDon = c.Int(nullable: false, identity: true),
                        MaHoaDon = c.Int(nullable: false),
                        MaProduct = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietHoaDon)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.MaProduct, cascadeDelete: true)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaProduct);
            
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
                "dbo.ShippingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Email = c.String(),
                        City = c.String(nullable: false),
                        Road = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Messages = c.String(),
                        PromotionCodeInput = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaProduct", "dbo.Products");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaProduct" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            AlterColumn("dbo.Products", "Price", c => c.String(nullable: false));
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
