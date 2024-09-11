namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDanhMucAndDanhMucTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        TieuDe = c.String(nullable: false, maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                        CongNgheID = c.Int(nullable: false),
                        STT = c.Int(),
                        Tags = c.String(),
                        HienThiTrangChu = c.Boolean(),
                        NgayTao = c.DateTime(),
                        NguoiTao = c.String(maxLength: 256),
                        NgayCapNhat = c.DateTime(),
                        NguoiCapNhat = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CongNghe", t => t.CongNgheID, cascadeDelete: true)
                .Index(t => t.CongNgheID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DanhMuc", "CongNgheID", "dbo.CongNghe");
            DropIndex("dbo.DanhMuc", new[] { "CongNgheID" });
            DropTable("dbo.DanhMuc");
        }
    }
}
