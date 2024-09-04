namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KhoiTaoCSDLdemolan1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhoaHoc",
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
                "dbo.LoaiCongNghe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 256),
                        TieuDeSEO = c.String(nullable: false, maxLength: 256),
                        MoTa = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        ThuTu = c.Int(),
                        HienThiTrangChu = c.Boolean(),
                        NgayTao = c.DateTime(),
                        NguoiTao = c.String(maxLength: 256),
                        NgayCapNhat = c.DateTime(),
                        NguoiCapNhat = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhoaHocTags",
                c => new
                    {
                        KhoaHocID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.KhoaHocID, t.TagID })
                .ForeignKey("dbo.KhoaHoc", t => t.KhoaHocID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.KhoaHocID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Ten = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KienThucCongNghe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChuDe = c.String(nullable: false, maxLength: 500),
                        TieuDe = c.String(nullable: false, maxLength: 500),
                        MoTa = c.String(nullable: false, maxLength: 500),
                        LinkTaiLieu = c.String(maxLength: 500),
                        KhoaHocID = c.Int(nullable: false),
                        STT = c.Int(),
                        Tags = c.String(),
                        HienThiDanhMuc = c.Boolean(),
                        NgayTao = c.DateTime(),
                        NguoiTao = c.String(maxLength: 256),
                        NgayCapNhat = c.DateTime(),
                        NguoiCapNhat = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KhoaHoc", t => t.KhoaHocID, cascadeDelete: true)
                .Index(t => t.KhoaHocID);
            
            CreateTable(
                "dbo.KienThucCongNgheTags",
                c => new
                    {
                        KienThucCongNgheID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.KienThucCongNgheID, t.TagID })
                .ForeignKey("dbo.KienThucCongNghe", t => t.KienThucCongNgheID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.KienThucCongNgheID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                        Image = c.String(maxLength: 256),
                        Url = c.String(maxLength: 256),
                        DisplayOrder = c.Int(),
                        Status = c.Boolean(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Yahoo = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(maxLength: 50),
                        ValueInt = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KienThucCongNgheTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.KienThucCongNgheTags", "KienThucCongNgheID", "dbo.KienThucCongNghe");
            DropForeignKey("dbo.KienThucCongNghe", "KhoaHocID", "dbo.KhoaHoc");
            DropForeignKey("dbo.KhoaHocTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.KhoaHocTags", "KhoaHocID", "dbo.KhoaHoc");
            DropForeignKey("dbo.KhoaHoc", "LoaiCongNgheID", "dbo.LoaiCongNghe");
            DropIndex("dbo.KienThucCongNgheTags", new[] { "TagID" });
            DropIndex("dbo.KienThucCongNgheTags", new[] { "KienThucCongNgheID" });
            DropIndex("dbo.KienThucCongNghe", new[] { "KhoaHocID" });
            DropIndex("dbo.KhoaHocTags", new[] { "TagID" });
            DropIndex("dbo.KhoaHocTags", new[] { "KhoaHocID" });
            DropIndex("dbo.KhoaHoc", new[] { "LoaiCongNgheID" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.KienThucCongNgheTags");
            DropTable("dbo.KienThucCongNghe");
            DropTable("dbo.Tags");
            DropTable("dbo.KhoaHocTags");
            DropTable("dbo.LoaiCongNghe");
            DropTable("dbo.KhoaHoc");
            DropTable("dbo.Errors");
        }
    }
}
