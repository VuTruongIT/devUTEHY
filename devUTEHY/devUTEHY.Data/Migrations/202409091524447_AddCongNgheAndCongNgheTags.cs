namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCongNgheAndCongNgheTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CongNghe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        TieuDe = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                        LoaiCongNgheID = c.Int(nullable: false),
                        Icon = c.String(maxLength: 256),
                        Logo = c.String(maxLength: 256),
                        PhienBan = c.String(nullable: false, maxLength: 100),
                        STT = c.Int(),
                        Tags = c.String(),
                        HienThiTrangChu = c.Boolean(),
                        HienThiHot = c.Boolean(),
                        NgayTao = c.DateTime(),
                        NguoiTao = c.String(maxLength: 256),
                        NgayCapNhat = c.DateTime(),
                        NguoiCapNhat = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoaiCongNghe", t => t.LoaiCongNgheID, cascadeDelete: true)
                .Index(t => t.LoaiCongNgheID);
            
            CreateTable(
                "dbo.CongNgheTags",
                c => new
                    {
                        CongNgheID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.CongNgheID, t.TagID })
                .ForeignKey("dbo.CongNghe", t => t.CongNgheID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.CongNgheID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CongNgheTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.CongNgheTags", "CongNgheID", "dbo.CongNghe");
            DropForeignKey("dbo.CongNghe", "LoaiCongNgheID", "dbo.LoaiCongNghe");
            DropIndex("dbo.CongNgheTags", new[] { "TagID" });
            DropIndex("dbo.CongNgheTags", new[] { "CongNgheID" });
            DropIndex("dbo.CongNghe", new[] { "LoaiCongNgheID" });
            DropTable("dbo.CongNgheTags");
            DropTable("dbo.CongNghe");
        }
    }
}
